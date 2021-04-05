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
using System.Xml.Serialization;

namespace acTelerikStylesRenaming
{
    [XmlRoot("Settings")]
    public class XmlSettings
    {
        public const string FILENAME = "acTelerikStylesRenaming.xml";

        private string m_sOutputDirectory;
        private string m_sNewSkinName;
        private string m_sTelerikSkinPath;
        private List<string> m_nStylesFileNames = new List<string>();
        private bool m_bZipSkinFile;

        public XmlSettings()
        {
        }

        [XmlElement("NewSkinName")]
        public string NewSkinName
        {
            get { return m_sNewSkinName; }
            set { m_sNewSkinName = value; }
        }

        [XmlElement("OutputDirectory")]
        public string OutputDirectory
        {
            get { return m_sOutputDirectory; }
            set { m_sOutputDirectory = value; }
        }

        [XmlElement("TelerikSkinPath")]
        public string TelerikSkinPath
        {
            get { return m_sTelerikSkinPath; }
            set { m_sTelerikSkinPath = value; }
        }

        [XmlElement("IsZipSkinFile")]
        public bool IsZipSkinFile
        {
            get { return m_bZipSkinFile; }
            set { m_bZipSkinFile = value; }
        }
    }
}
