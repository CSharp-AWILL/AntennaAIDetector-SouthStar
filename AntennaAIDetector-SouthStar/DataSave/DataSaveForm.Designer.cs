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
            this.dataGridView_ResultDatas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ResultDatas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ResultDatas
            // 
            this.dataGridView_ResultDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ResultDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ResultDatas.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ResultDatas.Name = "dataGridView_ResultDatas";
            this.dataGridView_ResultDatas.RowTemplate.Height = 23;
            this.dataGridView_ResultDatas.Size = new System.Drawing.Size(800, 450);
            this.dataGridView_ResultDatas.TabIndex = 0;
            // 
            // DataSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_ResultDatas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataSaveForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "结果保存";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ResultDatas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ResultDatas;
    }
}