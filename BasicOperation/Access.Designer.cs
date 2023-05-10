namespace BasicOperation
{
    partial class Access
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
            this.grpReadMemory = new System.Windows.Forms.GroupBox();
            this.numReadLength = new System.Windows.Forms.NumericUpDown();
            this.numReadOffset = new System.Windows.Forms.NumericUpDown();
            this.btnRead = new System.Windows.Forms.Button();
            this.tbxReadData = new System.Windows.Forms.TextBox();
            this.lblReadDataLength = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tbxReadAccessPwd = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cbxReadMemBank = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numWriteOffset = new System.Windows.Forms.NumericUpDown();
            this.btnWrite = new System.Windows.Forms.Button();
            this.tbxWriteData = new System.Windows.Forms.TextBox();
            this.lblWriteDataLength = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxWriteAccessPWD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxWriteMemBank = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxLockAccessPWD = new System.Windows.Forms.TextBox();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.chkLockUser = new System.Windows.Forms.CheckBox();
            this.chkLockTid = new System.Windows.Forms.CheckBox();
            this.chkLockEpc = new System.Windows.Forms.CheckBox();
            this.chkLockAccessPwd = new System.Windows.Forms.CheckBox();
            this.chkLockKillPwd = new System.Windows.Forms.CheckBox();
            this.btnPermalock = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnKill = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxKillPWD = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxExtParams = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxAccessedTag = new System.Windows.Forms.TextBox();
            this.grpReadMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReadLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadOffset)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteOffset)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReadMemory
            // 
            this.grpReadMemory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpReadMemory.Controls.Add(this.numReadLength);
            this.grpReadMemory.Controls.Add(this.numReadOffset);
            this.grpReadMemory.Controls.Add(this.btnRead);
            this.grpReadMemory.Controls.Add(this.tbxReadData);
            this.grpReadMemory.Controls.Add(this.lblReadDataLength);
            this.grpReadMemory.Controls.Add(this.label30);
            this.grpReadMemory.Controls.Add(this.tbxReadAccessPwd);
            this.grpReadMemory.Controls.Add(this.label27);
            this.grpReadMemory.Controls.Add(this.label26);
            this.grpReadMemory.Controls.Add(this.label25);
            this.grpReadMemory.Controls.Add(this.cbxReadMemBank);
            this.grpReadMemory.Location = new System.Drawing.Point(12, 109);
            this.grpReadMemory.Name = "grpReadMemory";
            this.grpReadMemory.Size = new System.Drawing.Size(560, 142);
            this.grpReadMemory.TabIndex = 6;
            this.grpReadMemory.TabStop = false;
            this.grpReadMemory.Text = "Read";
            // 
            // numReadLength
            // 
            this.numReadLength.Location = new System.Drawing.Point(216, 33);
            this.numReadLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReadLength.Name = "numReadLength";
            this.numReadLength.Size = new System.Drawing.Size(99, 21);
            this.numReadLength.TabIndex = 12;
            this.numReadLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numReadOffset
            // 
            this.numReadOffset.Location = new System.Drawing.Point(111, 33);
            this.numReadOffset.Name = "numReadOffset";
            this.numReadOffset.Size = new System.Drawing.Size(99, 21);
            this.numReadOffset.TabIndex = 11;
            // 
            // btnRead
            // 
            this.btnRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRead.Location = new System.Drawing.Point(431, 23);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(123, 29);
            this.btnRead.TabIndex = 10;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tbxReadData
            // 
            this.tbxReadData.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbxReadData.Location = new System.Drawing.Point(6, 72);
            this.tbxReadData.Multiline = true;
            this.tbxReadData.Name = "tbxReadData";
            this.tbxReadData.ReadOnly = true;
            this.tbxReadData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxReadData.Size = new System.Drawing.Size(548, 64);
            this.tbxReadData.TabIndex = 9;
            // 
            // lblReadDataLength
            // 
            this.lblReadDataLength.AutoSize = true;
            this.lblReadDataLength.Location = new System.Drawing.Point(4, 57);
            this.lblReadDataLength.Name = "lblReadDataLength";
            this.lblReadDataLength.Size = new System.Drawing.Size(75, 12);
            this.lblReadDataLength.TabIndex = 8;
            this.lblReadDataLength.Text = "Data ( 0 bit )";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(336, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 12);
            this.label30.TabIndex = 7;
            this.label30.Text = "Access PWD";
            // 
            // tbxReadAccessPwd
            // 
            this.tbxReadAccessPwd.Location = new System.Drawing.Point(321, 33);
            this.tbxReadAccessPwd.MaxLength = 8;
            this.tbxReadAccessPwd.Name = "tbxReadAccessPwd";
            this.tbxReadAccessPwd.Size = new System.Drawing.Size(99, 21);
            this.tbxReadAccessPwd.TabIndex = 6;
            this.tbxReadAccessPwd.Text = "00000000";
            this.tbxReadAccessPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxReadAccessPwd_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(240, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 12);
            this.label27.TabIndex = 5;
            this.label27.Text = "WordCount";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(136, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 12);
            this.label26.TabIndex = 3;
            this.label26.Text = "WordPtr";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 12);
            this.label25.TabIndex = 1;
            this.label25.Text = "MemBank";
            // 
            // cbxReadMemBank
            // 
            this.cbxReadMemBank.FormattingEnabled = true;
            this.cbxReadMemBank.Location = new System.Drawing.Point(6, 32);
            this.cbxReadMemBank.Name = "cbxReadMemBank";
            this.cbxReadMemBank.Size = new System.Drawing.Size(99, 20);
            this.cbxReadMemBank.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.numWriteOffset);
            this.groupBox1.Controls.Add(this.btnWrite);
            this.groupBox1.Controls.Add(this.tbxWriteData);
            this.groupBox1.Controls.Add(this.lblWriteDataLength);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxWriteAccessPWD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxWriteMemBank);
            this.groupBox1.Location = new System.Drawing.Point(12, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 145);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Write";
            // 
            // numWriteOffset
            // 
            this.numWriteOffset.Location = new System.Drawing.Point(111, 31);
            this.numWriteOffset.Name = "numWriteOffset";
            this.numWriteOffset.Size = new System.Drawing.Size(99, 21);
            this.numWriteOffset.TabIndex = 11;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(431, 20);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(123, 29);
            this.btnWrite.TabIndex = 10;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // tbxWriteData
            // 
            this.tbxWriteData.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbxWriteData.Location = new System.Drawing.Point(6, 75);
            this.tbxWriteData.Multiline = true;
            this.tbxWriteData.Name = "tbxWriteData";
            this.tbxWriteData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxWriteData.Size = new System.Drawing.Size(548, 64);
            this.tbxWriteData.TabIndex = 9;
            this.tbxWriteData.TextChanged += new System.EventHandler(this.tbxWriteData_TextChanged);
            this.tbxWriteData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxReadAccessPwd_KeyPress);
            // 
            // lblWriteDataLength
            // 
            this.lblWriteDataLength.AutoSize = true;
            this.lblWriteDataLength.Location = new System.Drawing.Point(12, 60);
            this.lblWriteDataLength.Name = "lblWriteDataLength";
            this.lblWriteDataLength.Size = new System.Drawing.Size(75, 12);
            this.lblWriteDataLength.TabIndex = 8;
            this.lblWriteDataLength.Text = "Data ( 0 bit )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Access PWD";
            // 
            // tbxWriteAccessPWD
            // 
            this.tbxWriteAccessPWD.Location = new System.Drawing.Point(216, 32);
            this.tbxWriteAccessPWD.MaxLength = 8;
            this.tbxWriteAccessPWD.Name = "tbxWriteAccessPWD";
            this.tbxWriteAccessPWD.Size = new System.Drawing.Size(99, 21);
            this.tbxWriteAccessPWD.TabIndex = 6;
            this.tbxWriteAccessPWD.Text = "00000000";
            this.tbxWriteAccessPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxReadAccessPwd_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "WordPtr";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "MemBank";
            // 
            // cbxWriteMemBank
            // 
            this.cbxWriteMemBank.FormattingEnabled = true;
            this.cbxWriteMemBank.Location = new System.Drawing.Point(6, 32);
            this.cbxWriteMemBank.Name = "cbxWriteMemBank";
            this.cbxWriteMemBank.Size = new System.Drawing.Size(99, 20);
            this.cbxWriteMemBank.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbxLockAccessPWD);
            this.groupBox2.Controls.Add(this.btnUnlock);
            this.groupBox2.Controls.Add(this.btnLock);
            this.groupBox2.Controls.Add(this.chkLockUser);
            this.groupBox2.Controls.Add(this.chkLockTid);
            this.groupBox2.Controls.Add(this.chkLockEpc);
            this.groupBox2.Controls.Add(this.chkLockAccessPwd);
            this.groupBox2.Controls.Add(this.chkLockKillPwd);
            this.groupBox2.Controls.Add(this.btnPermalock);
            this.groupBox2.Location = new System.Drawing.Point(12, 408);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 78);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "Access PWD";
            // 
            // tbxLockAccessPWD
            // 
            this.tbxLockAccessPWD.Location = new System.Drawing.Point(321, 39);
            this.tbxLockAccessPWD.MaxLength = 8;
            this.tbxLockAccessPWD.Name = "tbxLockAccessPWD";
            this.tbxLockAccessPWD.Size = new System.Drawing.Size(99, 21);
            this.tbxLockAccessPWD.TabIndex = 18;
            this.tbxLockAccessPWD.Text = "00000000";
            this.tbxLockAccessPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxReadAccessPwd_KeyPress);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(494, 15);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(62, 29);
            this.btnUnlock.TabIndex = 17;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(431, 15);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(62, 29);
            this.btnLock.TabIndex = 16;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // chkLockUser
            // 
            this.chkLockUser.AutoSize = true;
            this.chkLockUser.Location = new System.Drawing.Point(216, 44);
            this.chkLockUser.Name = "chkLockUser";
            this.chkLockUser.Size = new System.Drawing.Size(50, 16);
            this.chkLockUser.TabIndex = 15;
            this.chkLockUser.Text = "User";
            this.chkLockUser.UseVisualStyleBackColor = true;
            // 
            // chkLockTid
            // 
            this.chkLockTid.AutoSize = true;
            this.chkLockTid.Location = new System.Drawing.Point(126, 44);
            this.chkLockTid.Name = "chkLockTid";
            this.chkLockTid.Size = new System.Drawing.Size(43, 16);
            this.chkLockTid.TabIndex = 14;
            this.chkLockTid.Text = "TID";
            this.chkLockTid.UseVisualStyleBackColor = true;
            // 
            // chkLockEpc
            // 
            this.chkLockEpc.AutoSize = true;
            this.chkLockEpc.Location = new System.Drawing.Point(34, 44);
            this.chkLockEpc.Name = "chkLockEpc";
            this.chkLockEpc.Size = new System.Drawing.Size(49, 16);
            this.chkLockEpc.TabIndex = 13;
            this.chkLockEpc.Text = "EPC";
            this.chkLockEpc.UseVisualStyleBackColor = true;
            // 
            // chkLockAccessPwd
            // 
            this.chkLockAccessPwd.AutoSize = true;
            this.chkLockAccessPwd.Location = new System.Drawing.Point(162, 22);
            this.chkLockAccessPwd.Name = "chkLockAccessPwd";
            this.chkLockAccessPwd.Size = new System.Drawing.Size(128, 16);
            this.chkLockAccessPwd.TabIndex = 12;
            this.chkLockAccessPwd.Text = "Access Password";
            this.chkLockAccessPwd.UseVisualStyleBackColor = true;
            // 
            // chkLockKillPwd
            // 
            this.chkLockKillPwd.AutoSize = true;
            this.chkLockKillPwd.Location = new System.Drawing.Point(34, 22);
            this.chkLockKillPwd.Name = "chkLockKillPwd";
            this.chkLockKillPwd.Size = new System.Drawing.Size(102, 16);
            this.chkLockKillPwd.TabIndex = 11;
            this.chkLockKillPwd.Text = "Kill Password";
            this.chkLockKillPwd.UseVisualStyleBackColor = true;
            // 
            // btnPermalock
            // 
            this.btnPermalock.Location = new System.Drawing.Point(431, 44);
            this.btnPermalock.Name = "btnPermalock";
            this.btnPermalock.Size = new System.Drawing.Size(125, 29);
            this.btnPermalock.TabIndex = 10;
            this.btnPermalock.Text = "Permalock";
            this.btnPermalock.UseVisualStyleBackColor = true;
            this.btnPermalock.Click += new System.EventHandler(this.btnPermalock_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnKill);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbxKillPWD);
            this.groupBox3.Location = new System.Drawing.Point(12, 492);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 65);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kill";
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(44, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 24);
            this.label9.TabIndex = 21;
            this.label9.Text = "After completing kill operation, Tag can not be recovered.";
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(431, 27);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(123, 29);
            this.btnKill.TabIndex = 20;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "Kill PWD";
            // 
            // tbxKillPWD
            // 
            this.tbxKillPWD.Location = new System.Drawing.Point(321, 35);
            this.tbxKillPWD.MaxLength = 8;
            this.tbxKillPWD.Name = "tbxKillPWD";
            this.tbxKillPWD.Size = new System.Drawing.Size(99, 21);
            this.tbxKillPWD.TabIndex = 18;
            this.tbxKillPWD.Text = "00000000";
            this.tbxKillPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxReadAccessPwd_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tbxExtParams);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbxResult);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbxAccessedTag);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(560, 77);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Result";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(227, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "ExtParams";
            // 
            // tbxExtParams
            // 
            this.tbxExtParams.Location = new System.Drawing.Point(300, 43);
            this.tbxExtParams.MaxLength = 8;
            this.tbxExtParams.Name = "tbxExtParams";
            this.tbxExtParams.ReadOnly = true;
            this.tbxExtParams.Size = new System.Drawing.Size(254, 21);
            this.tbxExtParams.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Result";
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(77, 43);
            this.tbxResult.MaxLength = 8;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ReadOnly = true;
            this.tbxResult.Size = new System.Drawing.Size(131, 21);
            this.tbxResult.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "Accessed EPC";
            // 
            // tbxAccessedTag
            // 
            this.tbxAccessedTag.Location = new System.Drawing.Point(126, 20);
            this.tbxAccessedTag.MaxLength = 8;
            this.tbxAccessedTag.Name = "tbxAccessedTag";
            this.tbxAccessedTag.ReadOnly = true;
            this.tbxAccessedTag.Size = new System.Drawing.Size(428, 21);
            this.tbxAccessedTag.TabIndex = 18;
            // 
            // Access
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 570);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpReadMemory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Access";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Access";
            this.Load += new System.EventHandler(this.Access_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Access_FormClosing);
            this.grpReadMemory.ResumeLayout(false);
            this.grpReadMemory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReadLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReadOffset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWriteOffset)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReadMemory;
        private System.Windows.Forms.NumericUpDown numReadLength;
        private System.Windows.Forms.NumericUpDown numReadOffset;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbxReadData;
        private System.Windows.Forms.Label lblReadDataLength;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbxReadAccessPwd;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbxReadMemBank;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numWriteOffset;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox tbxWriteData;
        private System.Windows.Forms.Label lblWriteDataLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxWriteAccessPWD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxWriteMemBank;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxLockAccessPWD;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.CheckBox chkLockUser;
        private System.Windows.Forms.CheckBox chkLockTid;
        private System.Windows.Forms.CheckBox chkLockEpc;
        private System.Windows.Forms.CheckBox chkLockAccessPwd;
        private System.Windows.Forms.CheckBox chkLockKillPwd;
        private System.Windows.Forms.Button btnPermalock;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxKillPWD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxAccessedTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxExtParams;

    }
}