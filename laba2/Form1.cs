using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba2
{

    public partial class Form1 : Form
    {
        private OpenTK.GLControl GLViewer;

        private float TrackBarStepX = 1.0F;
        private float TrackBarStepY = 1.0F;
        private float TrackBarStepZ = 1.0F;

        private View SV;
        public Form1()
        {
            InitializeComponent();

            GLViewer = new OpenTK.GLControl(new OpenTK.Graphics.GraphicsMode(32, 24, 0, 8));

            GLViewer.Paint += GLPaint;
            GLViewer.MouseWheel += PosZ;

            Controls.Add(GLViewer);

            GLViewer.Top = 12;
            GLViewer.Left = 12;
            GLViewer.Width = 595;
            GLViewer.Height = 595;
        }



        private void GLPaint(object sender, PaintEventArgs e)
        {
            GLViewer.MakeCurrent();
            SV.DrawQuads();
            GLViewer.SwapBuffers();
        }



        private void PosZ(object sender, MouseEventArgs e)
        {
            int DeltaNormalized = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            if (radioLight.Checked)
            {
                SV.LightSourcePosition.Z += TrackBarStepZ * DeltaNormalized;
            }
            else if (radioCamera.Checked)
            {
                SV.CameraPosition.Z += TrackBarStepZ * DeltaNormalized;
            }

            GLViewer.Invalidate();
        }



        private void tbPosY_Scroll(object sender, EventArgs e)
        {
            if (radioLight.Checked)
            {
                SV.LightSourcePosition.Y = TrackBarStepY * tbPosY.Value;
            }
            else if (radioCamera.Checked)
            {
                SV.CameraPosition.Y = TrackBarStepY * tbPosY.Value;
            }

            GLViewer.Invalidate();
        }
        private void radioPositionChanged(object sender, EventArgs e)
        {
            if (radioLight.Checked)
            {
                tbPosX.Value = (int)(SV.LightSourcePosition.X / TrackBarStepX);
                tbPosY.Value = (int)(SV.LightSourcePosition.Y / TrackBarStepY);
            }
            else if (radioCamera.Checked)
            {
                tbPosX.Value = (int)(SV.CameraPosition.X / TrackBarStepX);
                tbPosY.Value = (int)(SV.CameraPosition.Y / TrackBarStepY);
            }
        }



        private void SetRayTracingDepth(object sender, EventArgs e)
        {
            SV.RayTracingDepth = Convert.ToInt32(trackRayTrDepth.Value);
            GLViewer.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SV = new View(GLViewer.Width, GLViewer.Height, GLViewer.Width, GLViewer.Height);

            TrackBarStepX = View.TOTAL_VIEW_WIDTH / (tbPosX.Maximum - tbPosX.Minimum);
            TrackBarStepY = View.TOTAL_VIEW_WIDTH / (tbPosY.Maximum - tbPosY.Minimum);
            TrackBarStepZ = View.TOTAL_VIEW_WIDTH / 100.0F;

            GLViewer.MakeCurrent();
        }

        private void buttonAddCube_Click_1(object sender, EventArgs e)
        {
            float x = (float)Convert.ToDouble(textCubePosX.Text.Replace('.', ',').Trim());
            float y = (float)Convert.ToDouble(textCubePosY.Text.Replace('.', ',').Trim());
            float z = (float)Convert.ToDouble(textCubePosZ.Text.Replace('.', ',').Trim());

            int colorIndex = comboColor.SelectedIndex;
            string sizeStr = comboSize.SelectedItem as string;

            if (sizeStr != null)
            {
                float sizeFlt = (float)Convert.ToDouble(sizeStr.Replace('.', ',').Trim());
                SV.CubeAdd(x, y, z, colorIndex, sizeFlt);
                GLViewer.Invalidate();
            }
        }

        private void tbPosX_Scroll(object sender, EventArgs e)
        {
            if (radioLight.Checked)
            {
                SV.LightSourcePosition.X = TrackBarStepX * tbPosX.Value;
            }
            else if (radioCamera.Checked)
            {
                SV.CameraPosition.X = TrackBarStepX * tbPosX.Value;
            }

            GLViewer.Invalidate();
        }

        private void radioCamera_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColor = comboColor.SelectedItem.ToString();
            int materialIndex = 0;

            switch (selectedColor)
            {
                case "RED":
                    materialIndex = 0;
                    break;
                case "GREEN":
                    materialIndex = 1;
                    break;
                case "BLUE":
                    materialIndex = 2;
                    break;
                case "YELLOW":
                    materialIndex = 3;
                    break;
                case "WHITE":
                    materialIndex = 4;
                    break;
                case "REFLECTION":
                    materialIndex = 5;
                    break;
            }

            SV.UpdateCubeMaterial(materialIndex);
            GLViewer.Invalidate();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }





}
