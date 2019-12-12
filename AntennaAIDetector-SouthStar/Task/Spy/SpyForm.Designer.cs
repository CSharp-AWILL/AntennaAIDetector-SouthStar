namespace AntennaAIDetector_SouthStar.Task.Spy
{
    partial class SpyForm
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
            this.comboBox_IndexOfTask = new System.Windows.Forms.ComboBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_IndexOfTask
            // 
            this.comboBox_IndexOfTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_IndexOfTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IndexOfTask.FormattingEnabled = true;
            this.comboBox_IndexOfTask.Location = new System.Drawing.Point(92, 68);
            this.comboBox_IndexOfTask.Name = "comboBox_IndexOfTask";
            this.comboBox_IndexOfTask.Size = new System.Drawing.Size(137, 20);
            this.comboBox_IndexOfTask.TabIndex = 10;
            this.comboBox_IndexOfTask.TextChanged += new System.EventHandler(this.comboBox_IndexOfTask_TextChanged);
            // 
            // label_Status
            // 
            this.label_Status.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(235, 71);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(17, 12);
            this.label_Status.TabIndex = 9;
            this.label_Status.Text = "空";
            // 
            // SpyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 161);
            this.Controls.Add(this.comboBox_IndexOfTask);
            this.Controls.Add(this.label_Status);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 200);
            this.Name = "SpyForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务监控";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_IndexOfTask;
        private System.Windows.Forms.Label label_Status;
    }
}