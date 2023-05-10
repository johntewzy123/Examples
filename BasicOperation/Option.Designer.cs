namespace BasicOperation
{
    partial class Option
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
            this.grpDeviceOptions = new System.Windows.Forms.GroupBox();
            this.btnDeviceTimeSet = new System.Windows.Forms.Button();
            this.tbxDeviceTime = new System.Windows.Forms.TextBox();
            this.chkAlertNotifyLight = new System.Windows.Forms.CheckBox();
            this.chkAlertNotifyVibrate = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkAlertNotifyBeep = new System.Windows.Forms.CheckBox();
            this.numDisplayOffTime = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chkButtonNotifyLight = new System.Windows.Forms.CheckBox();
            this.chkButtonNotifyVibrate = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkButtonNotifyBeep = new System.Windows.Forms.CheckBox();
            this.numAutoOffTime = new System.Windows.Forms.NumericUpDown();
            this.cbxButtonMode = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.grpRfidOptions = new System.Windows.Forms.GroupBox();
            this.cbxSel = new System.Windows.Forms.ComboBox();
            this.cbxTarget = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxSession = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxLinkProfileDefault = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLinkProfileCurrent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChannelFrequencies = new System.Windows.Forms.Button();
            this.btnInventoryAlgorithm = new System.Windows.Forms.Button();
            this.numOperationTime = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numIdleTime = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numInventoryTime = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxPowerGain = new System.Windows.Forms.ComboBox();
            this.lblPowerGain = new System.Windows.Forms.Label();
            this.tbxGlobalBand = new System.Windows.Forms.TextBox();
            this.lblGlobalBand = new System.Windows.Forms.Label();
            this.grpBarcodeOptions = new System.Windows.Forms.GroupBox();
            this.btnGeneralOptions = new System.Windows.Forms.Button();
            this.btnSymbolState = new System.Windows.Forms.Button();
            this.btnDefaultAllSymbol = new System.Windows.Forms.Button();
            this.btnDisableAllSymbol = new System.Windows.Forms.Button();
            this.btnEnableAllSymbol = new System.Windows.Forms.Button();
            this.btnDefaultSetting = new System.Windows.Forms.Button();
            this.pnlLinkProfile = new System.Windows.Forms.Panel();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.pnlDisplayOff = new System.Windows.Forms.Panel();
            this.pnlAutoOff = new System.Windows.Forms.Panel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.grpDeviceOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplayOffTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoOffTime)).BeginInit();
            this.grpRfidOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInventoryTime)).BeginInit();
            this.grpBarcodeOptions.SuspendLayout();
            this.pnlLinkProfile.SuspendLayout();
            this.pnlTime.SuspendLayout();
            this.pnlDisplayOff.SuspendLayout();
            this.pnlAutoOff.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDeviceOptions
            // 
            this.grpDeviceOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpDeviceOptions.Controls.Add(this.pnlButton);
            this.grpDeviceOptions.Controls.Add(this.pnlAutoOff);
            this.grpDeviceOptions.Controls.Add(this.pnlDisplayOff);
            this.grpDeviceOptions.Controls.Add(this.pnlTime);
            this.grpDeviceOptions.Controls.Add(this.chkAlertNotifyLight);
            this.grpDeviceOptions.Controls.Add(this.chkAlertNotifyVibrate);
            this.grpDeviceOptions.Controls.Add(this.chkAlertNotifyBeep);
            this.grpDeviceOptions.Controls.Add(this.label21);
            this.grpDeviceOptions.Location = new System.Drawing.Point(10, 12);
            this.grpDeviceOptions.Name = "grpDeviceOptions";
            this.grpDeviceOptions.Size = new System.Drawing.Size(721, 119);
            this.grpDeviceOptions.TabIndex = 33;
            this.grpDeviceOptions.TabStop = false;
            this.grpDeviceOptions.Text = "Device";
            // 
            // btnDeviceTimeSet
            // 
            this.btnDeviceTimeSet.Location = new System.Drawing.Point(240, 3);
            this.btnDeviceTimeSet.Name = "btnDeviceTimeSet";
            this.btnDeviceTimeSet.Size = new System.Drawing.Size(38, 21);
            this.btnDeviceTimeSet.TabIndex = 21;
            this.btnDeviceTimeSet.Text = "set";
            this.btnDeviceTimeSet.UseVisualStyleBackColor = true;
            this.btnDeviceTimeSet.Click += new System.EventHandler(this.btnDeviceTimeSet_Click);
            // 
            // tbxDeviceTime
            // 
            this.tbxDeviceTime.Location = new System.Drawing.Point(84, 3);
            this.tbxDeviceTime.Name = "tbxDeviceTime";
            this.tbxDeviceTime.ReadOnly = true;
            this.tbxDeviceTime.Size = new System.Drawing.Size(155, 21);
            this.tbxDeviceTime.TabIndex = 20;
            // 
            // chkAlertNotifyLight
            // 
            this.chkAlertNotifyLight.AutoSize = true;
            this.chkAlertNotifyLight.Location = new System.Drawing.Point(605, 77);
            this.chkAlertNotifyLight.Name = "chkAlertNotifyLight";
            this.chkAlertNotifyLight.Size = new System.Drawing.Size(51, 16);
            this.chkAlertNotifyLight.TabIndex = 19;
            this.chkAlertNotifyLight.Text = "Light";
            this.chkAlertNotifyLight.UseVisualStyleBackColor = true;
            this.chkAlertNotifyLight.CheckedChanged += new System.EventHandler(this.chkAlertNotifyBeep_CheckedChanged);
            // 
            // chkAlertNotifyVibrate
            // 
            this.chkAlertNotifyVibrate.AutoSize = true;
            this.chkAlertNotifyVibrate.Location = new System.Drawing.Point(536, 77);
            this.chkAlertNotifyVibrate.Name = "chkAlertNotifyVibrate";
            this.chkAlertNotifyVibrate.Size = new System.Drawing.Size(63, 16);
            this.chkAlertNotifyVibrate.TabIndex = 18;
            this.chkAlertNotifyVibrate.Text = "Vibrate";
            this.chkAlertNotifyVibrate.UseVisualStyleBackColor = true;
            this.chkAlertNotifyVibrate.CheckedChanged += new System.EventHandler(this.chkAlertNotifyBeep_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "Device Time";
            // 
            // chkAlertNotifyBeep
            // 
            this.chkAlertNotifyBeep.AutoSize = true;
            this.chkAlertNotifyBeep.Location = new System.Drawing.Point(475, 77);
            this.chkAlertNotifyBeep.Name = "chkAlertNotifyBeep";
            this.chkAlertNotifyBeep.Size = new System.Drawing.Size(53, 16);
            this.chkAlertNotifyBeep.TabIndex = 17;
            this.chkAlertNotifyBeep.Text = "Beep";
            this.chkAlertNotifyBeep.UseVisualStyleBackColor = true;
            this.chkAlertNotifyBeep.CheckedChanged += new System.EventHandler(this.chkAlertNotifyBeep_CheckedChanged);
            // 
            // numDisplayOffTime
            // 
            this.numDisplayOffTime.Location = new System.Drawing.Point(142, 3);
            this.numDisplayOffTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDisplayOffTime.Name = "numDisplayOffTime";
            this.numDisplayOffTime.Size = new System.Drawing.Size(124, 21);
            this.numDisplayOffTime.TabIndex = 11;
            this.numDisplayOffTime.ValueChanged += new System.EventHandler(this.numDisplayOffTime_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(363, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 12);
            this.label21.TabIndex = 6;
            this.label21.Text = "Alert Notify";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "Display Off Time (sec)";
            // 
            // chkButtonNotifyLight
            // 
            this.chkButtonNotifyLight.AutoSize = true;
            this.chkButtonNotifyLight.Location = new System.Drawing.Point(222, 30);
            this.chkButtonNotifyLight.Name = "chkButtonNotifyLight";
            this.chkButtonNotifyLight.Size = new System.Drawing.Size(51, 16);
            this.chkButtonNotifyLight.TabIndex = 16;
            this.chkButtonNotifyLight.Text = "Light";
            this.chkButtonNotifyLight.UseVisualStyleBackColor = true;
            this.chkButtonNotifyLight.CheckedChanged += new System.EventHandler(this.chkButtonNotifyBeep_CheckedChanged);
            // 
            // chkButtonNotifyVibrate
            // 
            this.chkButtonNotifyVibrate.AutoSize = true;
            this.chkButtonNotifyVibrate.Location = new System.Drawing.Point(153, 30);
            this.chkButtonNotifyVibrate.Name = "chkButtonNotifyVibrate";
            this.chkButtonNotifyVibrate.Size = new System.Drawing.Size(63, 16);
            this.chkButtonNotifyVibrate.TabIndex = 15;
            this.chkButtonNotifyVibrate.Text = "Vibrate";
            this.chkButtonNotifyVibrate.UseVisualStyleBackColor = true;
            this.chkButtonNotifyVibrate.CheckedChanged += new System.EventHandler(this.chkButtonNotifyBeep_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 12);
            this.label18.TabIndex = 3;
            this.label18.Text = "Auto Off Time (sec)";
            // 
            // chkButtonNotifyBeep
            // 
            this.chkButtonNotifyBeep.AutoSize = true;
            this.chkButtonNotifyBeep.Location = new System.Drawing.Point(94, 30);
            this.chkButtonNotifyBeep.Name = "chkButtonNotifyBeep";
            this.chkButtonNotifyBeep.Size = new System.Drawing.Size(53, 16);
            this.chkButtonNotifyBeep.TabIndex = 14;
            this.chkButtonNotifyBeep.Text = "Beep";
            this.chkButtonNotifyBeep.UseVisualStyleBackColor = true;
            this.chkButtonNotifyBeep.CheckedChanged += new System.EventHandler(this.chkButtonNotifyBeep_CheckedChanged);
            // 
            // numAutoOffTime
            // 
            this.numAutoOffTime.Location = new System.Drawing.Point(122, 3);
            this.numAutoOffTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numAutoOffTime.Name = "numAutoOffTime";
            this.numAutoOffTime.Size = new System.Drawing.Size(124, 21);
            this.numAutoOffTime.TabIndex = 12;
            this.numAutoOffTime.ValueChanged += new System.EventHandler(this.numAutoOffTime_ValueChanged);
            // 
            // cbxButtonMode
            // 
            this.cbxButtonMode.FormattingEnabled = true;
            this.cbxButtonMode.Location = new System.Drawing.Point(91, 3);
            this.cbxButtonMode.Name = "cbxButtonMode";
            this.cbxButtonMode.Size = new System.Drawing.Size(155, 20);
            this.cbxButtonMode.TabIndex = 13;
            this.cbxButtonMode.SelectedIndexChanged += new System.EventHandler(this.cbxButtonMode_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 12);
            this.label20.TabIndex = 5;
            this.label20.Text = "Button Notify";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 12);
            this.label19.TabIndex = 4;
            this.label19.Text = "Button Mode";
            // 
            // grpRfidOptions
            // 
            this.grpRfidOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpRfidOptions.Controls.Add(this.pnlLinkProfile);
            this.grpRfidOptions.Controls.Add(this.cbxSel);
            this.grpRfidOptions.Controls.Add(this.cbxTarget);
            this.grpRfidOptions.Controls.Add(this.label13);
            this.grpRfidOptions.Controls.Add(this.label10);
            this.grpRfidOptions.Controls.Add(this.cbxSession);
            this.grpRfidOptions.Controls.Add(this.label11);
            this.grpRfidOptions.Controls.Add(this.btnChannelFrequencies);
            this.grpRfidOptions.Controls.Add(this.btnInventoryAlgorithm);
            this.grpRfidOptions.Controls.Add(this.numOperationTime);
            this.grpRfidOptions.Controls.Add(this.label12);
            this.grpRfidOptions.Controls.Add(this.numIdleTime);
            this.grpRfidOptions.Controls.Add(this.label8);
            this.grpRfidOptions.Controls.Add(this.numInventoryTime);
            this.grpRfidOptions.Controls.Add(this.label7);
            this.grpRfidOptions.Controls.Add(this.cbxPowerGain);
            this.grpRfidOptions.Controls.Add(this.lblPowerGain);
            this.grpRfidOptions.Controls.Add(this.tbxGlobalBand);
            this.grpRfidOptions.Controls.Add(this.lblGlobalBand);
            this.grpRfidOptions.Location = new System.Drawing.Point(10, 137);
            this.grpRfidOptions.Name = "grpRfidOptions";
            this.grpRfidOptions.Size = new System.Drawing.Size(721, 167);
            this.grpRfidOptions.TabIndex = 34;
            this.grpRfidOptions.TabStop = false;
            this.grpRfidOptions.Text = "RFID";
            // 
            // cbxSel
            // 
            this.cbxSel.FormattingEnabled = true;
            this.cbxSel.Location = new System.Drawing.Point(45, 89);
            this.cbxSel.Name = "cbxSel";
            this.cbxSel.Size = new System.Drawing.Size(108, 20);
            this.cbxSel.TabIndex = 40;
            this.cbxSel.SelectedIndexChanged += new System.EventHandler(this.cbxSel_SelectedIndexChanged);
            // 
            // cbxTarget
            // 
            this.cbxTarget.FormattingEnabled = true;
            this.cbxTarget.Location = new System.Drawing.Point(393, 89);
            this.cbxTarget.Name = "cbxTarget";
            this.cbxTarget.Size = new System.Drawing.Size(108, 20);
            this.cbxTarget.TabIndex = 42;
            this.cbxTarget.SelectedIndexChanged += new System.EventHandler(this.cbxTarget_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(347, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "Target";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "Sel";
            // 
            // cbxSession
            // 
            this.cbxSession.FormattingEnabled = true;
            this.cbxSession.Location = new System.Drawing.Point(226, 89);
            this.cbxSession.Name = "cbxSession";
            this.cbxSession.Size = new System.Drawing.Size(108, 20);
            this.cbxSession.TabIndex = 41;
            this.cbxSession.SelectedIndexChanged += new System.EventHandler(this.cbxSession_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(172, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "Session";
            // 
            // cbxLinkProfileDefault
            // 
            this.cbxLinkProfileDefault.FormattingEnabled = true;
            this.cbxLinkProfileDefault.Location = new System.Drawing.Point(305, 6);
            this.cbxLinkProfileDefault.Name = "cbxLinkProfileDefault";
            this.cbxLinkProfileDefault.Size = new System.Drawing.Size(50, 20);
            this.cbxLinkProfileDefault.TabIndex = 36;
            this.cbxLinkProfileDefault.SelectedIndexChanged += new System.EventHandler(this.cbxLinkProfileDefault_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "Link Profile(default)";
            // 
            // cbxLinkProfileCurrent
            // 
            this.cbxLinkProfileCurrent.FormattingEnabled = true;
            this.cbxLinkProfileCurrent.Location = new System.Drawing.Point(126, 6);
            this.cbxLinkProfileCurrent.Name = "cbxLinkProfileCurrent";
            this.cbxLinkProfileCurrent.Size = new System.Drawing.Size(50, 20);
            this.cbxLinkProfileCurrent.TabIndex = 34;
            this.cbxLinkProfileCurrent.SelectedIndexChanged += new System.EventHandler(this.cbxLinkProfileCurrent_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "Link Profile(currnet)";
            // 
            // btnChannelFrequencies
            // 
            this.btnChannelFrequencies.Location = new System.Drawing.Point(536, 45);
            this.btnChannelFrequencies.Name = "btnChannelFrequencies";
            this.btnChannelFrequencies.Size = new System.Drawing.Size(149, 30);
            this.btnChannelFrequencies.TabIndex = 32;
            this.btnChannelFrequencies.Text = "Channel Frequencies";
            this.btnChannelFrequencies.UseVisualStyleBackColor = true;
            this.btnChannelFrequencies.Click += new System.EventHandler(this.btnChannelFrequencies_Click);
            // 
            // btnInventoryAlgorithm
            // 
            this.btnInventoryAlgorithm.Location = new System.Drawing.Point(382, 45);
            this.btnInventoryAlgorithm.Name = "btnInventoryAlgorithm";
            this.btnInventoryAlgorithm.Size = new System.Drawing.Size(150, 30);
            this.btnInventoryAlgorithm.TabIndex = 30;
            this.btnInventoryAlgorithm.Text = "Inventory Algorithm";
            this.btnInventoryAlgorithm.UseVisualStyleBackColor = true;
            this.btnInventoryAlgorithm.Click += new System.EventHandler(this.btnInventoryAlgorithm_Click);
            // 
            // numOperationTime
            // 
            this.numOperationTime.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOperationTime.Location = new System.Drawing.Point(566, 17);
            this.numOperationTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numOperationTime.Name = "numOperationTime";
            this.numOperationTime.Size = new System.Drawing.Size(62, 21);
            this.numOperationTime.TabIndex = 24;
            this.numOperationTime.ValueChanged += new System.EventHandler(this.numOperationTime_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(439, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 12);
            this.label12.TabIndex = 23;
            this.label12.Text = "Operation Time (ms)";
            // 
            // numIdleTime
            // 
            this.numIdleTime.Location = new System.Drawing.Point(309, 51);
            this.numIdleTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numIdleTime.Name = "numIdleTime";
            this.numIdleTime.Size = new System.Drawing.Size(62, 21);
            this.numIdleTime.TabIndex = 14;
            this.numIdleTime.ValueChanged += new System.EventHandler(this.numIdleTime_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "Idle Time (ms)";
            // 
            // numInventoryTime
            // 
            this.numInventoryTime.Location = new System.Drawing.Point(142, 51);
            this.numInventoryTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numInventoryTime.Name = "numInventoryTime";
            this.numInventoryTime.Size = new System.Drawing.Size(62, 21);
            this.numInventoryTime.TabIndex = 12;
            this.numInventoryTime.ValueChanged += new System.EventHandler(this.numInventoryTime_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "Inventory Time (ms)";
            // 
            // cbxPowerGain
            // 
            this.cbxPowerGain.FormattingEnabled = true;
            this.cbxPowerGain.Location = new System.Drawing.Point(354, 16);
            this.cbxPowerGain.Name = "cbxPowerGain";
            this.cbxPowerGain.Size = new System.Drawing.Size(83, 20);
            this.cbxPowerGain.TabIndex = 5;
            this.cbxPowerGain.SelectedIndexChanged += new System.EventHandler(this.cbxPowerGain_SelectedIndexChanged);
            // 
            // lblPowerGain
            // 
            this.lblPowerGain.AutoSize = true;
            this.lblPowerGain.Location = new System.Drawing.Point(278, 19);
            this.lblPowerGain.Name = "lblPowerGain";
            this.lblPowerGain.Size = new System.Drawing.Size(71, 12);
            this.lblPowerGain.TabIndex = 4;
            this.lblPowerGain.Text = "Power Gain";
            // 
            // tbxGlobalBand
            // 
            this.tbxGlobalBand.Location = new System.Drawing.Point(97, 17);
            this.tbxGlobalBand.Name = "tbxGlobalBand";
            this.tbxGlobalBand.ReadOnly = true;
            this.tbxGlobalBand.Size = new System.Drawing.Size(167, 21);
            this.tbxGlobalBand.TabIndex = 3;
            // 
            // lblGlobalBand
            // 
            this.lblGlobalBand.AutoSize = true;
            this.lblGlobalBand.Location = new System.Drawing.Point(17, 23);
            this.lblGlobalBand.Name = "lblGlobalBand";
            this.lblGlobalBand.Size = new System.Drawing.Size(74, 12);
            this.lblGlobalBand.TabIndex = 2;
            this.lblGlobalBand.Text = "Global Band";
            // 
            // grpBarcodeOptions
            // 
            this.grpBarcodeOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpBarcodeOptions.Controls.Add(this.btnGeneralOptions);
            this.grpBarcodeOptions.Controls.Add(this.btnSymbolState);
            this.grpBarcodeOptions.Controls.Add(this.btnDefaultAllSymbol);
            this.grpBarcodeOptions.Controls.Add(this.btnDisableAllSymbol);
            this.grpBarcodeOptions.Controls.Add(this.btnEnableAllSymbol);
            this.grpBarcodeOptions.Location = new System.Drawing.Point(10, 312);
            this.grpBarcodeOptions.Name = "grpBarcodeOptions";
            this.grpBarcodeOptions.Size = new System.Drawing.Size(719, 113);
            this.grpBarcodeOptions.TabIndex = 35;
            this.grpBarcodeOptions.TabStop = false;
            this.grpBarcodeOptions.Text = "Barcode";
            // 
            // btnGeneralOptions
            // 
            this.btnGeneralOptions.Location = new System.Drawing.Point(6, 55);
            this.btnGeneralOptions.Name = "btnGeneralOptions";
            this.btnGeneralOptions.Size = new System.Drawing.Size(162, 30);
            this.btnGeneralOptions.TabIndex = 15;
            this.btnGeneralOptions.Text = "General Options";
            this.btnGeneralOptions.UseVisualStyleBackColor = true;
            this.btnGeneralOptions.Click += new System.EventHandler(this.btnGeneralOptions_Click);
            // 
            // btnSymbolState
            // 
            this.btnSymbolState.Location = new System.Drawing.Point(6, 19);
            this.btnSymbolState.Name = "btnSymbolState";
            this.btnSymbolState.Size = new System.Drawing.Size(162, 30);
            this.btnSymbolState.TabIndex = 14;
            this.btnSymbolState.Text = "Symbologies State";
            this.btnSymbolState.UseVisualStyleBackColor = true;
            this.btnSymbolState.Click += new System.EventHandler(this.btnSymbolState_Click);
            // 
            // btnDefaultAllSymbol
            // 
            this.btnDefaultAllSymbol.Location = new System.Drawing.Point(541, 19);
            this.btnDefaultAllSymbol.Name = "btnDefaultAllSymbol";
            this.btnDefaultAllSymbol.Size = new System.Drawing.Size(162, 30);
            this.btnDefaultAllSymbol.TabIndex = 12;
            this.btnDefaultAllSymbol.Text = "Default All Symbologies";
            this.btnDefaultAllSymbol.UseVisualStyleBackColor = true;
            this.btnDefaultAllSymbol.Click += new System.EventHandler(this.btnDefaultAllSymbol_Click);
            // 
            // btnDisableAllSymbol
            // 
            this.btnDisableAllSymbol.Location = new System.Drawing.Point(365, 19);
            this.btnDisableAllSymbol.Name = "btnDisableAllSymbol";
            this.btnDisableAllSymbol.Size = new System.Drawing.Size(162, 30);
            this.btnDisableAllSymbol.TabIndex = 13;
            this.btnDisableAllSymbol.Text = "Disable All Symbologies";
            this.btnDisableAllSymbol.UseVisualStyleBackColor = true;
            this.btnDisableAllSymbol.Click += new System.EventHandler(this.btnDisableAllSymbol_Click);
            // 
            // btnEnableAllSymbol
            // 
            this.btnEnableAllSymbol.Location = new System.Drawing.Point(187, 19);
            this.btnEnableAllSymbol.Name = "btnEnableAllSymbol";
            this.btnEnableAllSymbol.Size = new System.Drawing.Size(162, 30);
            this.btnEnableAllSymbol.TabIndex = 11;
            this.btnEnableAllSymbol.Text = "Enable All Symbologies";
            this.btnEnableAllSymbol.UseVisualStyleBackColor = true;
            this.btnEnableAllSymbol.Click += new System.EventHandler(this.btnEnableAllSymbol_Click);
            // 
            // btnDefaultSetting
            // 
            this.btnDefaultSetting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDefaultSetting.Location = new System.Drawing.Point(257, 441);
            this.btnDefaultSetting.Name = "btnDefaultSetting";
            this.btnDefaultSetting.Size = new System.Drawing.Size(215, 30);
            this.btnDefaultSetting.TabIndex = 36;
            this.btnDefaultSetting.Text = "Default";
            this.btnDefaultSetting.UseVisualStyleBackColor = true;
            this.btnDefaultSetting.Click += new System.EventHandler(this.btnDefaultSetting_Click);
            // 
            // pnlLinkProfile
            // 
            this.pnlLinkProfile.Controls.Add(this.cbxLinkProfileDefault);
            this.pnlLinkProfile.Controls.Add(this.label2);
            this.pnlLinkProfile.Controls.Add(this.cbxLinkProfileCurrent);
            this.pnlLinkProfile.Controls.Add(this.label3);
            this.pnlLinkProfile.Location = new System.Drawing.Point(17, 119);
            this.pnlLinkProfile.Name = "pnlLinkProfile";
            this.pnlLinkProfile.Size = new System.Drawing.Size(371, 31);
            this.pnlLinkProfile.TabIndex = 43;
            // 
            // pnlTime
            // 
            this.pnlTime.Controls.Add(this.btnDeviceTimeSet);
            this.pnlTime.Controls.Add(this.tbxDeviceTime);
            this.pnlTime.Controls.Add(this.label14);
            this.pnlTime.Location = new System.Drawing.Point(20, 19);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(280, 27);
            this.pnlTime.TabIndex = 37;
            // 
            // pnlDisplayOff
            // 
            this.pnlDisplayOff.Controls.Add(this.numDisplayOffTime);
            this.pnlDisplayOff.Controls.Add(this.label15);
            this.pnlDisplayOff.Location = new System.Drawing.Point(359, 17);
            this.pnlDisplayOff.Name = "pnlDisplayOff";
            this.pnlDisplayOff.Size = new System.Drawing.Size(270, 27);
            this.pnlDisplayOff.TabIndex = 44;
            // 
            // pnlAutoOff
            // 
            this.pnlAutoOff.Controls.Add(this.numAutoOffTime);
            this.pnlAutoOff.Controls.Add(this.label18);
            this.pnlAutoOff.Location = new System.Drawing.Point(379, 47);
            this.pnlAutoOff.Name = "pnlAutoOff";
            this.pnlAutoOff.Size = new System.Drawing.Size(249, 27);
            this.pnlAutoOff.TabIndex = 45;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cbxButtonMode);
            this.pnlButton.Controls.Add(this.chkButtonNotifyLight);
            this.pnlButton.Controls.Add(this.label19);
            this.pnlButton.Controls.Add(this.chkButtonNotifyVibrate);
            this.pnlButton.Controls.Add(this.label20);
            this.pnlButton.Controls.Add(this.chkButtonNotifyBeep);
            this.pnlButton.Location = new System.Drawing.Point(15, 50);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(276, 51);
            this.pnlButton.TabIndex = 38;
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 483);
            this.Controls.Add(this.btnDefaultSetting);
            this.Controls.Add(this.grpBarcodeOptions);
            this.Controls.Add(this.grpRfidOptions);
            this.Controls.Add(this.grpDeviceOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.Option_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Option_FormClosing);
            this.grpDeviceOptions.ResumeLayout(false);
            this.grpDeviceOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDisplayOffTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoOffTime)).EndInit();
            this.grpRfidOptions.ResumeLayout(false);
            this.grpRfidOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOperationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInventoryTime)).EndInit();
            this.grpBarcodeOptions.ResumeLayout(false);
            this.pnlLinkProfile.ResumeLayout(false);
            this.pnlLinkProfile.PerformLayout();
            this.pnlTime.ResumeLayout(false);
            this.pnlTime.PerformLayout();
            this.pnlDisplayOff.ResumeLayout(false);
            this.pnlDisplayOff.PerformLayout();
            this.pnlAutoOff.ResumeLayout(false);
            this.pnlAutoOff.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDeviceOptions;
        private System.Windows.Forms.Button btnDeviceTimeSet;
        private System.Windows.Forms.TextBox tbxDeviceTime;
        private System.Windows.Forms.CheckBox chkAlertNotifyLight;
        private System.Windows.Forms.CheckBox chkAlertNotifyVibrate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkAlertNotifyBeep;
        private System.Windows.Forms.NumericUpDown numDisplayOffTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkButtonNotifyLight;
        private System.Windows.Forms.CheckBox chkButtonNotifyVibrate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkButtonNotifyBeep;
        private System.Windows.Forms.NumericUpDown numAutoOffTime;
        private System.Windows.Forms.ComboBox cbxButtonMode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox grpRfidOptions;
        private System.Windows.Forms.ComboBox cbxLinkProfileDefault;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLinkProfileCurrent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChannelFrequencies;
        private System.Windows.Forms.Button btnInventoryAlgorithm;
        private System.Windows.Forms.NumericUpDown numOperationTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numIdleTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numInventoryTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxPowerGain;
        private System.Windows.Forms.Label lblPowerGain;
        private System.Windows.Forms.TextBox tbxGlobalBand;
        private System.Windows.Forms.Label lblGlobalBand;
        private System.Windows.Forms.ComboBox cbxSel;
        private System.Windows.Forms.ComboBox cbxTarget;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxSession;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpBarcodeOptions;
        private System.Windows.Forms.Button btnGeneralOptions;
        private System.Windows.Forms.Button btnSymbolState;
        private System.Windows.Forms.Button btnDefaultAllSymbol;
        private System.Windows.Forms.Button btnDisableAllSymbol;
        private System.Windows.Forms.Button btnEnableAllSymbol;
        private System.Windows.Forms.Button btnDefaultSetting;
        private System.Windows.Forms.Panel pnlLinkProfile;
        private System.Windows.Forms.Panel pnlTime;
        private System.Windows.Forms.Panel pnlAutoOff;
        private System.Windows.Forms.Panel pnlDisplayOff;
        private System.Windows.Forms.Panel pnlButton;
    }
}