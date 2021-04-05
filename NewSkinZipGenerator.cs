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
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace acTelerikStylesRenaming
{
    public class NewSkinZipGenerator : ProgressHandler, IInitializeDispose
    {
        public const string PROCESS_CODE = "NewSkinZipGenerator";

        private const string PROCESSSKINFILEDIRECTORY_INITIALIZE = "{0}: Zip Skin File {1} initialized\r\n";
        private const string PROCESSSKINFILEDIRECTORY_COMPLETE = "{0}: Zip Skin File {1} completed\r\n";
        private const string PROCESSSKINFILE_CREATEZIPFILE_FORMAT = "{0}: Skin Zip File '{1}' created from {2}";

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

        private void ProcessSkinToZip(ref string sNewSkinName, string sOutputDirectory)
        {
            string sZipSkinPathFileName = Path.Combine(sOutputDirectory, Path.ChangeExtension(sNewSkinName, "zip")),
                   sSkinPathFileName = Path.Combine(sOutputDirectory, sNewSkinName);

            OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINFILEDIRECTORY_INITIALIZE, PROCESS_CODE, sNewSkinName)));

            FastZip nFastZip = new FastZip();

            nFastZip.RestoreAttributesOnExtract = true;
            nFastZip.RestoreDateTimeOnExtract = true;
            nFastZip.CreateEmptyDirectories = true;
            nFastZip.CreateZip(sZipSkinPathFileName, sSkinPathFileName, true, string.Empty);

            OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINFILE_CREATEZIPFILE_FORMAT, PROCESS_CODE, sZipSkinPathFileName, sSkinPathFileName)));
            
            OnProgressProcessing(new ProgressProcessingEventArg(string.Format(PROCESSSKINFILEDIRECTORY_COMPLETE, PROCESS_CODE, sNewSkinName)));
        }

        public void Generate(string sNewSkinName, string sOutputDirectory)
        {
            try
            {
                OnProgressStatus(new ProgressStatusEventArg(PROCESS_CODE, ProgressStatusEventArg.StatusType.STATUS_INITIALIZED));

                ProcessSkinToZip(ref sNewSkinName, sOutputDirectory);

                OnProgressStatus(new ProgressStatusEventArg(PROCESS_CODE, ProgressStatusEventArg.StatusType.STATUS_COMPLETED, sNewSkinName));
            }
            catch
            {
                OnProgressStatus(new ProgressStatusEventArg(PROCESS_CODE, ProgressStatusEventArg.StatusType.STATUS_ERROR));

                throw;
            }
        }


    }
}
