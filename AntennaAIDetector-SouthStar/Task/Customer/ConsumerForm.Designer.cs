namespace AntennaAIDetector_SouthStar.Task.Consumer
{
    partial class ConsumerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBoxDisplayWindowName = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Test = new System.Windows.Forms.Button();
            this.aqDisplay1 = new AqVision.Controls.AqDisplay();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.labelResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboBox_Index = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 449);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "显示设置";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBoxShow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 63);
            this.panel3.TabIndex = 1;
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Location = new System.Drawing.Point(92, 23);
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
            this.panel2.Size = new System.Drawing.Size(257, 63);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBoxDisplayWindowName);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(80, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(177, 63);
            this.panel5.TabIndex = 1;
            // 
            // comboBoxDisplayWindowName
            // 
            this.comboBoxDisplayWindowName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDisplayWindowName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplayWindowName.FormattingEnabled = true;
            this.comboBoxDisplayWindowName.Location = new System.Drawing.Point(3, 22);
            this.comboBoxDisplayWindowName.Name = "comboBoxDisplayWindowName";
            this.comboBoxDisplayWindowName.Size = new System.Drawing.Size(131, 20);
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
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(3, 3);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(69, 23);
            this.button_Test.TabIndex = 2;
            this.button_Test.Text = "运行测试";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
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
            this.aqDisplay1.Size = new System.Drawing.Size(617, 595);
            this.aqDisplay1.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.Gray;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelResult,
            this.labelRunTime,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip2.Location = new System.Drawing.Point(0, 595);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(884, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 36;
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
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(157, 17);
            this.toolStripStatusLabel5.Spring = true;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel6.Text = "Design By Aqrose";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_Test);
            this.splitContainer1.Panel2.Controls.Add(this.aqDisplay1);
            this.splitContainer1.Size = new System.Drawing.Size(884, 595);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 449);
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(263, 63);
            this.panel6.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.comboBox_Index);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(80, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(183, 63);
            this.panel7.TabIndex = 1;
            // 
            // comboBox_Index
            // 
            this.comboBox_Index.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Index.FormattingEnabled = true;
            this.comboBox_Index.Location = new System.Drawing.Point(3, 22);
            this.comboBox_Index.Name = "comboBox_Index";
            this.comboBox_Index.Size = new System.Drawing.Size(137, 20);
            this.comboBox_Index.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(80, 63);
            this.panel8.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "下标";
            // 
            // ConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 617);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1800, 1600);
            this.Name = "ConsumerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "取图";
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBoxDisplayWindowName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Test;
        private AqVision.Controls.AqDisplay aqDisplay1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel labelResult;
        private System.Windows.Forms.ToolStripStatusLabel labelRunTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox comboBox_Index;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
    }
}