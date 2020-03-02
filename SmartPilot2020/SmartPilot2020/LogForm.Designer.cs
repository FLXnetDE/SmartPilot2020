namespace SmartPilot2020
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.btnClearLog = new System.Windows.Forms.Button();
            this.clbLog = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(12, 487);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(403, 32);
            this.btnClearLog.TabIndex = 16;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // clbLog
            // 
            this.clbLog.BackColor = System.Drawing.Color.White;
            this.clbLog.FormattingEnabled = true;
            this.clbLog.Location = new System.Drawing.Point(12, 12);
            this.clbLog.Name = "clbLog";
            this.clbLog.Size = new System.Drawing.Size(403, 469);
            this.clbLog.TabIndex = 17;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 531);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.clbLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.CheckedListBox clbLog;
    }
}