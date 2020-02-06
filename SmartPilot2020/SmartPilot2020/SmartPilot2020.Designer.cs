namespace RCAutopilot
{
    partial class SmartPilot2020
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartPilot2020));
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.btnShutdown = new System.Windows.Forms.ToolStripButton();
            this.btnConnectComPort = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnectComPort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblJoystick = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblComPort = new System.Windows.Forms.ToolStripLabel();
            this.lblPacketOutput = new System.Windows.Forms.ToolStripLabel();
            this.btnStopOutgoingPackets = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.lblTrafficMonnitor = new System.Windows.Forms.ToolStripStatusLabel();
            this.clbLog = new System.Windows.Forms.CheckedListBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.pbPitchRollVisualization = new System.Windows.Forms.PictureBox();
            this.pbMonitorVisualization = new System.Windows.Forms.PictureBox();
            this.pbSpeedVisualization = new System.Windows.Forms.PictureBox();
            this.pbAltitudeVisualization = new System.Windows.Forms.PictureBox();
            this.pbHeadingVisualization = new System.Windows.Forms.PictureBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.tsTop.SuspendLayout();
            this.ssBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPitchRollVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitorVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingVisualization)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShutdown,
            this.btnConnectComPort,
            this.btnDisconnectComPort,
            this.toolStripSeparator1,
            this.lblJoystick,
            this.toolStripSeparator2,
            this.lblComPort,
            this.lblPacketOutput,
            this.btnStopOutgoingPackets,
            this.toolStripSeparator3});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(1236, 25);
            this.tsTop.TabIndex = 13;
            this.tsTop.Text = "Top";
            // 
            // btnShutdown
            // 
            this.btnShutdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShutdown.Image = ((System.Drawing.Image)(resources.GetObject("btnShutdown.Image")));
            this.btnShutdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(23, 22);
            this.btnShutdown.Text = "Exit application";
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnConnectComPort
            // 
            this.btnConnectComPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnectComPort.Image = ((System.Drawing.Image)(resources.GetObject("btnConnectComPort.Image")));
            this.btnConnectComPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnectComPort.Name = "btnConnectComPort";
            this.btnConnectComPort.Size = new System.Drawing.Size(23, 22);
            this.btnConnectComPort.Text = "Connect ComPort";
            this.btnConnectComPort.Click += new System.EventHandler(this.btnConnectComPort_Click);
            // 
            // btnDisconnectComPort
            // 
            this.btnDisconnectComPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDisconnectComPort.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnectComPort.Image")));
            this.btnDisconnectComPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnectComPort.Name = "btnDisconnectComPort";
            this.btnDisconnectComPort.Size = new System.Drawing.Size(23, 22);
            this.btnDisconnectComPort.Text = "Disconnect ComPort";
            this.btnDisconnectComPort.Click += new System.EventHandler(this.btnDisconnectComPort_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblJoystick
            // 
            this.lblJoystick.Name = "lblJoystick";
            this.lblJoystick.Size = new System.Drawing.Size(61, 22);
            this.lblJoystick.Text = "lblJoystick";
            this.lblJoystick.ToolTipText = "Connected & used JoyStick";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblComPort
            // 
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(68, 22);
            this.lblComPort.Text = "lblComPort";
            this.lblComPort.ToolTipText = "SerialPort connection";
            // 
            // lblPacketOutput
            // 
            this.lblPacketOutput.Name = "lblPacketOutput";
            this.lblPacketOutput.Size = new System.Drawing.Size(93, 22);
            this.lblPacketOutput.Text = "lblPacketOutput";
            this.lblPacketOutput.ToolTipText = "Remote packet output state";
            // 
            // btnStopOutgoingPackets
            // 
            this.btnStopOutgoingPackets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopOutgoingPackets.Image = ((System.Drawing.Image)(resources.GetObject("btnStopOutgoingPackets.Image")));
            this.btnStopOutgoingPackets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopOutgoingPackets.Name = "btnStopOutgoingPackets";
            this.btnStopOutgoingPackets.Size = new System.Drawing.Size(23, 22);
            this.btnStopOutgoingPackets.Text = "Strop outgoing packets";
            this.btnStopOutgoingPackets.Click += new System.EventHandler(this.btnStopOutgoingPackets_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrafficMonnitor});
            this.ssBottom.Location = new System.Drawing.Point(0, 533);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(1236, 22);
            this.ssBottom.TabIndex = 14;
            this.ssBottom.Text = "Bottom";
            // 
            // lblTrafficMonnitor
            // 
            this.lblTrafficMonnitor.ForeColor = System.Drawing.Color.Black;
            this.lblTrafficMonnitor.Name = "lblTrafficMonnitor";
            this.lblTrafficMonnitor.Size = new System.Drawing.Size(61, 17);
            this.lblTrafficMonnitor.Text = "RX - / TX -";
            // 
            // clbLog
            // 
            this.clbLog.BackColor = System.Drawing.Color.White;
            this.clbLog.FormattingEnabled = true;
            this.clbLog.Location = new System.Drawing.Point(839, 27);
            this.clbLog.Name = "clbLog";
            this.clbLog.Size = new System.Drawing.Size(388, 454);
            this.clbLog.TabIndex = 15;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(839, 484);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(388, 46);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // pbPitchRollVisualization
            // 
            this.pbPitchRollVisualization.Location = new System.Drawing.Point(123, 111);
            this.pbPitchRollVisualization.Name = "pbPitchRollVisualization";
            this.pbPitchRollVisualization.Size = new System.Drawing.Size(300, 300);
            this.pbPitchRollVisualization.TabIndex = 18;
            this.pbPitchRollVisualization.TabStop = false;
            this.pbPitchRollVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPitchRollVisualization_Paint);
            // 
            // pbMonitorVisualization
            // 
            this.pbMonitorVisualization.Location = new System.Drawing.Point(57, 45);
            this.pbMonitorVisualization.Name = "pbMonitorVisualization";
            this.pbMonitorVisualization.Size = new System.Drawing.Size(432, 60);
            this.pbMonitorVisualization.TabIndex = 21;
            this.pbMonitorVisualization.TabStop = false;
            this.pbMonitorVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMonitorVisualization_Paint);
            // 
            // pbSpeedVisualization
            // 
            this.pbSpeedVisualization.Location = new System.Drawing.Point(57, 111);
            this.pbSpeedVisualization.Name = "pbSpeedVisualization";
            this.pbSpeedVisualization.Size = new System.Drawing.Size(60, 300);
            this.pbSpeedVisualization.TabIndex = 22;
            this.pbSpeedVisualization.TabStop = false;
            this.pbSpeedVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSpeedVisualization_Paint);
            // 
            // pbAltitudeVisualization
            // 
            this.pbAltitudeVisualization.Location = new System.Drawing.Point(429, 111);
            this.pbAltitudeVisualization.Name = "pbAltitudeVisualization";
            this.pbAltitudeVisualization.Size = new System.Drawing.Size(60, 300);
            this.pbAltitudeVisualization.TabIndex = 23;
            this.pbAltitudeVisualization.TabStop = false;
            this.pbAltitudeVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAltitudeVisualization_Paint);
            // 
            // pbHeadingVisualization
            // 
            this.pbHeadingVisualization.Location = new System.Drawing.Point(123, 417);
            this.pbHeadingVisualization.Name = "pbHeadingVisualization";
            this.pbHeadingVisualization.Size = new System.Drawing.Size(300, 60);
            this.pbHeadingVisualization.TabIndex = 24;
            this.pbHeadingVisualization.TabStop = false;
            this.pbHeadingVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.pbHeadingVisualization_Paint);
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.BackColor = System.Drawing.Color.Black;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.Lime;
            this.lblLatitude.Location = new System.Drawing.Point(543, 111);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(89, 26);
            this.lblLatitude.TabIndex = 25;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.BackColor = System.Drawing.Color.Black;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.Lime;
            this.lblLongitude.Location = new System.Drawing.Point(543, 137);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(107, 26);
            this.lblLongitude.TabIndex = 26;
            this.lblLongitude.Text = "Longitude";
            // 
            // SmartPilot2020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 555);
            this.Controls.Add(this.lblLongitude);
            this.Controls.Add(this.lblLatitude);
            this.Controls.Add(this.pbHeadingVisualization);
            this.Controls.Add(this.pbAltitudeVisualization);
            this.Controls.Add(this.pbSpeedVisualization);
            this.Controls.Add(this.pbMonitorVisualization);
            this.Controls.Add(this.pbPitchRollVisualization);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.clbLog);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.tsTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmartPilot2020";
            this.Text = "SmartPilot2020";
            this.Load += new System.EventHandler(this.RCAutopilot_Load);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPitchRollVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitorVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingVisualization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.CheckedListBox clbLog;
        private System.Windows.Forms.ToolStripButton btnShutdown;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.ToolStripButton btnConnectComPort;
        private System.Windows.Forms.ToolStripButton btnDisconnectComPort;
        private System.Windows.Forms.ToolStripStatusLabel lblTrafficMonnitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblJoystick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblComPort;
        private System.Windows.Forms.PictureBox pbPitchRollVisualization;
        private System.Windows.Forms.PictureBox pbMonitorVisualization;
        private System.Windows.Forms.PictureBox pbSpeedVisualization;
        private System.Windows.Forms.PictureBox pbAltitudeVisualization;
        private System.Windows.Forms.PictureBox pbHeadingVisualization;
        private System.Windows.Forms.ToolStripButton btnStopOutgoingPackets;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblPacketOutput;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
    }
}

