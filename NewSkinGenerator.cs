/*
 * Copyright (c) 2013 acDevSoftware
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Web.UI;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;


namespace acTelerikStylesRenaming
{
    /// <summary>
    /// Generates a new named Skin from a Telerik Skin.
    /// </summary>
    public class NewSkinGenerator : ProgressHandler, IInitializeDispose
    {
        public const string PROCESS_CODE = "NewSkinGenerator";
        public const string EXTENSIONFILE_CSS = ".css";
        public const string MIMETYPE_TEXTCSS = "text/css";

        private const string COMMON_FOLDERNAME = "Common";
        private const string SKINLITE_SUFFIX = "Lite";

        private const string PROCESSSKINFILEDIRECTORY_INITIALIZE = "{0}: New skin {1} initialized from '{2}' in '{3}'\r\n";
        private const string PROCESSSKINFILEDIRECTORY_COMPLETE = "{0}: New skin {1} completed from '{2}' in '{3}'\r\n";
        private const string PROCESSSKINFILE_COPYFILE_FORMAT = "{0}: File '{1}' copied";
        private const string PROCESSSKINFILE_COPYCSSFILE_FORMAT = "{0}: CSS File '{1}' created";
        private const string PROCESSSKINDIRECTORY_CREATEDIRECTORY_FORMAT = "{0}: Directory '{1}' created";

        private readonly Dictionary<string, string> m_nMimeTypes = new Dictionary<string, string>() {
            { EXTENSIONFILE_CSS, MIMETYPE_TEXTCSS },
            { ".jpg", "image/jpg" },
            { ".gif", "image/gif" },
            { ".png", "image/png" },
            { ".ico", "image/x-icon" },
            { ".cur", "image/x-icon" }
        };

        public void  Initialize()
        {
        }

        public void  Dispose()
        {
        }

        private string GetMimeTypeFromAcceptedExtension(string sFileExtension)
        {
            if (!m_nMimeTypes.ContainsKey(sFileExtension))
                return string.Empty;

            return m_nMimeTypes[sFileExtension];
        }

        private void ProcessSkinFile(DirectoryInfo nNewSkinParentDirectory, string sNewSkinName, string sTelerikSkinName, DirectoryInfo nTelerikSkinParentDirectory)
        {
            // Correct for Lite skin
            CorrectTelerikSkinLiteName(ref sTelerikSkinName);
            CorrectTelerikSkinLiteName(ref sNewSkinName);
            
            FileInfo[] nTelerikSkinSkinFiles = nTelerikSkinParentDirectory.GetFiles();

            foreach (FileInfo nTelerikSkinFile in nTelerikSkinSkinFiles)
            {
                string sMimeType = GetMimeTypeFromAcceptedExtension(nTelerikSkinFile.Extension);

                if (!string.IsNullOrEmpty(sMimeType))
                {
                    string sNewSkinFileName = nTelerikSkinFile.Name.Replace(sTelerikSkinName, sNewSkinName),
                           sNewSkinPathFileName = Path.Combine(nNewSkinParentDirectory.FullName, sNewSkinFileName);

                    if (string.Compare(nTelerikSkinFile.Extension, EXTENSIONFILE_CSS, true) == 0)
                    {
                        File.WriteAllText(sNewSkinPathFileName, Regex.Replace(File.ReadAllText(nTelerikSkinFile.FullName), string.Format("(?i:{0})", sTelerikSkinName), sNewSkinName));

                        OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINFILE_COPYCSSFILE_FORMAT, PROCESS_CODE, sNewSkinFileName)));
                    }
                    else
                    {
                        FileInfo nNewSkinFile = nTelerikSkinFile.CopyTo(sNewSkinPathFileName, true);

                        OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINFILE_COPYFILE_FORMAT, PROCESS_CODE, Path.Combine(nNewSkinParentDirectory.Name, nNewSkinFile.Name))));
                    }
                }
                else
                    OnProgressProcessing(new ProgressProcessingEventArg(string.Format("No mime type for extension {0}", nTelerikSkinFile.Extension)));
            }
        }

        private void ProcessSkinDirectory(DirectoryInfo nNewSkinParentDirectory, string sNewSkinName, string sTelerikSkinName, DirectoryInfo nTelerikSkinParentDirectory)
        {
            DirectoryInfo[] nTelerikSkinSubDirectories = nTelerikSkinParentDirectory.GetDirectories();

            foreach (DirectoryInfo nTelerikSkinDirectory in nTelerikSkinSubDirectories)
            {
                DirectoryInfo nNewSkinDirectory = nNewSkinParentDirectory.CreateSubdirectory(nTelerikSkinDirectory.Name);

                OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINDIRECTORY_CREATEDIRECTORY_FORMAT, PROCESS_CODE, nNewSkinDirectory.Name)));

                ProcessSkinDirectory(nNewSkinDirectory, sNewSkinName, sTelerikSkinName, nTelerikSkinDirectory);
            }

            ProcessSkinFile(nNewSkinParentDirectory, sNewSkinName, sTelerikSkinName, nTelerikSkinParentDirectory);
        }

        private bool CorrectTelerikSkinLiteName(ref string sTelerikSkinName)
        {
            if (sTelerikSkinName.EndsWith(SKINLITE_SUFFIX))
            {
                sTelerikSkinName = sTelerikSkinName.Substring(0, sTelerikSkinName.Length - SKINLITE_SUFFIX.Length);

                return true;
            }
            else
                return false;
        }

        private bool CorrectNewSkinLiteName(ref string sNewSkinName, string sTelerikSkinName)
        {
            if (sTelerikSkinName.EndsWith(SKINLITE_SUFFIX))
            {
                if (!sNewSkinName.EndsWith(SKINLITE_SUFFIX))
                    sNewSkinName = string.Concat(sNewSkinName, SKINLITE_SUFFIX);

                return true;
            }
            else
                return false;
        }

        private void ProcessSkinFileDirectory(ref string sNewSkinName, string sTelerikSkinDirectory, string sOutputDirectory)
        {
            bool correctNewSkinLiteName = CorrectNewSkinLiteName(ref sNewSkinName, sTelerikSkinDirectory);

            DirectoryInfo nNewSkinDirectory = FileDirUtilities.CreateSubDirectory(sOutputDirectory, sNewSkinName),
                          nTelerikSkinDirectory = FileDirUtilities.GetDirectory(sTelerikSkinDirectory);

            OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINFILEDIRECTORY_INITIALIZE, PROCESS_CODE, sNewSkinName, nTelerikSkinDirectory.FullName, nNewSkinDirectory.FullName)));

            // Copy Common Skins folder only if no Lite Skin
            if (!correctNewSkinLiteName)
            {
                DirectoryInfo nNewCommonSkinDirectory = FileDirUtilities.CreateSubDirectory(nNewSkinDirectory.FullName, COMMON_FOLDERNAME),
                              nTelerikCommonSkinsDirectory = FileDirUtilities.GetDirectory(Path.Combine(FileDirUtilities.GetParentDirectory(sTelerikSkinDirectory).FullName, COMMON_FOLDERNAME));

                ProcessSkinDirectory(nNewCommonSkinDirectory, sNewSkinName, nTelerikSkinDirectory.Name, nTelerikCommonSkinsDirectory);
            }

            // Copy Skin folder
            ProcessSkinDirectory(nNewSkinDirectory, sNewSkinName, nTelerikSkinDirectory.Name, nTelerikSkinDirectory);

            OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINFILEDIRECTORY_COMPLETE, PROCESS_CODE, sNewSkinName, nTelerikSkinDirectory.FullName, nNewSkinDirectory.FullName)));
        }

        public string Generate(string sNewSkinName, string sTelerikSkinDirectory, string sOutputDirectory)
        {
            try
            {
                OnProgressStatus(new ProgressStatusEventArg(PROCESS_CODE, ProgressStatusEventArg.StatusType.STATUS_INITIALIZED));

                ProcessSkinFileDirectory(ref sNewSkinName, sTelerikSkinDirectory, sOutputDirectory);

                OnProgressStatus(new ProgressStatusEventArg(PROCESS_CODE, ProgressStatusEventArg.StatusType.STATUS_COMPLETED, sNewSkinName));
            }
            catch
            {
                OnProgressStatus(new ProgressStatusEventArg(PROCESS_CODE, ProgressStatusEventArg.StatusType.STATUS_ERROR));

                throw;
            }

            return sNewSkinName;
        }
    }
}
