namespace AntennaAIDetector_SouthStar.TileImage
{
    partial class TileImageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.aqDisplay1 = new AqVision.Controls.AqDisplay();
            this.button_LoadSingleImage = new System.Windows.Forms.Button();
            this.button_TileSingleImages = new System.Windows.Forms.Button();
            this.button_DisplayResult = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBoxDisplayWindowName = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // aqDisplay1
            // 
            this.aqDisplay1.BackColor = System.Drawing.Color.Black;
            this.aqDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aqDisplay1.GroupName = "";
            this.aqDisplay1.Image = null;
            this.aqDisplay1.IsAddDynamicPoint = false;
            this.aqDisplay1.IsBeginAddImageMask = false;
            this.aqDisplay1.IsBeginDrawDynamicPolygon = false;
            this.aqDisplay1.IsInteractiveFlag = true;
            this.aqDisplay1.IsSaveResultImage = false;
            this.aqDisplay1.IsScrollBar = true;
            this.aqDisplay1.IsShowCenterLine = true;
            this.aqDisplay1.IsShowStatusBar = true;
            this.aqDisplay1.IsTransformRGB = false;
            this.aqDisplay1.IsUsedEraser = false;
            this.aqDisplay1.Location = new System.Drawing.Point(0, 0);
            this.aqDisplay1.Margin = new System.Windows.Forms.Padding(2);
            this.aqDisplay1.Name = "aqDisplay1";
            this.aqDisplay1.OriginMaskImage = null;
            this.aqDisplay1.Radius = 1F;
            this.aqDisplay1.Size = new System.Drawing.Size(849, 489);
            this.aqDisplay1.TabIndex = 1;
            this.aqDisplay1.SizeChanged += new System.EventHandler(this.aqDisplay1_SizeChanged);
            // 
            // button_LoadSingleImage
            // 
            this.button_LoadSingleImage.Location = new System.Drawing.Point(14, 49);
            this.button_LoadSingleImage.Name = "button_LoadSingleImage";
            this.button_LoadSingleImage.Size = new System.Drawing.Size(91, 33);
            this.button_LoadSingleImage.TabIndex = 2;
            this.button_LoadSingleImage.Text = "读取拼接模型";
            this.button_LoadSingleImage.UseVisualStyleBackColor = true;
            this.button_LoadSingleImage.Click += new System.EventHandler(this.button_LoadSingleImage_Click);
            // 
            // button_TileSingleImages
            // 
            this.button_TileSingleImages.Location = new System.Drawing.Point(14, 117);
            this.button_TileSingleImages.Name = "button_TileSingleImages";
            this.button_TileSingleImages.Size = new System.Drawing.Size(91, 33);
            this.button_TileSingleImages.TabIndex = 3;
            this.button_TileSingleImages.Text = "拼接示意图像";
            this.button_TileSingleImages.UseVisualStyleBackColor = true;
            this.button_TileSingleImages.Click += new System.EventHandler(this.button_TileSingleImages_Click);
            // 
            // button_DisplayResult
            // 
            this.button_DisplayResult.Location = new System.Drawing.Point(14, 182);
            this.button_DisplayResult.Name = "button_DisplayResult";
            this.button_DisplayResult.Size = new System.Drawing.Size(91, 33);
            this.button_DisplayResult.TabIndex = 4;
            this.button_DisplayResult.Text = "显示当前结果";
            this.button_DisplayResult.UseVisualStyleBackColor = true;
            this.button_DisplayResult.Click += new System.EventHandler(this.button_DisplayResult_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button_LoadSingleImage);
            this.panel1.Controls.Add(this.button_DisplayResult);
            this.panel1.Controls.Add(this.button_TileSingleImages);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 489);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 146);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示设置";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBoxShow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(119, 63);
            this.panel3.TabIndex = 1;
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Location = new System.Drawing.Point(23, 23);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(72, 16);
            this.checkBoxShow.TabIndex = 4;
            this.checkBoxShow.Text = "是否显示";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(119, 63);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBoxDisplayWindowName);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(80, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(39, 63);
            this.panel5.TabIndex = 1;
            // 
            // comboBoxDisplayWindowName
            // 
            this.comboBoxDisplayWindowName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDisplayWindowName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplayWindowName.FormattingEnabled = true;
            this.comboBoxDisplayWindowName.Location = new System.Drawing.Point(3, 22);
            this.comboBoxDisplayWindowName.Name = "comboBoxDisplayWindowName";
            this.comboBoxDisplayWindowName.Size = new System.Drawing.Size(0, 20);
            this.comboBoxDisplayWindowName.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(80, 63);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "窗口名";
            // 
            // TileImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 489);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.aqDisplay1);
            this.Name = "TileImageForm";
            this.Text = "TileImageForm";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private AqVision.Controls.AqDisplay aqDisplay1;
        private System.Windows.Forms.Button button_LoadSingleImage;
        private System.Windows.Forms.Button button_TileSingleImages;
        private System.Windows.Forms.Button button_DisplayResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBoxDisplayWindowName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
    }
}