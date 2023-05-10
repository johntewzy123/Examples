using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using com.atid.lib.diagnostics;
using com.atid.lib.types;
using com.atid.lib.reader;
using com.atid.lib.reader.events;
using com.atid.lib.reader.types;
using com.atid.lib.module.rfid.uhf.events;
using com.atid.lib.module.rfid.uhf.parameters;
using com.atid.lib.module.rfid.uhf.types;
using com.atid.lib.transport.types;

namespace BasicOperation
{
    public partial class Access : Form, IATEAReaderEventListener, IATRfidUhfEventListener
    {
        private readonly String TAG;
        private String mTargetTag = String.Empty;
        private ATEAReader mReader = null;
        private LockState mLockState = LockState.NoChanged;
        private ActionState mAction = ActionState.Stop;
        private const int NUD_MIN = 0;
        private const int NUD_MAX = 255;
        private const int NUD_OFFSET_DEFAULT = 2;
        private const int NUD_LENGTH_DEFAULT = 6;
        private const int MAX_MASK_COUNT = 8;
        private const int MAX_PATTERN_LENGTH = 32;
        private SelectMask6cParam[] mBackupSelectMask;
        private SelectFlag mBackupSelectFlag;
        private SessionFlag mBackupSessionFlag;
        private SessionTarget mBackupSessionTarget;
        private bool mContinuousMode;
        private bool mPropertiesRestored;

        public delegate void EnableButtonsHandler(bool enabled);

        public Access()
        {
            InitializeComponent();
            TAG = typeof(Access).Name;
        }

        public ATEAReader Reader
        {
            set { mReader = value; }
        }

        public String TargetTag
        {
            set { mTargetTag = value; }
        }

        private void Access_Load(object sender, EventArgs e)
        {
            foreach (BankType b in Enum.GetValues(typeof(BankType)))
            {
                cbxReadMemBank.Items.Add(b);
                cbxWriteMemBank.Items.Add(b);
            }
            cbxReadMemBank.SelectedItem = BankType.EPC;
            cbxWriteMemBank.SelectedItem = BankType.EPC;

            numReadOffset.Minimum = NUD_MIN;
            numReadOffset.Maximum = NUD_MAX;
            numReadOffset.Value = NUD_OFFSET_DEFAULT;
            numWriteOffset.Minimum = NUD_MIN;
            numWriteOffset.Maximum = NUD_MAX;
            numWriteOffset.Value = NUD_OFFSET_DEFAULT;
            numReadLength.Minimum = NUD_MIN + 1;
            numReadLength.Maximum = NUD_MAX;
            numReadLength.Value = NUD_LENGTH_DEFAULT;

            if (mReader != null)
            {
                mReader.addListener(this);
                if (mReader.getRfidUhf() != null)
                    mReader.getRfidUhf().addListener(this);
            }

            EnableButtons(false);
            ThreadPool.QueueUserWorkItem(BeginBackupProperties);
        }

        private void BeginBackupProperties(Object obj)
        {
            bool result = true;

            try
            {
                mContinuousMode = mReader.getRfidUhf().getContinuousMode();
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("BeginBackupProperties : {0}", ae.getCode().toString()));
                result = false;
            }

            Invoke(new Action<Object>(EndBackupProperties), result);
        }

        private void EndBackupProperties(Object obj)
        {
            bool result = (bool)obj;
            System.Diagnostics.Trace.WriteLine("EndBackupProperties : " + result);
            mPropertiesRestored = false;
            EnableButtons(true);
        }

