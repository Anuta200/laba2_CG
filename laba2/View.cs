using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace laba2
{
    enum ShaderStatus
    {
        OK = 1,
        NotInitilized = 0,
        FileNotFound = -1,
        UnknownShaderFileType = -2,
    }



    class View
    {
        private STriangle[] CubeTriangles = new STriangle[0];

        private int Width;
        private int Height;
        private int VWidth;
        private int VHeight;

        private int BasicProgramID;
        private int BasicVertexShader;
        private int BasicFragmentShader;

        private ShaderStatus Status = ShaderStatus.NotInitilized;

        public const int CUBE_MAX_COUNT = 10;
        public const int CUBE_SIDES_COUNT = 6;
        public const int RAYTRACING_MAX_DEPTH = 10;
        public const int CUBE_TRIANGLES_COUNT = 12;
        public const float TOTAL_VIEW_WIDTH = 9.99f;

        private int CUBE_COUNT = 0;

        public int[] CubeMaterials = new int[CUBE_MAX_COUNT];
        public float[] CubeSizes = new float[CUBE_MAX_COUNT];

        public int RayTracingDepth = RAYTRACING_MAX_DEPTH;

        public OpenTK.Vector3[] CubePositions = new OpenTK.Vector3[CUBE_MAX_COUNT];
        public OpenTK.Vector3 CameraPosition = new OpenTK.Vector3(0.0F, 0.0F, -4.9f);
        public OpenTK.Vector3 LightSourcePosition = new OpenTK.Vector3(2.0f, 4.0f, -4.0f);

        public struct STriangle
        {
            public OpenTK.Vector3 v1;
            public OpenTK.Vector3 v2;
            public OpenTK.Vector3 v3;
            public int MaterialIdx;
        }

        public struct Basis
        {
            public OpenTK.Vector3 top;
            public OpenTK.Vector3 left;
            public OpenTK.Vector3 right;
            public OpenTK.Vector3 bottom;

            public OpenTK.Vector3 align;
        }

        public View(int width, int height, int vwidth, int vheight)
        {
            Width = Math.Abs(width);
            Height = Math.Abs(height);

            VWidth = Math.Abs(vwidth);
            VHeight = Math.Abs(vheight);

            Init();

            InitView(vwidth, vheight);
        }

        private void Init()
        {
            BasicProgramID = GL.CreateProgram();

            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Shaders");
            string vertexPath = Path.Combine(basePath, "raytracing.vert.txt");
            string fragmentPath = Path.Combine(basePath, "raytracing.frag.txt");

            BasicVertexShader = LoadAndAttachShader(vertexPath, ShaderType.VertexShader, BasicProgramID);
            BasicFragmentShader = LoadAndAttachShader(fragmentPath, ShaderType.FragmentShader, BasicProgramID);

            GL.LinkProgram(BasicProgramID);
            GL.GetProgram(BasicProgramID, GetProgramParameterName.LinkStatus, out int status);
            if (status != (int)All.True)
            {
                Console.WriteLine($"[PROGRAM LINK ERROR]: {GL.GetProgramInfoLog(BasicProgramID)}");
            }
            else
            {
                Console.WriteLine("[LINK SUCCESS] Shader program ready");
            }
        }

        public static int LoadAndAttachShader(string path, ShaderType type, int programId)
        {
            string source = File.ReadAllText(path);
            int shaderId = GL.CreateShader(type);
            GL.ShaderSource(shaderId, source);
            GL.CompileShader(shaderId);
            GL.AttachShader(programId, shaderId);
            return shaderId;
        }


            public void InitView(int ViewWidth = 800, int ViewHeight = 600)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Width, 0, Height, -1, 1);
            GL.Viewport(0, 0, VWidth, VHeight);
        }

        public void CubeAdd(float x, float y, float z, int materialIndex, float size)
        {
            if (CUBE_COUNT < CUBE_MAX_COUNT)
            {
                int index = CUBE_COUNT;

                CubeSizes[index] = size;
                CubeMaterials[index] = materialIndex;
                CubePositions[index] = new OpenTK.Vector3(x, y, z);

                CUBE_COUNT += 1;
            }
        }

        private void SetUniform3(string name, OpenTK.Vector3 value)
        {
            GL.Uniform3(GL.GetUniformLocation(BasicProgramID, name), value);
        }

        private void SetUniform2(string name, OpenTK.Vector2 value)
        {
            GL.Uniform2(GL.GetUniformLocation(BasicProgramID, name), value);
        }

        private void SetUniform1(string name, int value)
        {
            GL.Uniform1(GL.GetUniformLocation(BasicProgramID, name), value);
        }

        private STriangle[] CreateCube(OpenTK.Vector3 position, float size)
        {
            STriangle[] Triangles = new STriangle[2 * CUBE_SIDES_COUNT];
            Basis[] basis = new Basis[6];

            // Базис Oxy, Z = 1
            basis[0].top = new OpenTK.Vector3(+0, +1, +0);
            basis[0].left = new OpenTK.Vector3(-1, +0, +0);
            basis[0].right = new OpenTK.Vector3(+1, +0, +0);
            basis[0].bottom = new OpenTK.Vector3(+0, -1, +0);

            basis[0].align = new OpenTK.Vector3(+0, +0, +1);

            // Базис Oxy, Z = -1
            basis[1].top = new OpenTK.Vector3(+0, +1, +0);
            basis[1].left = new OpenTK.Vector3(-1, +0, +0);
            basis[1].right = new OpenTK.Vector3(+1, +0, +0);
            basis[1].bottom = new OpenTK.Vector3(+0, -1, +0);

            basis[1].align = new OpenTK.Vector3(+0, +0, -1);

            // Базис Oyz, X = -1
            basis[2].top = new OpenTK.Vector3(+0, +1, +0);
            basis[2].left = new OpenTK.Vector3(+0, +0, +1);
            basis[2].right = new OpenTK.Vector3(+0, +0, -1);
            basis[2].bottom = new OpenTK.Vector3(+0, -1, +0);

            basis[2].align = new OpenTK.Vector3(-1, +0, +0);


            // Базис Oyz, X = 1
            basis[3].top = new OpenTK.Vector3(+0, -1, +0);
            basis[3].left = new OpenTK.Vector3(+0, +0, +1);
            basis[3].right = new OpenTK.Vector3(+0, +0, -1);
            basis[3].bottom = new OpenTK.Vector3(+0, +1, +0);

            basis[3].align = new OpenTK.Vector3(+1, +0, +0);


            // Базис Oxz, Y = 1
            basis[4].top = new OpenTK.Vector3(+0, +0, +1);
            basis[4].left = new OpenTK.Vector3(-1, +0, +0);
            basis[4].right = new OpenTK.Vector3(+1, +0, +0);
            basis[4].bottom = new OpenTK.Vector3(+0, +0, -1);

            basis[4].align = new OpenTK.Vector3(+0, +1, +0);


            // Базис Oxz, Y = -1
            basis[5].top = new OpenTK.Vector3(+0, +0, +1);
            basis[5].left = new OpenTK.Vector3(-1, +0, +0);
            basis[5].right = new OpenTK.Vector3(+1, +0, +0);
            basis[5].bottom = new OpenTK.Vector3(+0, +0, -1);

            basis[5].align = new OpenTK.Vector3(+0, -1, +0);

            // Правило обхода для создания вершин треугольников
            // Линейная комбинация базисных векторов образует плоскость треугольника в пространстве, масштабируется параметром size
            // Чтобы спозиционировать положение всех пространственных плоскостей используется линейный сдвиг
            for (int i = 0; i < CUBE_SIDES_COUNT; i++)
            {
                Triangles[2 * i + 0].v1 = position + size * (basis[i].align + basis[i].right + basis[i].top);
                Triangles[2 * i + 0].v2 = position + size * (basis[i].align + basis[i].left + basis[i].bottom);
                Triangles[2 * i + 0].v3 = position + size * (basis[i].align + basis[i].right + basis[i].bottom);

                Triangles[2 * i + 1].v1 = position + size * (basis[i].align + basis[i].right + basis[i].top);
                Triangles[2 * i + 1].v2 = position + size * (basis[i].align + basis[i].left + basis[i].top);
                Triangles[2 * i + 1].v3 = position + size * (basis[i].align + basis[i].left + basis[i].bottom);
            }

            return Triangles;
        }

        private void LoadCubes()
        {
            CubeTriangles = new STriangle[0];

            for (int i = 0; i < CUBE_COUNT; i++)
            {
                STriangle[] NextTriangles = CreateCube(CubePositions[i], CubeSizes[i]);

                
                for (int j = 0; j < NextTriangles.Length; j++)
                {
                    NextTriangles[j].MaterialIdx = CubeMaterials[i];
                }

                CubeTriangles = CubeTriangles.Union(NextTriangles).ToArray();
            }

          
            for (int i = 0; i < CubeTriangles.Length; i++)
            {
                SetUniform3("CubeTriangles[" + i + "].v1", CubeTriangles[i].v1);
                SetUniform3("CubeTriangles[" + i + "].v2", CubeTriangles[i].v2);
                SetUniform3("CubeTriangles[" + i + "].v3", CubeTriangles[i].v3);
                SetUniform1("CubeTriangles[" + i + "].MaterialIdx", CubeTriangles[i].MaterialIdx);
            }

        }

        private void UpdateUniforms()
        {
            // Загружаем настройки во фрагментный шейдер
            SetUniform1("CubeLoadedCount", CUBE_COUNT);
            SetUniform1("RayTracingDepth", Math.Max(1, Math.Min(RayTracingDepth, RAYTRACING_MAX_DEPTH)));
            SetUniform3("LIGHT_POSITION", LightSourcePosition);

            SetUniform3("uCamera.Position", CameraPosition);
            SetUniform3("uCamera.View", new OpenTK.Vector3(0.0f, 0.0f, 1.0f));
            SetUniform3("uCamera.Up", new OpenTK.Vector3(0.0f, 1.0f, 0.0f));
            SetUniform3("uCamera.Side", new OpenTK.Vector3(1.0f, 0.0f, 0.0f));

            SetUniform2("uCamera.Scale", new OpenTK.Vector2(1.0f, 1.0f));

            LoadCubes();
        }

        public void DrawQuads()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(BasicProgramID);

            UpdateUniforms();

            GL.Begin(PrimitiveType.Quads);

            GL.Vertex2(-Width, -Height);
            GL.Vertex2(+Width, -Height);
            GL.Vertex2(+Width, +Height);
            GL.Vertex2(-Width, +Height);

            GL.End();
        }
        public void UpdateCubeMaterial(int newMaterialIndex)
        {
            if (CUBE_COUNT == 0)
                return;

            int lastCubeIndex = CUBE_COUNT - 1;

            CubeMaterials[lastCubeIndex] = newMaterialIndex;

            UpdateUniforms();
        }

    }
   
}


