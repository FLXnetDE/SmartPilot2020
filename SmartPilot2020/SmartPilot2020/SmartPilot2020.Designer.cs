namespace SmartPilot2020
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblJoystick = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblComPort = new System.Windows.Forms.ToolStripLabel();
            this.lblPacketOutput = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.lblTrafficMonnitor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbAngle = new System.Windows.Forms.TrackBar();
            this.gbStationaryEnvData = new System.Windows.Forms.GroupBox();
            this.lblStationaryPressure = new System.Windows.Forms.Label();
            this.lblStationaryHumidity = new System.Windows.Forms.Label();
            this.lblStationaryTemperature = new System.Windows.Forms.Label();
            this.gbAircraftTelemetryData = new System.Windows.Forms.GroupBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblCurrentAltitude = new System.Windows.Forms.Label();
            this.lblCurrentSpeed = new System.Windows.Forms.Label();
            this.lblCurrentHeading = new System.Windows.Forms.Label();
            this.lblCurrentRoll = new System.Windows.Forms.Label();
            this.lblCurrentPitch = new System.Windows.Forms.Label();
            this.gbAircraftEnvironmentalData = new System.Windows.Forms.GroupBox();
            this.lblAircraftPressure = new System.Windows.Forms.Label();
            this.lblAircraftHumidity = new System.Windows.Forms.Label();
            this.lblAircraftTemperature = new System.Windows.Forms.Label();
            this.pbStationaryWindDirection = new System.Windows.Forms.PictureBox();
            this.pbGaugeTest = new System.Windows.Forms.PictureBox();
            this.pbHeadingVisualization = new System.Windows.Forms.PictureBox();
            this.pbAltitudeVisualization = new System.Windows.Forms.PictureBox();
            this.pbSpeedVisualization = new System.Windows.Forms.PictureBox();
            this.pbMonitorVisualization = new System.Windows.Forms.PictureBox();
            this.pbPitchRollVisualization = new System.Windows.Forms.PictureBox();
            this.btnShutdown = new System.Windows.Forms.ToolStripButton();
            this.btnConnectComPort = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnectComPort = new System.Windows.Forms.ToolStripButton();
            this.btnStopOutgoingPackets = new System.Windows.Forms.ToolStripButton();
            this.lblCurrentWindInformation = new System.Windows.Forms.Label();
            this.pbNavigation = new System.Windows.Forms.PictureBox();
            this.tsTop.SuspendLayout();
            this.ssBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).BeginInit();
            this.gbStationaryEnvData.SuspendLayout();
            this.gbAircraftTelemetryData.SuspendLayout();
            this.gbAircraftEnvironmentalData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStationaryWindDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGaugeTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitorVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPitchRollVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNavigation)).BeginInit();
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
            this.tsTop.Size = new System.Drawing.Size(1270, 25);
            this.tsTop.TabIndex = 13;
            this.tsTop.Text = "Top";
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrafficMonnitor});
            this.ssBottom.Location = new System.Drawing.Point(0, 747);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(1270, 22);
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
            // tbAngle
            // 
            this.tbAngle.LargeChange = 1;
            this.tbAngle.Location = new System.Drawing.Point(930, 653);
            this.tbAngle.Maximum = 360;
            this.tbAngle.Name = "tbAngle";
            this.tbAngle.Size = new System.Drawing.Size(120, 45);
            this.tbAngle.TabIndex = 28;
            this.tbAngle.Scroll += new System.EventHandler(this.tbAngle_Scroll);
            // 
            // gbStationaryEnvData
            // 
            this.gbStationaryEnvData.Controls.Add(this.lblCurrentWindInformation);
            this.gbStationaryEnvData.Controls.Add(this.pbStationaryWindDirection);
            this.gbStationaryEnvData.Controls.Add(this.lblStationaryPressure);
            this.gbStationaryEnvData.Controls.Add(this.lblStationaryHumidity);
            this.gbStationaryEnvData.Controls.Add(this.lblStationaryTemperature);
            this.gbStationaryEnvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStationaryEnvData.Location = new System.Drawing.Point(639, 496);
            this.gbStationaryEnvData.Name = "gbStationaryEnvData";
            this.gbStationaryEnvData.Size = new System.Drawing.Size(285, 233);
            this.gbStationaryEnvData.TabIndex = 29;
            this.gbStationaryEnvData.TabStop = false;
            this.gbStationaryEnvData.Text = "Stationary environmental data";
            // 
            // lblStationaryPressure
            // 
            this.lblStationaryPressure.AutoSize = true;
            this.lblStationaryPressure.BackColor = System.Drawing.Color.Black;
            this.lblStationaryPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationaryPressure.ForeColor = System.Drawing.Color.Lime;
            this.lblStationaryPressure.Location = new System.Drawing.Point(6, 74);
            this.lblStationaryPressure.Name = "lblStationaryPressure";
            this.lblStationaryPressure.Size = new System.Drawing.Size(99, 26);
            this.lblStationaryPressure.TabIndex = 38;
            this.lblStationaryPressure.Text = "Pressure";
            // 
            // lblStationaryHumidity
            // 
            this.lblStationaryHumidity.AutoSize = true;
            this.lblStationaryHumidity.BackColor = System.Drawing.Color.Black;
            this.lblStationaryHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationaryHumidity.ForeColor = System.Drawing.Color.Lime;
            this.lblStationaryHumidity.Location = new System.Drawing.Point(6, 48);
            this.lblStationaryHumidity.Name = "lblStationaryHumidity";
            this.lblStationaryHumidity.Size = new System.Drawing.Size(98, 26);
            this.lblStationaryHumidity.TabIndex = 37;
            this.lblStationaryHumidity.Text = "Humidity";
            // 
            // lblStationaryTemperature
            // 
            this.lblStationaryTemperature.AutoSize = true;
            this.lblStationaryTemperature.BackColor = System.Drawing.Color.Black;
            this.lblStationaryTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationaryTemperature.ForeColor = System.Drawing.Color.Lime;
            this.lblStationaryTemperature.Location = new System.Drawing.Point(6, 22);
            this.lblStationaryTemperature.Name = "lblStationaryTemperature";
            this.lblStationaryTemperature.Size = new System.Drawing.Size(135, 26);
            this.lblStationaryTemperature.TabIndex = 36;
            this.lblStationaryTemperature.Text = "Temperature";
            // 
            // gbAircraftTelemetryData
            // 
            this.gbAircraftTelemetryData.Controls.Add(this.lblLatitude);
            this.gbAircraftTelemetryData.Controls.Add(this.lblLongitude);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentAltitude);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentSpeed);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentHeading);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentRoll);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentPitch);
            this.gbAircraftTelemetryData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAircraftTelemetryData.Location = new System.Drawing.Point(57, 496);
            this.gbAircraftTelemetryData.Name = "gbAircraftTelemetryData";
            this.gbAircraftTelemetryData.Size = new System.Drawing.Size(285, 233);
            this.gbAircraftTelemetryData.TabIndex = 30;
            this.gbAircraftTelemetryData.TabStop = false;
            this.gbAircraftTelemetryData.Text = "Aircraft telemetry data";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.BackColor = System.Drawing.Color.Black;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.Lime;
            this.lblLatitude.Location = new System.Drawing.Point(6, 172);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(89, 26);
            this.lblLatitude.TabIndex = 32;
            this.lblLatitude.Text = "Latitude";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.BackColor = System.Drawing.Color.Black;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.Lime;
            this.lblLongitude.Location = new System.Drawing.Point(6, 198);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(107, 26);
            this.lblLongitude.TabIndex = 33;
            this.lblLongitude.Text = "Longitude";
            // 
            // lblCurrentAltitude
            // 
            this.lblCurrentAltitude.AutoSize = true;
            this.lblCurrentAltitude.BackColor = System.Drawing.Color.Black;
            this.lblCurrentAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAltitude.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentAltitude.Location = new System.Drawing.Point(6, 123);
            this.lblCurrentAltitude.Name = "lblCurrentAltitude";
            this.lblCurrentAltitude.Size = new System.Drawing.Size(85, 26);
            this.lblCurrentAltitude.TabIndex = 31;
            this.lblCurrentAltitude.Text = "Altitude";
            // 
            // lblCurrentSpeed
            // 
            this.lblCurrentSpeed.AutoSize = true;
            this.lblCurrentSpeed.BackColor = System.Drawing.Color.Black;
            this.lblCurrentSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSpeed.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentSpeed.Location = new System.Drawing.Point(6, 97);
            this.lblCurrentSpeed.Name = "lblCurrentSpeed";
            this.lblCurrentSpeed.Size = new System.Drawing.Size(75, 26);
            this.lblCurrentSpeed.TabIndex = 30;
            this.lblCurrentSpeed.Text = "Speed";
            // 
            // lblCurrentHeading
            // 
            this.lblCurrentHeading.AutoSize = true;
            this.lblCurrentHeading.BackColor = System.Drawing.Color.Black;
            this.lblCurrentHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHeading.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentHeading.Location = new System.Drawing.Point(6, 71);
            this.lblCurrentHeading.Name = "lblCurrentHeading";
            this.lblCurrentHeading.Size = new System.Drawing.Size(93, 26);
            this.lblCurrentHeading.TabIndex = 29;
            this.lblCurrentHeading.Text = "Heading";
            // 
            // lblCurrentRoll
            // 
            this.lblCurrentRoll.AutoSize = true;
            this.lblCurrentRoll.BackColor = System.Drawing.Color.Black;
            this.lblCurrentRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentRoll.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentRoll.Location = new System.Drawing.Point(6, 45);
            this.lblCurrentRoll.Name = "lblCurrentRoll";
            this.lblCurrentRoll.Size = new System.Drawing.Size(50, 26);
            this.lblCurrentRoll.TabIndex = 28;
            this.lblCurrentRoll.Text = "Roll";
            // 
            // lblCurrentPitch
            // 
            this.lblCurrentPitch.AutoSize = true;
            this.lblCurrentPitch.BackColor = System.Drawing.Color.Black;
            this.lblCurrentPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPitch.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentPitch.Location = new System.Drawing.Point(6, 19);
            this.lblCurrentPitch.Name = "lblCurrentPitch";
            this.lblCurrentPitch.Size = new System.Drawing.Size(61, 26);
            this.lblCurrentPitch.TabIndex = 27;
            this.lblCurrentPitch.Text = "Pitch";
            // 
            // gbAircraftEnvironmentalData
            // 
            this.gbAircraftEnvironmentalData.Controls.Add(this.lblAircraftPressure);
            this.gbAircraftEnvironmentalData.Controls.Add(this.lblAircraftHumidity);
            this.gbAircraftEnvironmentalData.Controls.Add(this.lblAircraftTemperature);
            this.gbAircraftEnvironmentalData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAircraftEnvironmentalData.Location = new System.Drawing.Point(348, 496);
            this.gbAircraftEnvironmentalData.Name = "gbAircraftEnvironmentalData";
            this.gbAircraftEnvironmentalData.Size = new System.Drawing.Size(285, 233);
            this.gbAircraftEnvironmentalData.TabIndex = 31;
            this.gbAircraftEnvironmentalData.TabStop = false;
            this.gbAircraftEnvironmentalData.Text = "Aircraft environmental data";
            // 
            // lblAircraftPressure
            // 
            this.lblAircraftPressure.AutoSize = true;
            this.lblAircraftPressure.BackColor = System.Drawing.Color.Black;
            this.lblAircraftPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraftPressure.ForeColor = System.Drawing.Color.Lime;
            this.lblAircraftPressure.Location = new System.Drawing.Point(6, 71);
            this.lblAircraftPressure.Name = "lblAircraftPressure";
            this.lblAircraftPressure.Size = new System.Drawing.Size(99, 26);
            this.lblAircraftPressure.TabIndex = 35;
            this.lblAircraftPressure.Text = "Pressure";
            // 
            // lblAircraftHumidity
            // 
            this.lblAircraftHumidity.AutoSize = true;
            this.lblAircraftHumidity.BackColor = System.Drawing.Color.Black;
            this.lblAircraftHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraftHumidity.ForeColor = System.Drawing.Color.Lime;
            this.lblAircraftHumidity.Location = new System.Drawing.Point(6, 45);
            this.lblAircraftHumidity.Name = "lblAircraftHumidity";
            this.lblAircraftHumidity.Size = new System.Drawing.Size(98, 26);
            this.lblAircraftHumidity.TabIndex = 34;
            this.lblAircraftHumidity.Text = "Humidity";
            // 
            // lblAircraftTemperature
            // 
            this.lblAircraftTemperature.AutoSize = true;
            this.lblAircraftTemperature.BackColor = System.Drawing.Color.Black;
            this.lblAircraftTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraftTemperature.ForeColor = System.Drawing.Color.Lime;
            this.lblAircraftTemperature.Location = new System.Drawing.Point(6, 19);
            this.lblAircraftTemperature.Name = "lblAircraftTemperature";
            this.lblAircraftTemperature.Size = new System.Drawing.Size(135, 26);
            this.lblAircraftTemperature.TabIndex = 33;
            this.lblAircraftTemperature.Text = "Temperature";
            // 
            // pbStationaryWindDirection
            // 
            this.pbStationaryWindDirection.Location = new System.Drawing.Point(6, 120);
            this.pbStationaryWindDirection.Name = "pbStationaryWindDirection";
            this.pbStationaryWindDirection.Size = new System.Drawing.Size(50, 50);
            this.pbStationaryWindDirection.TabIndex = 39;
            this.pbStationaryWindDirection.TabStop = false;
            this.pbStationaryWindDirection.Paint += new System.Windows.Forms.PaintEventHandler(this.pbStationaryWindDirection_Paint);
            // 
            // pbGaugeTest
            // 
            this.pbGaugeTest.Location = new System.Drawing.Point(930, 496);
            this.pbGaugeTest.Name = "pbGaugeTest";
            this.pbGaugeTest.Size = new System.Drawing.Size(120, 150);
            this.pbGaugeTest.TabIndex = 27;
            this.pbGaugeTest.TabStop = false;
            this.pbGaugeTest.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGaugeTest_Paint);
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
            // pbAltitudeVisualization
            // 
            this.pbAltitudeVisualization.Location = new System.Drawing.Point(429, 111);
            this.pbAltitudeVisualization.Name = "pbAltitudeVisualization";
            this.pbAltitudeVisualization.Size = new System.Drawing.Size(60, 300);
            this.pbAltitudeVisualization.TabIndex = 23;
            this.pbAltitudeVisualization.TabStop = false;
            this.pbAltitudeVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAltitudeVisualization_Paint);
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
            // pbMonitorVisualization
            // 
            this.pbMonitorVisualization.Location = new System.Drawing.Point(57, 45);
            this.pbMonitorVisualization.Name = "pbMonitorVisualization";
            this.pbMonitorVisualization.Size = new System.Drawing.Size(432, 60);
            this.pbMonitorVisualization.TabIndex = 21;
            this.pbMonitorVisualization.TabStop = false;
            this.pbMonitorVisualization.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMonitorVisualization_Paint);
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
            // btnStopOutgoingPackets
            // 
            this.btnStopOutgoingPackets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopOutgoingPackets.Image = ((System.Drawing.Image)(resources.GetObject("btnStopOutgoingPackets.Image")));
            this.btnStopOutgoingPackets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopOutgoingPackets.Name = "btnStopOutgoingPackets";
            this.btnStopOutgoingPackets.Size = new System.Drawing.Size(23, 22);
            this.btnStopOutgoingPackets.Text = "Toggle outgoing packet state";
            this.btnStopOutgoingPackets.Click += new System.EventHandler(this.btnStopOutgoingPackets_Click);
            // 
            // lblCurrentWindInformation
            // 
            this.lblCurrentWindInformation.AutoSize = true;
            this.lblCurrentWindInformation.BackColor = System.Drawing.Color.Black;
            this.lblCurrentWindInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentWindInformation.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentWindInformation.Location = new System.Drawing.Point(6, 173);
            this.lblCurrentWindInformation.Name = "lblCurrentWindInformation";
            this.lblCurrentWindInformation.Size = new System.Drawing.Size(265, 26);
            this.lblCurrentWindInformation.TabIndex = 40;
            this.lblCurrentWindInformation.Text = "lblCurrentWindInformation";
            // 
            // pbNavigation
            // 
            this.pbNavigation.Location = new System.Drawing.Point(618, 45);
            this.pbNavigation.Name = "pbNavigation";
            this.pbNavigation.Size = new System.Drawing.Size(432, 432);
            this.pbNavigation.TabIndex = 32;
            this.pbNavigation.TabStop = false;
            this.pbNavigation.Paint += new System.Windows.Forms.PaintEventHandler(this.pbNavigation_Paint);
            // 
            // SmartPilot2020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 769);
            this.Controls.Add(this.pbNavigation);
            this.Controls.Add(this.gbAircraftEnvironmentalData);
            this.Controls.Add(this.gbAircraftTelemetryData);
            this.Controls.Add(this.gbStationaryEnvData);
            this.Controls.Add(this.tbAngle);
            this.Controls.Add(this.pbGaugeTest);
            this.Controls.Add(this.pbHeadingVisualization);
            this.Controls.Add(this.pbAltitudeVisualization);
            this.Controls.Add(this.pbSpeedVisualization);
            this.Controls.Add(this.pbMonitorVisualization);
            this.Controls.Add(this.pbPitchRollVisualization);
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
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).EndInit();
            this.gbStationaryEnvData.ResumeLayout(false);
            this.gbStationaryEnvData.PerformLayout();
            this.gbAircraftTelemetryData.ResumeLayout(false);
            this.gbAircraftTelemetryData.PerformLayout();
            this.gbAircraftEnvironmentalData.ResumeLayout(false);
            this.gbAircraftEnvironmentalData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStationaryWindDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGaugeTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitorVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPitchRollVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNavigation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStripButton btnShutdown;
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
        private System.Windows.Forms.PictureBox pbGaugeTest;
        private System.Windows.Forms.TrackBar tbAngle;
        private System.Windows.Forms.GroupBox gbStationaryEnvData;
        private System.Windows.Forms.GroupBox gbAircraftTelemetryData;
        private System.Windows.Forms.GroupBox gbAircraftEnvironmentalData;
        private System.Windows.Forms.Label lblCurrentPitch;
        private System.Windows.Forms.Label lblCurrentAltitude;
        private System.Windows.Forms.Label lblCurrentSpeed;
        private System.Windows.Forms.Label lblCurrentHeading;
        private System.Windows.Forms.Label lblCurrentRoll;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblAircraftTemperature;
        private System.Windows.Forms.Label lblAircraftPressure;
        private System.Windows.Forms.Label lblAircraftHumidity;
        private System.Windows.Forms.Label lblStationaryPressure;
        private System.Windows.Forms.Label lblStationaryHumidity;
        private System.Windows.Forms.Label lblStationaryTemperature;
        private System.Windows.Forms.PictureBox pbStationaryWindDirection;
        private System.Windows.Forms.Label lblCurrentWindInformation;
        private System.Windows.Forms.PictureBox pbNavigation;
    }
}

