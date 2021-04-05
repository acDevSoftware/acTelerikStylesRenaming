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
using System.IO;

namespace acTelerikStylesRenaming
{
    public class FileDirUtilities
    {
        public static DirectoryInfo CreateDirectory(string sDirectoryName)
        {
            if (Directory.Exists(sDirectoryName))
                return new DirectoryInfo(sDirectoryName);
            else
                return Directory.CreateDirectory(sDirectoryName);
        }

        public static DirectoryInfo CreateSubDirectory(string sDirectoryName, string sSubDirectoryName)
        {
            return CreateDirectory(Path.Combine(sDirectoryName, sSubDirectoryName));
        }

        public static DirectoryInfo GetDirectory(string sDirectoryName)
        {
            if (!Directory.Exists(sDirectoryName))
                throw new ArgumentException(string.Format("The directory {0} doesn't exist", sDirectoryName));
               
            return new DirectoryInfo(sDirectoryName);
        }

        public static DirectoryInfo GetParentDirectory(string sDirectoryName)
        {
            DirectoryInfo directory = GetDirectory(sDirectoryName);

            return directory.Parent;
        }
    }
}
