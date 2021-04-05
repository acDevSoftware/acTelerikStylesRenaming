/*
 * Copyright (c) 2012 acDevSoftware
 * http://www.acdevsoftware.ch
 * 
 * This file is part of acTelerikStylesRenaming.
 *
 * acTelerikStylesRenaming is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * acTelerikStylesRenaming is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.

 * You should have received a copy of the GNU Lesser General Public License
 * along with acTelerikStylesRenaming.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * 
 * */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace acTelerikStylesRenaming
{
    public partial class MainForm : Form
    {
        private string m_sApplicationSettingsSaveFilename = XmlSettings.FILENAME;
        private string m_sApplicationSettingsLoadFilename = XmlSettings.FILENAME;

        public MainForm()
        {
            InitializeComponent();

            SetupInternal();
            SetupWindow();
            SetupControls();
        }

        private void SetupInternal()
        {
            Program.Application.NewSkinGenerator.ProgressProcessing += new NewSkinGenerator.ProgressProcessingHandler(ProgressProcessing_OnProgress);
            Program.Application.NewSkinGenerator.ProgressStatus += new NewSkinGenerator.ProgressStatusHandler(ProgressProcessing_OnStatus);

            Program.Application.NewSkinZipGenerator.ProgressProcessing += new NewSkinZipGenerator.ProgressProcessingHandler(ProgressProcessing_OnProgress);
            Program.Application.NewSkinZipGenerator.ProgressStatus += new NewSkinZipGenerator.ProgressStatusHandler(ProgressProcessing_OnStatus);        
        }

        private void SetupWindow()
        {
            this.Text = string.Format("{0} v{1}", Program.Application.AssemblyTitle, Program.Application.AssemblyVersion);
        }

        private void SetupControls()
        {
            LoadSettingsToControls();
            HandleEnableControls();
        }

        private void LoadSettingsToControls()
        {
            try
            {
                txtBrowseOutputDirectory.Text = Program.Application.XmlSettings.OutputDirectory;
                txtNewSkinName.Text = Program.Application.XmlSettings.NewSkinName;
                txtBrowseTelerikSkinDirectory.Text = Program.Application.XmlSettings.TelerikSkinPath;
                chkGenerateZipSkin.Checked = Program.Application.XmlSettings.IsZipSkinFile;

                if (string.IsNullOrEmpty(txtBrowseTelerikSkinDirectory.Text))
                    txtBrowseTelerikSkinDirectory.Text = Program.Application.ApplicationSettings.TelerikSkinsPath;

            }
            catch
            {
            }
        }

        private void SaveSettingsFromControls()
        {
            try
            {
                Program.Application.XmlSettings.OutputDirectory = txtBrowseOutputDirectory.Text;
                Program.Application.XmlSettings.NewSkinName = txtNewSkinName.Text;
                Program.Application.XmlSettings.TelerikSkinPath = txtBrowseTelerikSkinDirectory.Text;
                Program.Application.XmlSettings.IsZipSkinFile = chkGenerateZipSkin.Checked;
            }
            catch
            {
            }
        }

        private void HandleEnableControls()
        {
            
        }

        private void LogText(string sText)
        {
            txtLogger.Text = string.Concat(txtLogger.Text, string.Format("{0}\r\n", sText));
            UIUtilities.TextBox_ScrollToBottom(txtLogger);
        }

        private void LogException(Exception nException)
        {
            LogText(string.Format("ERROR: {0}", nException.Message));
        }

        private void ClearLog()
        {
            txtLogger.Clear();
        }

        private void ClearStatus()
        {
            tslStatus.Text = string.Empty;
        }

        private void btnBrowseOutputDirectory_Click(object sender, EventArgs e)
        {
            fbdOutputDirectory.SelectedPath = txtBrowseOutputDirectory.Text;

            if (fbdOutputDirectory.ShowDialog() == DialogResult.OK)
            {
                txtBrowseOutputDirectory.Text = fbdOutputDirectory.SelectedPath;
            }
        }

        private void btnBrowseTelerikSkinDirectory_Click(object sender, EventArgs e)
        {
            fbdTelerikSkinDirectory.SelectedPath = txtBrowseTelerikSkinDirectory.Text;

            if (fbdTelerikSkinDirectory.ShowDialog() == DialogResult.OK)
            {
                txtBrowseTelerikSkinDirectory.Text = fbdTelerikSkinDirectory.SelectedPath;
            }
        }

        private void txtBrowseOutputDirectory_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrowseOutputDirectory.Text))
            {
                errGenerateAssembly.SetError(txtBrowseOutputDirectory, "Output Directory cannot be empty");

                e.Cancel = true;
            }
            else
                errGenerateAssembly.SetError(txtBrowseOutputDirectory, string.Empty);
        }

        private void txtNewSkinName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewSkinName.Text))
            {
                errGenerateAssembly.SetError(txtNewSkinName, "New Skin Name cannot be empty");

                e.Cancel = true;
            }
            else if (txtNewSkinName.Text.Contains('.'))
            {
                errGenerateAssembly.SetError(txtNewSkinName, "New Skin Name cannot contain a . character");

                e.Cancel = true;
            }
            else
                errGenerateAssembly.SetError(txtNewSkinName, string.Empty);
        }

        private void txtBrowseTelerikSkinDirectory_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrowseTelerikSkinDirectory.Text))
            {
                errGenerateAssembly.SetError(txtBrowseTelerikSkinDirectory, "Skin Directory cannot be empty");

                e.Cancel = true;
            }
            else
                errGenerateAssembly.SetError(txtBrowseTelerikSkinDirectory, string.Empty);
        }

        private void btnGenerateNewSkin_Click(object sender, EventArgs e)
        {
            btnGenerateNewSkin.Enabled = false;

            try
            {
                if (ValidateChildren())
                {
                    try
                    {
                        string sNewSkinName = Program.Application.NewSkinGenerator.Generate(txtNewSkinName.Text, txtBrowseTelerikSkinDirectory.Text, txtBrowseOutputDirectory.Text);

                        if(chkGenerateZipSkin.Checked)
                            Program.Application.NewSkinZipGenerator.Generate(sNewSkinName, txtBrowseOutputDirectory.Text);

                    }
                    catch(Exception nException)
                    {
                        LogException(nException);
                    }
                }
            }
            catch (Exception nException)
            {
                LogException(nException);
            }
            finally
            {
                btnGenerateNewSkin.Enabled = true;
            }
        }

        private void ProgressProcessing_OnProgress(object sender, ProgressProcessingEventArg e)
        {
            LogText(e.ProgressInfo);

            Application.DoEvents();
        }

        private void ProgressProcessing_OnStatus(object sender, ProgressStatusEventArg e)
        {
            string sStatusText = string.Empty;

            if (string.Compare(e.Code, NewSkinGenerator.PROCESS_CODE, true) == 0)
            {
                switch (e.Status)
                {
                    case ProgressStatusEventArg.StatusType.STATUS_INITIALIZED:
                        sStatusText = "Generation of new skin initialized";
                        break;
                    case ProgressStatusEventArg.StatusType.STATUS_ERROR:
                        sStatusText = "Generation of new skin aborted on error";
                        break;
                    case ProgressStatusEventArg.StatusType.STATUS_COMPLETED:
                        sStatusText = string.Format("Generation  of new skin {0} completed", e.Information);
                        break;
                }
            }
            else if (string.Compare(e.Code, NewSkinZipGenerator.PROCESS_CODE, true) == 0)
            {
                switch (e.Status)
                {
                    case ProgressStatusEventArg.StatusType.STATUS_INITIALIZED:
                        sStatusText = "Zip of new skin initialized";
                        break;
                    case ProgressStatusEventArg.StatusType.STATUS_ERROR:
                        sStatusText = "Zip of new skin aborted on error";
                        break;
                    case ProgressStatusEventArg.StatusType.STATUS_COMPLETED:
                        sStatusText = string.Format("Zip of new skin {0} completed", e.Information);
                        break;
                }
            }

            tslStatus.Text = sStatusText;

            Application.DoEvents();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBoxForm nAboutBoxForm = new AboutBoxForm();
            nAboutBoxForm.ShowDialog();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettingsFromControls();
                
                sfdSettings.FileName = m_sApplicationSettingsSaveFilename;

                if (sfdSettings.ShowDialog() == DialogResult.OK)
                {
                    m_sApplicationSettingsSaveFilename = sfdSettings.FileName;

                    XmlUtilities.SaveObject(sfdSettings.FileName, Program.Application.XmlSettings);
                }
            }
            catch (Exception nException)
            {
                LogException(nException);
            }
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            try
            {
                ofdSettings.FileName = m_sApplicationSettingsLoadFilename;

                if (ofdSettings.ShowDialog() == DialogResult.OK)
                {
                    m_sApplicationSettingsLoadFilename = ofdSettings.FileName;

                    Program.Application.XmlSettings = XmlUtilities.LoadObject<XmlSettings>(ofdSettings.FileName);

                    SetupControls();
                }
            }
            catch (Exception nException)
            {
                LogException(nException);
            }
        }

        private void btnClearLogging_Click(object sender, EventArgs e)
        {
            try
            {
                ClearLog();
                ClearStatus();
            }
            catch
            {
            }
        }


    }
}
