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
using System.Windows.Forms;

namespace acTelerikStylesRenaming
{
    static class Program
    {
        private static acTelerikStylesRenamingApplication _acTelerikStylesRenamingApplication = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                _acTelerikStylesRenamingApplication = new acTelerikStylesRenamingApplication();
                _acTelerikStylesRenamingApplication.Initialize();

                _acTelerikStylesRenamingApplication.RunApp();
            }
            catch (Exception)
            {
            }
            finally
            {
                try
                {
                    if (_acTelerikStylesRenamingApplication != null)
                        _acTelerikStylesRenamingApplication.Dispose();
                }
                catch
                {
                }
            }            
        }

        public static acTelerikStylesRenamingApplication Application
        {
            get { return _acTelerikStylesRenamingApplication; }
        }
    }
}
