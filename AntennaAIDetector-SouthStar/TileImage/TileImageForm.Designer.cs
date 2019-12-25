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
            this.button1 = new System.Windows.Forms.Button();
            this.aqDisplay1 = new AqVision.Controls.AqDisplay();
            this.button_LoadSingleImage = new System.Windows.Forms.Button();
            this.button_TileSingleImages = new System.Windows.Forms.Button();
            this.button_DisplayResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // aqDisplay1
            // 
            this.aqDisplay1.BackColor = System.Drawing.Color.Black;
            this.aqDisplay1.Dock = System.Windows.Forms.DockStyle.Right;
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
            this.aqDisplay1.Location = new System.Drawing.Point(232, 0);
            this.aqDisplay1.Margin = new System.Windows.Forms.Padding(2);
            this.aqDisplay1.Name = "aqDisplay1";
            this.aqDisplay1.OriginMaskImage = null;
            this.aqDisplay1.Radius = 1F;
            this.aqDisplay1.Size = new System.Drawing.Size(617, 489);
            this.aqDisplay1.TabIndex = 1;
            // 
            // button_LoadSingleImage
            // 
            this.button_LoadSingleImage.Location = new System.Drawing.Point(56, 150);
            this.button_LoadSingleImage.Name = "button_LoadSingleImage";
            this.button_LoadSingleImage.Size = new System.Drawing.Size(91, 33);
            this.button_LoadSingleImage.TabIndex = 2;
            this.button_LoadSingleImage.Text = "读取拼接模型";
            this.button_LoadSingleImage.UseVisualStyleBackColor = true;
            this.button_LoadSingleImage.Click += new System.EventHandler(this.button_LoadSingleImage_Click);
            // 
            // button_TileSingleImages
            // 
            this.button_TileSingleImages.Location = new System.Drawing.Point(56, 224);
            this.button_TileSingleImages.Name = "button_TileSingleImages";
            this.button_TileSingleImages.Size = new System.Drawing.Size(91, 33);
            this.button_TileSingleImages.TabIndex = 3;
            this.button_TileSingleImages.Text = "拼接示意图像";
            this.button_TileSingleImages.UseVisualStyleBackColor = true;
            this.button_TileSingleImages.Click += new System.EventHandler(this.button_TileSingleImages_Click);
            // 
            // button_DisplayResult
            // 
            this.button_DisplayResult.Location = new System.Drawing.Point(56, 293);
            this.button_DisplayResult.Name = "button_DisplayResult";
            this.button_DisplayResult.Size = new System.Drawing.Size(91, 33);
            this.button_DisplayResult.TabIndex = 4;
            this.button_DisplayResult.Text = "显示当前结果";
            this.button_DisplayResult.UseVisualStyleBackColor = true;
            this.button_DisplayResult.Click += new System.EventHandler(this.button_DisplayResult_Click);
            // 
            // TileImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 489);
            this.Controls.Add(this.button_DisplayResult);
            this.Controls.Add(this.button_TileSingleImages);
            this.Controls.Add(this.button_LoadSingleImage);
            this.Controls.Add(this.aqDisplay1);
            this.Controls.Add(this.button1);
            this.Name = "TileImageForm";
            this.Text = "TileImageForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private AqVision.Controls.AqDisplay aqDisplay1;
        private System.Windows.Forms.Button button_LoadSingleImage;
        private System.Windows.Forms.Button button_TileSingleImages;
        private System.Windows.Forms.Button button_DisplayResult;
    }
}