namespace AntennaAIDetector_SouthStar.DataSave
{
    partial class DataSaveForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_PathSettingView = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_ResultDatas = new System.Windows.Forms.DataGridView();
            this.label_TimeSpan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_TimeSpanForNewFile = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_QueueSize = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ResultDatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimeSpanForNewFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_QueueSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_PathSettingView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_PathSettingView
            // 
            this.ToolStripMenuItem_PathSettingView.Name = "ToolStripMenuItem_PathSettingView";
            this.ToolStripMenuItem_PathSettingView.Size = new System.Drawing.Size(92, 21);
            this.ToolStripMenuItem_PathSettingView.Text = "打开路径设置";
            this.ToolStripMenuItem_PathSettingView.Click += new System.EventHandler(this.ToolStripMenuItem_PathSettingView_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 165);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown_QueueSize);
            this.panel2.Controls.Add(this.numericUpDown_TimeSpanForNewFile);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label_TimeSpan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.MaximumSize = new System.Drawing.Size(192, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 260);
            this.panel2.TabIndex = 37;
            // 
            // dataGridView_ResultDatas
            // 
            this.dataGridView_ResultDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ResultDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ResultDatas.Location = new System.Drawing.Point(192, 190);
            this.dataGridView_ResultDatas.Name = "dataGridView_ResultDatas";
            this.dataGridView_ResultDatas.RowTemplate.Height = 23;
            this.dataGridView_ResultDatas.Size = new System.Drawing.Size(608, 260);
            this.dataGridView_ResultDatas.TabIndex = 38;
            // 
            // label_TimeSpan
            // 
            this.label_TimeSpan.AutoSize = true;
            this.label_TimeSpan.Location = new System.Drawing.Point(14, 73);
            this.label_TimeSpan.Name = "label_TimeSpan";
            this.label_TimeSpan.Size = new System.Drawing.Size(89, 12);
            this.label_TimeSpan.TabIndex = 0;
            this.label_TimeSpan.Text = "更新周期（h）:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "窗口数据容量：";
            // 
            // numericUpDown_TimeSpanForNewFile
            // 
            this.numericUpDown_TimeSpanForNewFile.Location = new System.Drawing.Point(109, 69);
            this.numericUpDown_TimeSpanForNewFile.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_TimeSpanForNewFile.Name = "numericUpDown_TimeSpanForNewFile";
            this.numericUpDown_TimeSpanForNewFile.Size = new System.Drawing.Size(77, 21);
            this.numericUpDown_TimeSpanForNewFile.TabIndex = 2;
            // 
            // numericUpDown_QueueSize
            // 
            this.numericUpDown_QueueSize.Location = new System.Drawing.Point(109, 115);
            this.numericUpDown_QueueSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_QueueSize.Name = "numericUpDown_QueueSize";
            this.numericUpDown_QueueSize.Size = new System.Drawing.Size(77, 21);
            this.numericUpDown_QueueSize.TabIndex = 3;
            // 
            // DataSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_ResultDatas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataSaveForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "结果保存";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ResultDatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TimeSpanForNewFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_QueueSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_PathSettingView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_ResultDatas;
        private System.Windows.Forms.NumericUpDown numericUpDown_QueueSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_TimeSpanForNewFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_TimeSpan;
    }
}