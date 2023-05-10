namespace BasicOperation
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.cbxAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.tbxSerailNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxBarcodeVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxRfidVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDeviceVersion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpOperation = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnMask = new System.Windows.Forms.Button();
            this.btnStoredData = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.btnAccess = new System.Windows.Forms.Button();
            this.pnlOpt = new System.Windows.Forms.Panel();
            this.chkContinuousMode = new System.Windows.Forms.CheckBox();
            this.chkReportRssi = new System.Windows.Forms.CheckBox();
            this.cbxOperationMode = new System.Windows.Forms.ComboBox();
            this.chkFilterMode = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoSaveMode = new System.Windows.Forms.CheckBox();
            this.grpData.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.grpOperation.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstData
            // 
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.FullRowSelect = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(3, 17);
            this.lstData.MultiSelect = false;
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(501, 132);
            this.lstData.TabIndex = 0;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            this.lstData.VirtualMode = true;
            this.lstData.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.lstData_CacheVirtualItems);
            this.lstData.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lstData_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 44;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data";
            this.columnHeader2.Width = 219;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Info";
            this.columnHeader3.Width = 158;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "#";
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 17);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(498, 69);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.lstData);
            this.grpData.Location = new System.Drawing.Point(3, 108);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(507, 152);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "Data";
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.rtbLog);
            this.grpLog.Location = new System.Drawing.Point(6, 356);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(504, 89);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log";
            // 
            // cbxDevice
            // 
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Location = new System.Drawing.Point(60, 20);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(79, 20);
            this.cbxDevice.TabIndex = 4;
            this.cbxDevice.SelectedIndexChanged += new System.EventHandler(this.cbxDevice_SelectedIndexChanged);
            // 
            // cbxAddress
            // 
            this.cbxAddress.FormattingEnabled = true;
            this.cbxAddress.Location = new System.Drawing.Point(212, 20);
            this.cbxAddress.Name = "cbxAddress";
            this.cbxAddress.Size = new System.Drawing.Size(79, 20);
            this.cbxAddress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Address";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(406, 16);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(95, 24);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.tbxSerailNumber);
            this.grpConnection.Controls.Add(this.label7);
            this.grpConnection.Controls.Add(this.tbxBarcodeVersion);
            this.grpConnection.Controls.Add(this.label6);
            this.grpConnection.Controls.Add(this.tbxRfidVersion);
            this.grpConnection.Controls.Add(this.label5);
            this.grpConnection.Controls.Add(this.tbxDeviceVersion);
            this.grpConnection.Controls.Add(this.label4);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Controls.Add(this.cbxDevice);
            this.grpConnection.Controls.Add(this.cbxAddress);
            this.grpConnection.Controls.Add(this.label2);
            this.grpConnection.Controls.Add(this.label1);
            this.grpConnection.Location = new System.Drawing.Point(3, 8);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(507, 91);
            this.grpConnection.TabIndex = 10;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // tbxSerailNumber
            // 
            this.tbxSerailNumber.Location = new System.Drawing.Point(11, 63);
            this.tbxSerailNumber.Name = "tbxSerailNumber";
            this.tbxSerailNumber.ReadOnly = true;
            this.tbxSerailNumber.Size = new System.Drawing.Size(107, 21);
            this.tbxSerailNumber.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "S/N";
            // 
            // tbxBarcodeVersion
            // 
            this.tbxBarcodeVersion.Location = new System.Drawing.Point(360, 63);
            this.tbxBarcodeVersion.Name = "tbxBarcodeVersion";
            this.tbxBarcodeVersion.ReadOnly = true;
            this.tbxBarcodeVersion.Size = new System.Drawing.Size(141, 21);
            this.tbxBarcodeVersion.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Barcode Ver.";
            // 
            // tbxRfidVersion
            // 
            this.tbxRfidVersion.Location = new System.Drawing.Point(243, 63);
            this.tbxRfidVersion.Name = "tbxRfidVersion";
            this.tbxRfidVersion.ReadOnly = true;
            this.tbxRfidVersion.Size = new System.Drawing.Size(107, 21);
            this.tbxRfidVersion.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "RFID Ver.";
            // 
            // tbxDeviceVersion
            // 
            this.tbxDeviceVersion.Location = new System.Drawing.Point(127, 63);
            this.tbxDeviceVersion.Name = "tbxDeviceVersion";
            this.tbxDeviceVersion.ReadOnly = true;
            this.tbxDeviceVersion.Size = new System.Drawing.Size(107, 21);
            this.tbxDeviceVersion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Device Ver.";
            // 
            // grpOperation
            // 
            this.grpOperation.Controls.Add(this.pnlButtons);
            this.grpOperation.Controls.Add(this.pnlOpt);
            this.grpOperation.Location = new System.Drawing.Point(6, 266);
            this.grpOperation.Name = "grpOperation";
            this.grpOperation.Size = new System.Drawing.Size(504, 83);
            this.grpOperation.TabIndex = 11;
            this.grpOperation.TabStop = false;
            this.grpOperation.Text = "Operation";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnMask);
            this.pnlButtons.Controls.Add(this.btnStoredData);
            this.pnlButtons.Controls.Add(this.btnInventory);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnOption);
            this.pnlButtons.Controls.Add(this.btnAccess);
            this.pnlButtons.Location = new System.Drawing.Point(12, 45);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(486, 28);
            this.pnlButtons.TabIndex = 12;
            // 
            // btnMask
            // 
            this.btnMask.Location = new System.Drawing.Point(162, 2);
            this.btnMask.Name = "btnMask";
            this.btnMask.Size = new System.Drawing.Size(78, 24);
            this.btnMask.TabIndex = 17;
            this.btnMask.Text = "Mask";
            this.btnMask.UseVisualStyleBackColor = true;
            this.btnMask.Click += new System.EventHandler(this.btnMask_Click);
            // 
            // btnStoredData
            // 
            this.btnStoredData.Location = new System.Drawing.Point(82, 2);
            this.btnStoredData.Name = "btnStoredData";
            this.btnStoredData.Size = new System.Drawing.Size(78, 24);
            this.btnStoredData.TabIndex = 16;
            this.btnStoredData.Text = "Stored Data";
            this.btnStoredData.UseVisualStyleBackColor = true;
            this.btnStoredData.Click += new System.EventHandler(this.btnStoredData_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(402, 2);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(78, 24);
            this.btnInventory.TabIndex = 9;
            this.btnInventory.Text = "inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(322, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 24);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(2, 2);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(78, 24);
            this.btnOption.TabIndex = 12;
            this.btnOption.Text = "Option";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnAccess
            // 
            this.btnAccess.Location = new System.Drawing.Point(242, 2);
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.Size = new System.Drawing.Size(78, 24);
            this.btnAccess.TabIndex = 10;
            this.btnAccess.Text = "Access";
            this.btnAccess.UseVisualStyleBackColor = true;
            this.btnAccess.Click += new System.EventHandler(this.btnAccess_Click);
            // 
            // pnlOpt
            // 
            this.pnlOpt.Controls.Add(this.chkContinuousMode);
            this.pnlOpt.Controls.Add(this.chkReportRssi);
            this.pnlOpt.Controls.Add(this.cbxOperationMode);
            this.pnlOpt.Controls.Add(this.chkFilterMode);
            this.pnlOpt.Controls.Add(this.label3);
            this.pnlOpt.Controls.Add(this.chkAutoSaveMode);
            this.pnlOpt.Location = new System.Drawing.Point(12, 16);
            this.pnlOpt.Name = "pnlOpt";
            this.pnlOpt.Size = new System.Drawing.Size(486, 27);
            this.pnlOpt.TabIndex = 12;
            // 
            // chkContinuousMode
            // 
            this.chkContinuousMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkContinuousMode.AutoSize = true;
            this.chkContinuousMode.Location = new System.Drawing.Point(395, 6);
            this.chkContinuousMode.Name = "chkContinuousMode";
            this.chkContinuousMode.Size = new System.Drawing.Size(88, 16);
            this.chkContinuousMode.TabIndex = 38;
            this.chkContinuousMode.Text = "Continuous";
            this.chkContinuousMode.UseVisualStyleBackColor = true;
            this.chkContinuousMode.CheckedChanged += new System.EventHandler(this.chkContinuousMode_CheckedChanged);
            // 
            // chkReportRssi
            // 
            this.chkReportRssi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReportRssi.AutoSize = true;
            this.chkReportRssi.Location = new System.Drawing.Point(320, 6);
            this.chkReportRssi.Name = "chkReportRssi";
            this.chkReportRssi.Size = new System.Drawing.Size(51, 16);
            this.chkReportRssi.TabIndex = 37;
            this.chkReportRssi.Text = "RSSI";
            this.chkReportRssi.UseVisualStyleBackColor = true;
            this.chkReportRssi.CheckedChanged += new System.EventHandler(this.chkContinuousMode_CheckedChanged);
            // 
            // cbxOperationMode
            // 
            this.cbxOperationMode.FormattingEnabled = true;
            this.cbxOperationMode.Location = new System.Drawing.Point(44, 4);
            this.cbxOperationMode.Name = "cbxOperationMode";
            this.cbxOperationMode.Size = new System.Drawing.Size(95, 20);
            this.cbxOperationMode.TabIndex = 14;
            this.cbxOperationMode.SelectedIndexChanged += new System.EventHandler(this.cbxOperationMode_SelectedIndexChanged);
            // 
            // chkFilterMode
            // 
            this.chkFilterMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFilterMode.AutoSize = true;
            this.chkFilterMode.Location = new System.Drawing.Point(246, 6);
            this.chkFilterMode.Name = "chkFilterMode";
            this.chkFilterMode.Size = new System.Drawing.Size(51, 16);
            this.chkFilterMode.TabIndex = 36;
            this.chkFilterMode.Text = "Filter";
            this.chkFilterMode.UseVisualStyleBackColor = true;
            this.chkFilterMode.CheckedChanged += new System.EventHandler(this.chkContinuousMode_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mode";
            // 
            // chkAutoSaveMode
            // 
            this.chkAutoSaveMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoSaveMode.AutoSize = true;
            this.chkAutoSaveMode.Location = new System.Drawing.Point(152, 6);
            this.chkAutoSaveMode.Name = "chkAutoSaveMode";
            this.chkAutoSaveMode.Size = new System.Drawing.Size(81, 16);
            this.chkAutoSaveMode.TabIndex = 35;
            this.chkAutoSaveMode.Text = "Auto Save";
            this.chkAutoSaveMode.UseVisualStyleBackColor = true;
            this.chkAutoSaveMode.CheckedChanged += new System.EventHandler(this.chkContinuousMode_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpOperation);
            this.Controls.Add(this.grpConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.grpData.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpOperation.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlOpt.ResumeLayout(false);
            this.pnlOpt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.ComboBox cbxAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.GroupBox grpOperation;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnAccess;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxOperationMode;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkContinuousMode;
        private System.Windows.Forms.CheckBox chkReportRssi;
        private System.Windows.Forms.CheckBox chkFilterMode;
        private System.Windows.Forms.CheckBox chkAutoSaveMode;
        private System.Windows.Forms.TextBox tbxBarcodeVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxRfidVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxDeviceVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlOpt;
        private System.Windows.Forms.TextBox tbxSerailNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnStoredData;
        private System.Windows.Forms.Button btnMask;
    }
}