        private void Access_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mPropertiesRestored)
            {
                e.Cancel = true;
                EnableButtons(false);
                ThreadPool.QueueUserWorkItem(BeginRestoreProperties);
                return;
            }
        }

        private void BeginRestoreProperties(Object obj)
        {
            bool result = true;

            try
            {
                if (mReader.getAction() != ActionState.Stop)
                    mReader.getRfidUhf().stop();

                while (mReader.getAction() != ActionState.Stop)
                    Thread.Sleep(100);
                
                mReader.getRfidUhf().setContinuousMode(mContinuousMode);
            }
            catch (ATException ae)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("BeginRestoreProperties : {0}", ae.getCode().toString()));
                result = false;
            }

            Invoke(new Action<Object>(EndRestoreProperties), result);
        }
        private void EndRestoreProperties(Object obj)
        {
            bool result = (bool)obj;
            System.Diagnostics.Trace.WriteLine("EndRestoreProperties : " + result);
            EnableButtons(true);

            mReader.getRfidUhf().removeListener(this);
            mReader.removeListener(this);
            mPropertiesRestored = true;

            this.Close();
        }

        private void BeginBackupMask(Object obj)
        {
            mBackupSelectMask = new SelectMask6cParam[MAX_MASK_COUNT];
            int index = 0;

            for (index = 0; index < MAX_MASK_COUNT; index++)
            {
                mBackupSelectMask[index] = mReader.getRfidUhf().getSelectMask6c(index);
            }
            mBackupSelectFlag = mReader.getRfidUhf().getSelectFlag();
            mBackupSessionTarget = mReader.getRfidUhf().getSessionTarget();
            mBackupSessionFlag = mReader.getRfidUhf().getSessionFlag();

            for (index = 0; index < MAX_MASK_COUNT; index++)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("{0}, {1}", index, mBackupSelectMask[index].isUsed()));
            }

            int len = MAX_PATTERN_LENGTH * 2;
            String maskPattern = mTargetTag.Length > len ? mTargetTag.Substring(0, len) : mTargetTag;

            SelectMask6cParam maskParam = new SelectMask6cParam(true,
                                                                Mask6cTarget.SL,
                                                                Mask6cAction.AB,
                                                                BankType.EPC,
                                                                16,
                                                                maskPattern,
                                                                maskPattern.Length * 4);
            mReader.getRfidUhf().setSelectMask6c(0, maskParam);
            mReader.getRfidUhf().setSelectFlag(SelectFlag.SL);

            bool result = true;

            Invoke(new Action<Object>(EndBackupMask), result);
        }

        private void EndBackupMask(Object obj)
        {
            bool result = (bool)obj;
            System.Diagnostics.Trace.WriteLine("BeginInitMask : " + result);
            EnableButtons(true);
        }

        private void BeginRestoreMask(Object obj)
        {


            bool result = true;

            Invoke(new Action<Object>(EndRestoreMask), result);
        }

        private void EndRestoreMask(Object obj)
        {

            this.mTargetTag = String.Empty;
            this.Close();
        }

        private void EnableButtons(bool enabled)
        {
            if (InvokeRequired)
            {
                EnableButtonsHandler d = new EnableButtonsHandler(EnableButtons);
                BeginInvoke(d, new object[] { enabled });
                return;
            }

            if (enabled)
            {
                switch (mAction)
                {
                    case com.atid.lib.types.ActionState.ReadMemory6c:
                        btnRead.Enabled = enabled;
                        break;
                    case com.atid.lib.types.ActionState.WriteMemory6c:
                        btnWrite.Enabled = enabled;
                        break;
                    case com.atid.lib.types.ActionState.Lock:
                        if (mLockState == LockState.Lock)
                            btnLock.Enabled = enabled;
                        else if (mLockState == LockState.Unlock)
                            btnUnlock.Enabled = enabled;
                        break;
                    case com.atid.lib.types.ActionState.PermaLock:
                        btnPermalock.Enabled = enabled;
                        break;
                    case com.atid.lib.types.ActionState.Kill:
                        btnKill.Enabled = enabled;
                        break;
                    case com.atid.lib.types.ActionState.Stop:
                        cbxReadMemBank.Enabled =
                        numReadOffset.Enabled =
                        numReadLength.Enabled =
                        tbxReadAccessPwd.Enabled =
                        btnRead.Enabled =
                        cbxWriteMemBank.Enabled =
                        numWriteOffset.Enabled =
                        tbxWriteAccessPWD.Enabled =
                        btnWrite.Enabled =
                        tbxWriteData.Enabled =
                        chkLockKillPwd.Enabled =
                        chkLockAccessPwd.Enabled =
                        chkLockEpc.Enabled =
                        chkLockTid.Enabled =
                        chkLockUser.Enabled =
                        tbxLockAccessPWD.Enabled =
                        btnLock.Enabled =
                        btnUnlock.Enabled =
                        btnPermalock.Enabled =
                        tbxKillPWD.Enabled =
                        btnKill.Enabled = enabled;
                        break;
                }
            }
            else
            {
                cbxReadMemBank.Enabled =
                numReadOffset.Enabled =
                numReadLength.Enabled =
                tbxReadAccessPwd.Enabled =
                btnRead.Enabled =
                cbxWriteMemBank.Enabled =
                numWriteOffset.Enabled =
                tbxWriteAccessPWD.Enabled =
                btnWrite.Enabled =
                tbxWriteData.Enabled =
                chkLockKillPwd.Enabled =
                chkLockAccessPwd.Enabled =
                chkLockEpc.Enabled =
                chkLockTid.Enabled =
                chkLockUser.Enabled =
                tbxLockAccessPWD.Enabled =
                btnLock.Enabled =
                btnUnlock.Enabled =
                btnPermalock.Enabled =
                tbxKillPWD.Enabled =
                btnKill.Enabled = false;
            }
        }

        private void tbxWriteData_TextChanged(object sender, EventArgs e)
        {
            int len = tbxWriteData.Text.Length;
            lblWriteDataLength.Text = string.Format("Data ( {0} )", len == 0 ? "0 bit" : string.Format("{0} bits", len * 4));
        }

        private void tbxReadAccessPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Helper.IsValidChar(e.KeyChar))
                e.Handled = true;
        }

        private void ClearResult()
        {
            tbxResult.Text = String.Empty;
            tbxReadData.Text = String.Empty;
            tbxExtParams.Text = String.Empty;
            lblReadDataLength.Text = "Data ( 0 bit )";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            EnableButtons(false);
            if (mAction != com.atid.lib.types.ActionState.Stop)
            {
                mReader.getRfidUhf().stop();
            }
            else
            {
                ClearResult();

                BankType bank = (BankType)EnumExtension.valueOf(typeof(BankType), cbxReadMemBank.SelectedIndex);
                int offset = (int)numReadOffset.Value;
                int length = (int)numReadLength.Value;
                String password = tbxReadAccessPwd.Text.Trim();
                ResultCode res;

                try
                {
                    res = mReader.getRfidUhf().readMemory6c(bank, offset, length, password);
                    if (res != ResultCode.NoError)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("readMemory6c - [{0}]", res.toString()));
                        mReader.getRfidUhf().stop();
                        EnableButtons(true);
                    }
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. readMemory6c - {0}", ae.getCode().toString()));
                }
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (mReader == null)
                return;

            EnableButtons(false);
            if (mAction != com.atid.lib.types.ActionState.Stop)
            {
                mReader.getRfidUhf().stop();
            }
            else
            {
                ClearResult();

                BankType bank = (BankType)EnumExtension.valueOf(typeof(BankType), cbxWriteMemBank.SelectedIndex);
                int offset = (int)numWriteOffset.Value;
                String data = tbxWriteData.Text.Trim();
                String password = tbxWriteAccessPWD.Text.Trim();
                ResultCode res;

                try
                {
                    res = mReader.getRfidUhf().writeMemory6c(bank, offset, data, password);
                    if (res != ResultCode.NoError)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("writeMemory6c - [{0}]", res.toString()));
                        mReader.getRfidUhf().stop();
                        EnableButtons(true);
                    }
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. writeMemory6c - {0}", ae.getCode().toString()));
                }
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (mAction != com.atid.lib.types.ActionState.Stop)
            {
                mReader.getRfidUhf().stop();
                System.Diagnostics.Trace.WriteLine("INFO. stop lock6c lock");
            }
            else
            {
                mLockState = LockState.Lock;
                EnableButtons(false);
                ClearResult();
                ResultCode res;
                Lock6cParam param = new Lock6cParam(chkLockKillPwd.Checked ? LockState.Lock : LockState.NoChanged,
                                                    chkLockAccessPwd.Checked ? LockState.Lock : LockState.NoChanged,
                                                    chkLockEpc.Checked ? LockState.Lock : LockState.NoChanged,
                                                    chkLockTid.Checked ? LockState.Lock : LockState.NoChanged,
                                                    chkLockUser.Checked ? LockState.Lock : LockState.NoChanged);
                String password = tbxLockAccessPWD.Text.Trim();

                try
                {
                    if ((res = mReader.getRfidUhf().lock6c(param, password)) != ResultCode.NoError)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("ERROR. lock6c lock - [{0}], {1}, {2}", res.toString(), param, password));
                        mReader.getRfidUhf().stop();
                        return;
                    }

                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. lock6c - {0}, {1}", param, password));
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. lock6c lock - {0}", ae.getCode().toString()));
                }
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (mAction != com.atid.lib.types.ActionState.Stop)
            {
                mReader.getRfidUhf().stop();
                System.Diagnostics.Trace.WriteLine("INFO. stop lock6c unlock");
            }
            else
            {
                mLockState = LockState.Unlock;
                EnableButtons(false);
                ClearResult();
                ResultCode res;
                Lock6cParam param = new Lock6cParam(chkLockKillPwd.Checked ? LockState.Unlock : LockState.NoChanged,
                                                    chkLockAccessPwd.Checked ? LockState.Unlock : LockState.NoChanged,
                                                    chkLockEpc.Checked ? LockState.Unlock : LockState.NoChanged,
                                                    chkLockTid.Checked ? LockState.Unlock : LockState.NoChanged,
                                                    chkLockUser.Checked ? LockState.Unlock : LockState.NoChanged);
                String password = tbxLockAccessPWD.Text.Trim();

                try
                {
                    if ((res = mReader.getRfidUhf().lock6c(param, password)) != ResultCode.NoError)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("ERROR. lock6c unlock - [{0}], {1}, {2}", res.toString(), param, password));
                        mReader.getRfidUhf().stop();
                        return;
                    }

                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. lock6c - {0}, {1}", param, password));
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. lock6c unlock - {0}", ae.getCode().toString()));
                }
            }
        }

        private void btnPermalock_Click(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (mAction != com.atid.lib.types.ActionState.Stop)
            {
                mReader.getRfidUhf().stop();
                System.Diagnostics.Trace.WriteLine("INFO. stop permaLock6c");
            }
            else
            {
                EnableButtons(false);
                ClearResult();
                ResultCode res;
                PermaLock6cParam param = new PermaLock6cParam(chkLockKillPwd.Checked ? PermalockState.PermalLock : PermalockState.NoChanged,
                                                              chkLockAccessPwd.Checked ? PermalockState.PermalLock : PermalockState.NoChanged,
                                                              chkLockEpc.Checked ? PermalockState.PermalLock : PermalockState.NoChanged,
                                                              chkLockTid.Checked ? PermalockState.PermalLock : PermalockState.NoChanged,
                                                              chkLockUser.Checked ? PermalockState.PermalLock : PermalockState.NoChanged);
                String password = tbxLockAccessPWD.Text.Trim();

                try
                {
                    if ((res = mReader.getRfidUhf().permaLock6c(param, password)) != ResultCode.NoError)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("ERROR. permaLock6c - [{0}], {1}, {2}", res.toString(), param, password));
                        mReader.getRfidUhf().stop();
                        return;
                    }

                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. permaLock6c - {0}, {1}", param, password));
                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. permaLock6c - {0}", ae.getCode().toString()));
                }
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (mReader.getRfidUhf() == null)
                return;

            if (mAction != com.atid.lib.types.ActionState.Stop)
            {
                mReader.getRfidUhf().stop();
                System.Diagnostics.Trace.WriteLine("INFO. stop kill6c");
            }
            else
            {
                EnableButtons(false);
                ClearResult();
                ResultCode res;
                String password = tbxKillPWD.Text.Trim();

                try
                {
                    if ((res = mReader.getRfidUhf().kill6c(password)) != ResultCode.NoError)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("ERROR. kill6c - [{0}], {1}", res.toString(), password));
                        mReader.getRfidUhf().stop();
                        return;
                    }
                    System.Diagnostics.Trace.WriteLine(String.Format("INFO. kill6c - {0}", password));

                }
                catch (ATException ae)
                {
                    System.Diagnostics.Trace.WriteLine(String.Format("ERROR. kill6c - {0}", ae.getCode().toString()));
                }
            }
        }
    }
}
