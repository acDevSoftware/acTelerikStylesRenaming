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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace acTelerikStylesRenaming
{
    /// <summary>
    /// Main application to build Telerik Styles assembly.
    /// </summary>
    public class acTelerikStylesRenamingApplication : IInitializeDispose
    {
        private Form m_nMainForm = null;

        private NewSkinGenerator m_nNewSkinGenerator = null;
        private NewSkinZipGenerator m_nNewSkinZipGenerator = null;
        private XmlSettings m_nXmlSettings = null;
        private ApplicationSettings m_nApplicationSettings = null;

        public acTelerikStylesRenamingApplication()
        {
            SetupInternal();

            SetupUI();
        }

        private void SetupInternal()
        {
            m_nXmlSettings = new XmlSettings();
            m_nApplicationSettings = new ApplicationSettings();
            m_nNewSkinGenerator = new NewSkinGenerator();
            m_nNewSkinZipGenerator = new NewSkinZipGenerator();
        }

        private void SetupUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }


        private void InitializeNewSkinGenerator()
        {
            m_nNewSkinGenerator.Initialize();
            m_nNewSkinZipGenerator.Initialize();
        }

        public void Initialize()
        {
            InitializeNewSkinGenerator();
        }

        private void DisposeNewSkinGenerator()
        {
            m_nNewSkinGenerator.Dispose();
            m_nNewSkinZipGenerator.Dispose();
        }

        public void Dispose()
        {
            DisposeNewSkinGenerator();
        }

        private T GetAssemblyInformation<T>() where T : Attribute
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false);
            if (attributes.Length == 0)
                return null;
            else
                return (T)attributes[0];
        }

        public string AssemblyTitle
        {
            get
            {
                AssemblyTitleAttribute nAssemblyTitleAttribute = GetAssemblyInformation<AssemblyTitleAttribute>();

                if (nAssemblyTitleAttribute != null && !string.IsNullOrEmpty(nAssemblyTitleAttribute.Title))
                    return nAssemblyTitleAttribute.Title;
                else
                    return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                AssemblyDescriptionAttribute nAssemblyDescriptionAttribute = GetAssemblyInformation<AssemblyDescriptionAttribute>();

                if (nAssemblyDescriptionAttribute != null)
                    return nAssemblyDescriptionAttribute.Description;
                else
                    return string.Empty;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                AssemblyProductAttribute nAssemblyProductAttribute = GetAssemblyInformation<AssemblyProductAttribute>();

                if (nAssemblyProductAttribute != null)
                    return nAssemblyProductAttribute.Product;
                else
                    return string.Empty;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                AssemblyCopyrightAttribute nAssemblyCopyrightAttribute = GetAssemblyInformation<AssemblyCopyrightAttribute>();

                if (nAssemblyCopyrightAttribute != null)
                    return nAssemblyCopyrightAttribute.Copyright;
                else
                    return string.Empty;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                AssemblyCompanyAttribute nAssemblyCompanyAttribute = GetAssemblyInformation<AssemblyCompanyAttribute>();

                if (nAssemblyCompanyAttribute != null)
                    return nAssemblyCompanyAttribute.Company;
                else
                    return string.Empty;
            }
        }

        public string AssemblyDate
        {
            get
            {
                AssemblyConfigurationAttribute nAssemblyConfigurationAttribute = GetAssemblyInformation<AssemblyConfigurationAttribute>();

                if (nAssemblyConfigurationAttribute != null)
                    return nAssemblyConfigurationAttribute.Configuration;
                else
                    return string.Empty;
            }
        }

        public NewSkinGenerator NewSkinGenerator
        {
            get { return m_nNewSkinGenerator; }
        }

        public NewSkinZipGenerator NewSkinZipGenerator
        {
            get { return m_nNewSkinZipGenerator; }
        }

        public XmlSettings XmlSettings
        {
            get { return m_nXmlSettings; }
            set { if (value != null) m_nXmlSettings = value; }
        }

        public ApplicationSettings ApplicationSettings
        {
            get { return m_nApplicationSettings; }
            set { if (value != null) m_nApplicationSettings = value; }
        }

        public string ApplicationPath
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath); }
        }

        public void RunApp()
        {
            m_nMainForm = new MainForm();
            
            Application.Run(m_nMainForm);
        }


    }
}
