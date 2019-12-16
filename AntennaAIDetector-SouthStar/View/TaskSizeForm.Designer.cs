namespace AntennaAIDetector_SouthStar.View
{
    partial class TaskSizeForm
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
            this.button_Ensure = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.numericUpDown_TaskSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TaskSize)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Ensure
            // 
            this.button_Ensure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Ensure.Location = new System.Drawing.Point(67, 123);
            this.button_Ensure.Name = "button_Ensure";
            this.button_Ensure.Size = new System.Drawing.Size(75, 23);
            this.button_Ensure.TabIndex = 0;
            this.button_Ensure.Text = "确认";
            this.button_Ensure.UseVisualStyleBackColor = true;
            this.button_Ensure.Click += new System.EventHandler(this.button_Ensure_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(228, 123);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // numericUpDown_TaskSize
            // 
            this.numericUpDown_TaskSize.Location = new System.Drawing.Point(168, 60);
            this.numericUpDown_TaskSize.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_TaskSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_TaskSize.Name = "numericUpDown_TaskSize";
            this.numericUpDown_TaskSize.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown_TaskSize.TabIndex = 2;
            this.numericUpDown_TaskSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "视野内产品数量：";
            // 
            // TaskSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 201);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_TaskSize);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ensure);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "TaskSizeForm";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模式设置";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TaskSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Ensure;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.NumericUpDown numericUpDown_TaskSize;
        private System.Windows.Forms.Label label1;
    }
}