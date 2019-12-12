namespace AntennaAIDetector_SouthStar.Detector
{
    partial class DetectorForm
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
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_ParamView = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Run = new System.Windows.Forms.ToolStripMenuItem();
            this.panelOfDefaultView = new System.Windows.Forms.Panel();
            this.panelOfParamView = new System.Windows.Forms.Panel();
            this.statusStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.Gray;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelResult,
            this.labelRunTime,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip2.Location = new System.Drawing.Point(0, 739);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 33;
            this.statusStrip2.Text = "statusStrip1";
            // 
            // labelResult
            // 
            this.labelResult.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelResult.AutoSize = false;
            this.labelResult.Name = "labelResult";
            this.labelResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelResult.Size = new System.Drawing.Size(300, 17);
            this.labelResult.Text = "运行状态：OK";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelResult.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // labelRunTime
            // 
            this.labelRunTime.AutoSize = false;
            this.labelRunTime.Name = "labelRunTime";
            this.labelRunTime.Size = new System.Drawing.Size(300, 17);
            this.labelRunTime.Text = "运行时间(ms) 0.00  ";
            this.labelRunTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(457, 17);
            this.toolStripStatusLabel5.Spring = true;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel6.Text = "Design By Aqrose";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ParamView,
            this.ToolStripMenuItem_Run});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_ParamView
            // 
            this.ToolStripMenuItem_ParamView.Name = "ToolStripMenuItem_ParamView";
            this.ToolStripMenuItem_ParamView.Size = new System.Drawing.Size(92, 21);
            this.ToolStripMenuItem_ParamView.Text = "打开参数设置";
            this.ToolStripMenuItem_ParamView.Click += new System.EventHandler(this.ToolStripMenuItem_ParamView_Click);
            // 
            // ToolStripMenuItem_Run
            // 
            this.ToolStripMenuItem_Run.Name = "ToolStripMenuItem_Run";
            this.ToolStripMenuItem_Run.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItem_Run.Text = "运行测试";
            this.ToolStripMenuItem_Run.Click += new System.EventHandler(this.ToolStripMenuItem_Run_Click);
            // 
            // panelOfDefaultView
            // 
            this.panelOfDefaultView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOfDefaultView.Location = new System.Drawing.Point(0, 25);
            this.panelOfDefaultView.Name = "panelOfDefaultView";
            this.panelOfDefaultView.Size = new System.Drawing.Size(1184, 714);
            this.panelOfDefaultView.TabIndex = 35;
            // 
            // panelOfParamView
            // 
            this.panelOfParamView.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOfParamView.Location = new System.Drawing.Point(159, 25);
            this.panelOfParamView.Name = "panelOfParamView";
            this.panelOfParamView.Size = new System.Drawing.Size(1025, 714);
            this.panelOfParamView.TabIndex = 36;
            // 
            // DetectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panelOfParamView);
            this.Controls.Add(this.panelOfDefaultView);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1800, 1600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "DetectorForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "南斗星天线检测";
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel labelResult;
        private System.Windows.Forms.ToolStripStatusLabel labelRunTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ParamView;
        private System.Windows.Forms.Panel panelOfDefaultView;
        private System.Windows.Forms.Panel panelOfParamView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Run;
    }
}