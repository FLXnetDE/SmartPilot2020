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
            this.lblCarrierTest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbAngle = new System.Windows.Forms.TrackBar();
            this.lblCurrentPitch = new System.Windows.Forms.Label();
            this.lblCurrentRoll = new System.Windows.Forms.Label();
            this.lblCurrentHeading = new System.Windows.Forms.Label();
            this.lblCurrentSpeed = new System.Windows.Forms.Label();
            this.lblCurrentAltitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.gbAircraftTelemetryData = new System.Windows.Forms.GroupBox();
            this.lblAircraftTemperature = new System.Windows.Forms.Label();
            this.lblAircraftHumidity = new System.Windows.Forms.Label();
            this.lblAircraftPressure = new System.Windows.Forms.Label();
            this.gbAircraftEnvironmentalData = new System.Windows.Forms.GroupBox();
            this.gbStationaryEnvData = new System.Windows.Forms.GroupBox();
            this.lblCurrentWindInformation = new System.Windows.Forms.Label();
            this.pbStationaryWindDirection = new System.Windows.Forms.PictureBox();
            this.lblStationaryPressure = new System.Windows.Forms.Label();
            this.lblStationaryHumidity = new System.Windows.Forms.Label();
            this.lblStationaryTemperature = new System.Windows.Forms.Label();
            this.pbAltitudeWheel = new System.Windows.Forms.PictureBox();
            this.pbSpeedWheel = new System.Windows.Forms.PictureBox();
            this.pbAutoThrustToggle = new System.Windows.Forms.PictureBox();
            this.pbHeadingWheel = new System.Windows.Forms.PictureBox();
            this.pbAutoPilotToggle = new System.Windows.Forms.PictureBox();
            this.pbFlightEnvelopeToggle = new System.Windows.Forms.PictureBox();
            this.pbNavigation = new System.Windows.Forms.PictureBox();
            this.pbGaugeTest = new System.Windows.Forms.PictureBox();
            this.pbHeadingVisualization = new System.Windows.Forms.PictureBox();
            this.pbAltitudeVisualization = new System.Windows.Forms.PictureBox();
            this.pbSpeedVisualization = new System.Windows.Forms.PictureBox();
            this.pbMonitorVisualization = new System.Windows.Forms.PictureBox();
            this.pbPitchRollVisualization = new System.Windows.Forms.PictureBox();
            this.gbFCU = new System.Windows.Forms.GroupBox();
            this.pbSelectorDisplay = new System.Windows.Forms.PictureBox();
            this.btnAircraftMode = new System.Windows.Forms.Button();
            this.btnAltitudeReference = new System.Windows.Forms.Button();
            this.nudBaroRef = new System.Windows.Forms.NumericUpDown();
            this.txtbTest = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.pbMonitoring = new System.Windows.Forms.PictureBox();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.tsTop.SuspendLayout();
            this.ssBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).BeginInit();
            this.gbAircraftTelemetryData.SuspendLayout();
            this.gbAircraftEnvironmentalData.SuspendLayout();
            this.gbStationaryEnvData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStationaryWindDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoThrustToggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoPilotToggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlightEnvelopeToggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNavigation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGaugeTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitorVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPitchRollVisualization)).BeginInit();
            this.gbFCU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectorDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaroRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitoring)).BeginInit();
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
            this.tsTop.Size = new System.Drawing.Size(1812, 25);
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
            this.lblJoystick.ForeColor = System.Drawing.Color.Black;
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
            this.lblComPort.ForeColor = System.Drawing.Color.Black;
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(68, 22);
            this.lblComPort.Text = "lblComPort";
            this.lblComPort.ToolTipText = "SerialPort connection";
            // 
            // lblPacketOutput
            // 
            this.lblPacketOutput.ForeColor = System.Drawing.Color.Black;
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
            this.btnStopOutgoingPackets.Text = "Toggle outgoing packet state";
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
            this.lblTrafficMonnitor,
            this.lblCarrierTest});
            this.ssBottom.Location = new System.Drawing.Point(0, 887);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(1812, 22);
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
            // lblCarrierTest
            // 
            this.lblCarrierTest.ForeColor = System.Drawing.Color.Black;
            this.lblCarrierTest.Name = "lblCarrierTest";
            this.lblCarrierTest.Size = new System.Drawing.Size(145, 17);
            this.lblCarrierTest.Text = "lblRadioSignalInformation";
            // 
            // tbAngle
            // 
            this.tbAngle.LargeChange = 1;
            this.tbAngle.Location = new System.Drawing.Point(1046, 795);
            this.tbAngle.Maximum = 360;
            this.tbAngle.Name = "tbAngle";
            this.tbAngle.Size = new System.Drawing.Size(120, 45);
            this.tbAngle.TabIndex = 28;
            this.tbAngle.Scroll += new System.EventHandler(this.tbAngle_Scroll);
            // 
            // lblCurrentPitch
            // 
            this.lblCurrentPitch.AutoSize = true;
            this.lblCurrentPitch.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPitch.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCurrentPitch.Location = new System.Drawing.Point(6, 19);
            this.lblCurrentPitch.Name = "lblCurrentPitch";
            this.lblCurrentPitch.Size = new System.Drawing.Size(61, 26);
            this.lblCurrentPitch.TabIndex = 27;
            this.lblCurrentPitch.Text = "Pitch";
            // 
            // lblCurrentRoll
            // 
            this.lblCurrentRoll.AutoSize = true;
            this.lblCurrentRoll.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentRoll.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCurrentRoll.Location = new System.Drawing.Point(6, 45);
            this.lblCurrentRoll.Name = "lblCurrentRoll";
            this.lblCurrentRoll.Size = new System.Drawing.Size(50, 26);
            this.lblCurrentRoll.TabIndex = 28;
            this.lblCurrentRoll.Text = "Roll";
            // 
            // lblCurrentHeading
            // 
            this.lblCurrentHeading.AutoSize = true;
            this.lblCurrentHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHeading.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCurrentHeading.Location = new System.Drawing.Point(6, 71);
            this.lblCurrentHeading.Name = "lblCurrentHeading";
            this.lblCurrentHeading.Size = new System.Drawing.Size(93, 26);
            this.lblCurrentHeading.TabIndex = 29;
            this.lblCurrentHeading.Text = "Heading";
            // 
            // lblCurrentSpeed
            // 
            this.lblCurrentSpeed.AutoSize = true;
            this.lblCurrentSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSpeed.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCurrentSpeed.Location = new System.Drawing.Point(6, 97);
            this.lblCurrentSpeed.Name = "lblCurrentSpeed";
            this.lblCurrentSpeed.Size = new System.Drawing.Size(75, 26);
            this.lblCurrentSpeed.TabIndex = 30;
            this.lblCurrentSpeed.Text = "Speed";
            // 
            // lblCurrentAltitude
            // 
            this.lblCurrentAltitude.AutoSize = true;
            this.lblCurrentAltitude.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAltitude.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCurrentAltitude.Location = new System.Drawing.Point(6, 123);
            this.lblCurrentAltitude.Name = "lblCurrentAltitude";
            this.lblCurrentAltitude.Size = new System.Drawing.Size(85, 26);
            this.lblCurrentAltitude.TabIndex = 31;
            this.lblCurrentAltitude.Text = "Altitude";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.BackColor = System.Drawing.Color.Transparent;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblLongitude.Location = new System.Drawing.Point(6, 198);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(107, 26);
            this.lblLongitude.TabIndex = 33;
            this.lblLongitude.Text = "Longitude";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.BackColor = System.Drawing.Color.Transparent;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblLatitude.Location = new System.Drawing.Point(6, 172);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(89, 26);
            this.lblLatitude.TabIndex = 32;
            this.lblLatitude.Text = "Latitude";
            // 
            // gbAircraftTelemetryData
            // 
            this.gbAircraftTelemetryData.BackColor = System.Drawing.Color.Black;
            this.gbAircraftTelemetryData.Controls.Add(this.lblLatitude);
            this.gbAircraftTelemetryData.Controls.Add(this.lblLongitude);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentAltitude);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentSpeed);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentHeading);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentRoll);
            this.gbAircraftTelemetryData.Controls.Add(this.lblCurrentPitch);
            this.gbAircraftTelemetryData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAircraftTelemetryData.ForeColor = System.Drawing.Color.White;
            this.gbAircraftTelemetryData.Location = new System.Drawing.Point(57, 638);
            this.gbAircraftTelemetryData.Name = "gbAircraftTelemetryData";
            this.gbAircraftTelemetryData.Size = new System.Drawing.Size(285, 233);
            this.gbAircraftTelemetryData.TabIndex = 30;
            this.gbAircraftTelemetryData.TabStop = false;
            this.gbAircraftTelemetryData.Text = "Aircraft telemetry data";
            // 
            // lblAircraftTemperature
            // 
            this.lblAircraftTemperature.AutoSize = true;
            this.lblAircraftTemperature.BackColor = System.Drawing.Color.Transparent;
            this.lblAircraftTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraftTemperature.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblAircraftTemperature.Location = new System.Drawing.Point(6, 19);
            this.lblAircraftTemperature.Name = "lblAircraftTemperature";
            this.lblAircraftTemperature.Size = new System.Drawing.Size(135, 26);
            this.lblAircraftTemperature.TabIndex = 33;
            this.lblAircraftTemperature.Text = "Temperature";
            // 
            // lblAircraftHumidity
            // 
            this.lblAircraftHumidity.AutoSize = true;
            this.lblAircraftHumidity.BackColor = System.Drawing.Color.Transparent;
            this.lblAircraftHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraftHumidity.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblAircraftHumidity.Location = new System.Drawing.Point(6, 45);
            this.lblAircraftHumidity.Name = "lblAircraftHumidity";
            this.lblAircraftHumidity.Size = new System.Drawing.Size(98, 26);
            this.lblAircraftHumidity.TabIndex = 34;
            this.lblAircraftHumidity.Text = "Humidity";
            // 
            // lblAircraftPressure
            // 
            this.lblAircraftPressure.AutoSize = true;
            this.lblAircraftPressure.BackColor = System.Drawing.Color.Transparent;
            this.lblAircraftPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraftPressure.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblAircraftPressure.Location = new System.Drawing.Point(6, 71);
            this.lblAircraftPressure.Name = "lblAircraftPressure";
            this.lblAircraftPressure.Size = new System.Drawing.Size(99, 26);
            this.lblAircraftPressure.TabIndex = 35;
            this.lblAircraftPressure.Text = "Pressure";
            // 
            // gbAircraftEnvironmentalData
            // 
            this.gbAircraftEnvironmentalData.BackColor = System.Drawing.Color.Black;
            this.gbAircraftEnvironmentalData.Controls.Add(this.lblAircraftPressure);
            this.gbAircraftEnvironmentalData.Controls.Add(this.lblAircraftHumidity);
            this.gbAircraftEnvironmentalData.Controls.Add(this.lblAircraftTemperature);
            this.gbAircraftEnvironmentalData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAircraftEnvironmentalData.ForeColor = System.Drawing.Color.White;
            this.gbAircraftEnvironmentalData.Location = new System.Drawing.Point(348, 638);
            this.gbAircraftEnvironmentalData.Name = "gbAircraftEnvironmentalData";
            this.gbAircraftEnvironmentalData.Size = new System.Drawing.Size(285, 233);
            this.gbAircraftEnvironmentalData.TabIndex = 31;
            this.gbAircraftEnvironmentalData.TabStop = false;
            this.gbAircraftEnvironmentalData.Text = "Aircraft environmental data";
            // 
            // gbStationaryEnvData
            // 
            this.gbStationaryEnvData.BackColor = System.Drawing.Color.Black;
            this.gbStationaryEnvData.Controls.Add(this.lblCurrentWindInformation);
            this.gbStationaryEnvData.Controls.Add(this.pbStationaryWindDirection);
            this.gbStationaryEnvData.Controls.Add(this.lblStationaryPressure);
            this.gbStationaryEnvData.Controls.Add(this.lblStationaryHumidity);
            this.gbStationaryEnvData.Controls.Add(this.lblStationaryTemperature);
            this.gbStationaryEnvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStationaryEnvData.ForeColor = System.Drawing.Color.White;
            this.gbStationaryEnvData.Location = new System.Drawing.Point(639, 638);
            this.gbStationaryEnvData.Name = "gbStationaryEnvData";
            this.gbStationaryEnvData.Size = new System.Drawing.Size(285, 233);
            this.gbStationaryEnvData.TabIndex = 29;
            this.gbStationaryEnvData.TabStop = false;
            this.gbStationaryEnvData.Text = "Stationary environmental data";
            // 
            // lblCurrentWindInformation
            // 
            this.lblCurrentWindInformation.AutoSize = true;
            this.lblCurrentWindInformation.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentWindInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentWindInformation.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCurrentWindInformation.Location = new System.Drawing.Point(6, 173);
            this.lblCurrentWindInformation.Name = "lblCurrentWindInformation";
            this.lblCurrentWindInformation.Size = new System.Drawing.Size(265, 26);
            this.lblCurrentWindInformation.TabIndex = 40;
            this.lblCurrentWindInformation.Text = "lblCurrentWindInformation";
            // 
            // pbStationaryWindDirection
            // 
            this.pbStationaryWindDirection.Location = new System.Drawing.Point(7, 120);
            this.pbStationaryWindDirection.Name = "pbStationaryWindDirection";
            this.pbStationaryWindDirection.Size = new System.Drawing.Size(50, 50);
            this.pbStationaryWindDirection.TabIndex = 39;
            this.pbStationaryWindDirection.TabStop = false;
            this.pbStationaryWindDirection.Paint += new System.Windows.Forms.PaintEventHandler(this.pbStationaryWindDirection_Paint);
            // 
            // lblStationaryPressure
            // 
            this.lblStationaryPressure.AutoSize = true;
            this.lblStationaryPressure.BackColor = System.Drawing.Color.Transparent;
            this.lblStationaryPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationaryPressure.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblStationaryPressure.Location = new System.Drawing.Point(6, 74);
            this.lblStationaryPressure.Name = "lblStationaryPressure";
            this.lblStationaryPressure.Size = new System.Drawing.Size(99, 26);
            this.lblStationaryPressure.TabIndex = 38;
            this.lblStationaryPressure.Text = "Pressure";
            // 
            // lblStationaryHumidity
            // 
            this.lblStationaryHumidity.AutoSize = true;
            this.lblStationaryHumidity.BackColor = System.Drawing.Color.Transparent;
            this.lblStationaryHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationaryHumidity.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblStationaryHumidity.Location = new System.Drawing.Point(6, 48);
            this.lblStationaryHumidity.Name = "lblStationaryHumidity";
            this.lblStationaryHumidity.Size = new System.Drawing.Size(98, 26);
            this.lblStationaryHumidity.TabIndex = 37;
            this.lblStationaryHumidity.Text = "Humidity";
            // 
            // lblStationaryTemperature
            // 
            this.lblStationaryTemperature.AutoSize = true;
            this.lblStationaryTemperature.BackColor = System.Drawing.Color.Transparent;
            this.lblStationaryTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationaryTemperature.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblStationaryTemperature.Location = new System.Drawing.Point(6, 22);
            this.lblStationaryTemperature.Name = "lblStationaryTemperature";
            this.lblStationaryTemperature.Size = new System.Drawing.Size(135, 26);
            this.lblStationaryTemperature.TabIndex = 36;
            this.lblStationaryTemperature.Text = "Temperature";
            // 
            // pbAltitudeWheel
            // 
            this.pbAltitudeWheel.BackColor = System.Drawing.Color.SteelBlue;
            this.pbAltitudeWheel.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbAltitudeWheel.InitialImage")));
            this.pbAltitudeWheel.Location = new System.Drawing.Point(494, 78);
            this.pbAltitudeWheel.Name = "pbAltitudeWheel";
            this.pbAltitudeWheel.Size = new System.Drawing.Size(50, 50);
            this.pbAltitudeWheel.TabIndex = 38;
            this.pbAltitudeWheel.TabStop = false;
            this.pbAltitudeWheel.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAltitudeWheel_Paint);
            // 
            // pbSpeedWheel
            // 
            this.pbSpeedWheel.BackColor = System.Drawing.Color.SteelBlue;
            this.pbSpeedWheel.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbSpeedWheel.InitialImage")));
            this.pbSpeedWheel.Location = new System.Drawing.Point(270, 78);
            this.pbSpeedWheel.Name = "pbSpeedWheel";
            this.pbSpeedWheel.Size = new System.Drawing.Size(50, 50);
            this.pbSpeedWheel.TabIndex = 37;
            this.pbSpeedWheel.TabStop = false;
            this.pbSpeedWheel.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSpeedWheel_Paint);
            // 
            // pbAutoThrustToggle
            // 
            this.pbAutoThrustToggle.Location = new System.Drawing.Point(119, 78);
            this.pbAutoThrustToggle.Name = "pbAutoThrustToggle";
            this.pbAutoThrustToggle.Size = new System.Drawing.Size(50, 50);
            this.pbAutoThrustToggle.TabIndex = 36;
            this.pbAutoThrustToggle.TabStop = false;
            this.pbAutoThrustToggle.Click += new System.EventHandler(this.pbAutoThrustToggle_Click);
            this.pbAutoThrustToggle.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAutoThrustToggle_Paint);
            // 
            // pbHeadingWheel
            // 
            this.pbHeadingWheel.BackColor = System.Drawing.Color.SteelBlue;
            this.pbHeadingWheel.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbHeadingWheel.InitialImage")));
            this.pbHeadingWheel.Location = new System.Drawing.Point(382, 78);
            this.pbHeadingWheel.Name = "pbHeadingWheel";
            this.pbHeadingWheel.Size = new System.Drawing.Size(50, 50);
            this.pbHeadingWheel.TabIndex = 35;
            this.pbHeadingWheel.TabStop = false;
            this.pbHeadingWheel.Paint += new System.Windows.Forms.PaintEventHandler(this.pbHeadingWheel_Paint);
            // 
            // pbAutoPilotToggle
            // 
            this.pbAutoPilotToggle.Location = new System.Drawing.Point(63, 78);
            this.pbAutoPilotToggle.Name = "pbAutoPilotToggle";
            this.pbAutoPilotToggle.Size = new System.Drawing.Size(50, 50);
            this.pbAutoPilotToggle.TabIndex = 34;
            this.pbAutoPilotToggle.TabStop = false;
            this.pbAutoPilotToggle.Click += new System.EventHandler(this.pbAutoPilotToggle_Click);
            this.pbAutoPilotToggle.Paint += new System.Windows.Forms.PaintEventHandler(this.pbAutoPilotToggle_Paint);
            // 
            // pbFlightEnvelopeToggle
            // 
            this.pbFlightEnvelopeToggle.Location = new System.Drawing.Point(7, 78);
            this.pbFlightEnvelopeToggle.Name = "pbFlightEnvelopeToggle";
            this.pbFlightEnvelopeToggle.Size = new System.Drawing.Size(50, 50);
            this.pbFlightEnvelopeToggle.TabIndex = 33;
            this.pbFlightEnvelopeToggle.TabStop = false;
            this.pbFlightEnvelopeToggle.Paint += new System.Windows.Forms.PaintEventHandler(this.pbFlightEnvelopeToggle_Paint);
            this.pbFlightEnvelopeToggle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbFlightEnvelopeToggle_MouseClick);
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
            // pbGaugeTest
            // 
            this.pbGaugeTest.Location = new System.Drawing.Point(1046, 638);
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
            // gbFCU
            // 
            this.gbFCU.BackColor = System.Drawing.Color.SteelBlue;
            this.gbFCU.Controls.Add(this.pbSelectorDisplay);
            this.gbFCU.Controls.Add(this.pbFlightEnvelopeToggle);
            this.gbFCU.Controls.Add(this.pbAltitudeWheel);
            this.gbFCU.Controls.Add(this.pbAutoPilotToggle);
            this.gbFCU.Controls.Add(this.pbSpeedWheel);
            this.gbFCU.Controls.Add(this.pbHeadingWheel);
            this.gbFCU.Controls.Add(this.pbAutoThrustToggle);
            this.gbFCU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFCU.ForeColor = System.Drawing.Color.White;
            this.gbFCU.Location = new System.Drawing.Point(57, 493);
            this.gbFCU.Name = "gbFCU";
            this.gbFCU.Size = new System.Drawing.Size(993, 139);
            this.gbFCU.TabIndex = 39;
            this.gbFCU.TabStop = false;
            this.gbFCU.Text = "FCU";
            // 
            // pbSelectorDisplay
            // 
            this.pbSelectorDisplay.Location = new System.Drawing.Point(270, 22);
            this.pbSelectorDisplay.Name = "pbSelectorDisplay";
            this.pbSelectorDisplay.Size = new System.Drawing.Size(274, 50);
            this.pbSelectorDisplay.TabIndex = 39;
            this.pbSelectorDisplay.TabStop = false;
            this.pbSelectorDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSelectorDisplay_Paint);
            // 
            // btnAircraftMode
            // 
            this.btnAircraftMode.ForeColor = System.Drawing.Color.Black;
            this.btnAircraftMode.Location = new System.Drawing.Point(933, 638);
            this.btnAircraftMode.Name = "btnAircraftMode";
            this.btnAircraftMode.Size = new System.Drawing.Size(107, 23);
            this.btnAircraftMode.TabIndex = 40;
            this.btnAircraftMode.Text = "AircraftMode";
            this.btnAircraftMode.UseVisualStyleBackColor = true;
            this.btnAircraftMode.Click += new System.EventHandler(this.btnAircraftMode_Click);
            // 
            // btnAltitudeReference
            // 
            this.btnAltitudeReference.ForeColor = System.Drawing.Color.Black;
            this.btnAltitudeReference.Location = new System.Drawing.Point(933, 715);
            this.btnAltitudeReference.Name = "btnAltitudeReference";
            this.btnAltitudeReference.Size = new System.Drawing.Size(107, 23);
            this.btnAltitudeReference.TabIndex = 41;
            this.btnAltitudeReference.Text = "AltitudeReference";
            this.btnAltitudeReference.UseVisualStyleBackColor = true;
            this.btnAltitudeReference.Click += new System.EventHandler(this.btnAltitudeReference_Click);
            // 
            // nudBaroRef
            // 
            this.nudBaroRef.Location = new System.Drawing.Point(933, 689);
            this.nudBaroRef.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudBaroRef.Name = "nudBaroRef";
            this.nudBaroRef.Size = new System.Drawing.Size(107, 20);
            this.nudBaroRef.TabIndex = 42;
            // 
            // txtbTest
            // 
            this.txtbTest.Location = new System.Drawing.Point(933, 761);
            this.txtbTest.Name = "txtbTest";
            this.txtbTest.Size = new System.Drawing.Size(107, 20);
            this.txtbTest.TabIndex = 43;
            // 
            // btnTest
            // 
            this.btnTest.ForeColor = System.Drawing.Color.Black;
            this.btnTest.Location = new System.Drawing.Point(933, 788);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(107, 23);
            this.btnTest.TabIndex = 44;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pbMonitoring
            // 
            this.pbMonitoring.Location = new System.Drawing.Point(1179, 45);
            this.pbMonitoring.Name = "pbMonitoring";
            this.pbMonitoring.Size = new System.Drawing.Size(432, 432);
            this.pbMonitoring.TabIndex = 45;
            this.pbMonitoring.TabStop = false;
            this.pbMonitoring.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMonitoring_Paint);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(1179, 633);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(432, 238);
            this.lbLog.TabIndex = 46;
            // 
            // SmartPilot2020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1812, 909);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.pbMonitoring);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtbTest);
            this.Controls.Add(this.nudBaroRef);
            this.Controls.Add(this.btnAltitudeReference);
            this.Controls.Add(this.btnAircraftMode);
            this.Controls.Add(this.gbFCU);
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
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmartPilot2020";
            this.Text = "SmartPilot2020";
            this.Load += new System.EventHandler(this.RCAutopilot_Load);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbAngle)).EndInit();
            this.gbAircraftTelemetryData.ResumeLayout(false);
            this.gbAircraftTelemetryData.PerformLayout();
            this.gbAircraftEnvironmentalData.ResumeLayout(false);
            this.gbAircraftEnvironmentalData.PerformLayout();
            this.gbStationaryEnvData.ResumeLayout(false);
            this.gbStationaryEnvData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStationaryWindDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoThrustToggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoPilotToggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlightEnvelopeToggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNavigation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGaugeTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeadingVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAltitudeVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpeedVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitorVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPitchRollVisualization)).EndInit();
            this.gbFCU.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectorDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaroRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonitoring)).EndInit();
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
        private System.Windows.Forms.Label lblCurrentPitch;
        private System.Windows.Forms.Label lblCurrentRoll;
        private System.Windows.Forms.Label lblCurrentHeading;
        private System.Windows.Forms.Label lblCurrentSpeed;
        private System.Windows.Forms.Label lblCurrentAltitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.GroupBox gbAircraftTelemetryData;
        private System.Windows.Forms.Label lblAircraftTemperature;
        private System.Windows.Forms.Label lblAircraftHumidity;
        private System.Windows.Forms.Label lblAircraftPressure;
        private System.Windows.Forms.GroupBox gbAircraftEnvironmentalData;
        private System.Windows.Forms.PictureBox pbNavigation;
        private System.Windows.Forms.PictureBox pbFlightEnvelopeToggle;
        private System.Windows.Forms.GroupBox gbStationaryEnvData;
        private System.Windows.Forms.Label lblCurrentWindInformation;
        private System.Windows.Forms.PictureBox pbStationaryWindDirection;
        private System.Windows.Forms.Label lblStationaryPressure;
        private System.Windows.Forms.Label lblStationaryHumidity;
        private System.Windows.Forms.Label lblStationaryTemperature;
        private System.Windows.Forms.PictureBox pbAutoPilotToggle;
        private System.Windows.Forms.PictureBox pbHeadingWheel;
        private System.Windows.Forms.ToolStripStatusLabel lblCarrierTest;
        private System.Windows.Forms.PictureBox pbAutoThrustToggle;
        private System.Windows.Forms.PictureBox pbSpeedWheel;
        private System.Windows.Forms.PictureBox pbAltitudeWheel;
        private System.Windows.Forms.GroupBox gbFCU;
        private System.Windows.Forms.Button btnAircraftMode;
        private System.Windows.Forms.Button btnAltitudeReference;
        private System.Windows.Forms.NumericUpDown nudBaroRef;
        private System.Windows.Forms.TextBox txtbTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.PictureBox pbMonitoring;
        private System.Windows.Forms.PictureBox pbSelectorDisplay;
        private System.Windows.Forms.ListBox lbLog;
    }
}

