namespace AntennaAIDetector_SouthStar.View
{
    partial class FilePathView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.btnClearText = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.textBoxDirPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "不支持存储至系统盘";
            // 
            // btnClearText
            // 
            this.btnClearText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearText.Location = new System.Drawing.Point(393, 89);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(36, 21);
            this.btnClearText.TabIndex = 24;
            this.btnClearText.Text = "del";
            this.btnClearText.UseVisualStyleBackColor = true;
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxFileName.Location = new System.Drawing.Point(96, 90);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(291, 21);
            this.textBoxFileName.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "文件名称：";
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDir.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenDir.Location = new System.Drawing.Point(393, 35);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(36, 21);
            this.btnOpenDir.TabIndex = 21;
            this.btnOpenDir.Text = "...";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // textBoxDirPath
            // 
            this.textBoxDirPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDirPath.Location = new System.Drawing.Point(96, 36);
            this.textBoxDirPath.Name = "textBoxDirPath";
            this.textBoxDirPath.Size = new System.Drawing.Size(291, 21);
            this.textBoxDirPath.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "存储目录：";
            // 
            // FilePathView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClearText);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.textBoxDirPath);
            this.Controls.Add(this.label5);
            this.Name = "FilePathView";
            this.Size = new System.Drawing.Size(449, 146);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClearText;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.TextBox textBoxDirPath;
        private System.Windows.Forms.Label label5;
    }
}
