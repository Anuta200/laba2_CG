namespace laba2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>


        #endregion



        private void InitializeComponent()
        {
            this.tbPosY = new System.Windows.Forms.TrackBar();
            this.trackRayTrDepth = new System.Windows.Forms.TrackBar();
            this.radioLight = new System.Windows.Forms.RadioButton();
            this.radioCamera = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddCube = new System.Windows.Forms.Button();
            this.comboSize = new System.Windows.Forms.ComboBox();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.textCubePosZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textCubePosY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCubePosX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPosX = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRayTrDepth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosX)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPosY
            // 
            this.tbPosY.Location = new System.Drawing.Point(606, 13);
            this.tbPosY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPosY.Maximum = 50;
            this.tbPosY.Minimum = -50;
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbPosY.Size = new System.Drawing.Size(56, 447);
            this.tbPosY.TabIndex = 3;
            this.tbPosY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbPosY.Value = 2;
            this.tbPosY.Scroll += new System.EventHandler(this.tbPosY_Scroll);
            // 
            // trackRayTrDepth
            // 
            this.trackRayTrDepth.Location = new System.Drawing.Point(690, 241);
            this.trackRayTrDepth.Minimum = 1;
            this.trackRayTrDepth.Name = "trackRayTrDepth";
            this.trackRayTrDepth.Size = new System.Drawing.Size(531, 56);
            this.trackRayTrDepth.TabIndex = 7;
            this.trackRayTrDepth.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackRayTrDepth.Value = 10;
            this.trackRayTrDepth.Scroll += new System.EventHandler(this.SetRayTracingDepth);
            // 
            // radioLight
            // 
            this.radioLight.AutoSize = true;
            this.radioLight.Checked = true;
            this.radioLight.Location = new System.Drawing.Point(691, 41);
            this.radioLight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioLight.Name = "radioLight";
            this.radioLight.Size = new System.Drawing.Size(56, 20);
            this.radioLight.TabIndex = 0;
            this.radioLight.TabStop = true;
            this.radioLight.Text = "Light\r\n";
            this.radioLight.UseVisualStyleBackColor = true;
            this.radioLight.CheckedChanged += new System.EventHandler(this.radioPositionChanged);
            // 
            // radioCamera
            // 
            this.radioCamera.AutoSize = true;
            this.radioCamera.Location = new System.Drawing.Point(794, 42);
            this.radioCamera.Name = "radioCamera";
            this.radioCamera.Size = new System.Drawing.Size(76, 20);
            this.radioCamera.TabIndex = 1;
            this.radioCamera.TabStop = true;
            this.radioCamera.Text = "Camera";
            this.radioCamera.UseVisualStyleBackColor = true;
            this.radioCamera.CheckedChanged += new System.EventHandler(this.radioPositionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddCube);
            this.groupBox1.Controls.Add(this.comboSize);
            this.groupBox1.Controls.Add(this.comboColor);
            this.groupBox1.Controls.Add(this.textCubePosZ);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textCubePosY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textCubePosX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(691, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cubes";
            // 
            // buttonAddCube
            // 
            this.buttonAddCube.Location = new System.Drawing.Point(385, 29);
            this.buttonAddCube.Name = "buttonAddCube";
            this.buttonAddCube.Size = new System.Drawing.Size(97, 49);
            this.buttonAddCube.TabIndex = 0;
            this.buttonAddCube.Text = "Add cube";
            this.buttonAddCube.UseVisualStyleBackColor = true;
            this.buttonAddCube.Click += new System.EventHandler(this.buttonAddCube_Click_1);
            // 
            // comboSize
            // 
            this.comboSize.FormattingEnabled = true;
            this.comboSize.Items.AddRange(new object[] {
            "0.1",
            "0.3",
            "0.5",
            "1",
            "2",
            "3"});
            this.comboSize.Location = new System.Drawing.Point(172, 70);
            this.comboSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboSize.Name = "comboSize";
            this.comboSize.Size = new System.Drawing.Size(121, 24);
            this.comboSize.TabIndex = 8;
            this.comboSize.Text = "Size";
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Items.AddRange(new object[] {
            "RED",
            "GREEN",
            "BLUE",
            "YELLOW",
            "WHITE"});
            this.comboColor.Location = new System.Drawing.Point(10, 70);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(121, 24);
            this.comboColor.TabIndex = 7;
            this.comboColor.Text = "Color";
            // 
            // textCubePosZ
            // 
            this.textCubePosZ.Location = new System.Drawing.Point(263, 29);
            this.textCubePosZ.Name = "textCubePosZ";
            this.textCubePosZ.Size = new System.Drawing.Size(100, 22);
            this.textCubePosZ.TabIndex = 5;
            this.textCubePosZ.Text = "0";
            this.textCubePosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Z";
            // 
            // textCubePosY
            // 
            this.textCubePosY.Location = new System.Drawing.Point(145, 29);
            this.textCubePosY.Name = "textCubePosY";
            this.textCubePosY.Size = new System.Drawing.Size(91, 22);
            this.textCubePosY.TabIndex = 3;
            this.textCubePosY.Text = "0";
            this.textCubePosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y";
            // 
            // textCubePosX
            // 
            this.textCubePosX.Location = new System.Drawing.Point(30, 30);
            this.textCubePosX.Name = "textCubePosX";
            this.textCubePosX.Size = new System.Drawing.Size(87, 22);
            this.textCubePosX.TabIndex = 1;
            this.textCubePosX.Text = "0";
            this.textCubePosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // tbPosX
            // 
            this.tbPosX.Location = new System.Drawing.Point(13, 468);
            this.tbPosX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPosX.Maximum = 50;
            this.tbPosX.Minimum = -50;
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.Size = new System.Drawing.Size(565, 56);
            this.tbPosX.TabIndex = 2;
            this.tbPosX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbPosX.Value = 2;
            this.tbPosX.Scroll += new System.EventHandler(this.tbPosX_Scroll);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1233, 521);
            this.Controls.Add(this.tbPosX);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioCamera);
            this.Controls.Add(this.radioLight);
            this.Controls.Add(this.trackRayTrDepth);
            this.Controls.Add(this.tbPosY);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRayTrDepth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPosX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private OpenTK.GLControl GLView;
        private System.Windows.Forms.TrackBar tbPosY;
        private System.Windows.Forms.TrackBar trackRayTrDepth;
        private System.Windows.Forms.RadioButton radioLight;
        private System.Windows.Forms.RadioButton radioCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textCubePosY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCubePosX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.TextBox textCubePosZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddCube;
        private System.Windows.Forms.ComboBox comboSize;
        private System.Windows.Forms.TrackBar tbPosX;
    }
}

