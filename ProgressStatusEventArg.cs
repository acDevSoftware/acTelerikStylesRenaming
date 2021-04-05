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

namespace acTelerikStylesRenaming
{
    public class ProgressStatusEventArg
    {
        public enum StatusType {
            STATUS_ERROR=-1,
            STATUS_NONE,
            STATUS_INITIALIZED,
            STATUS_COMPLETED
        }

        private StatusType m_nStatus;
        private string m_sCode;
        private string m_sInformation;

        public ProgressStatusEventArg(string sCode, StatusType nStatus)
        {
            m_sCode = sCode;
            m_nStatus = nStatus;
        }

        public ProgressStatusEventArg(string sCode, StatusType nStatus, string sInformation)
        {
            m_sCode = sCode;
            m_nStatus = nStatus;
            m_sInformation = sInformation;
        }

        public string Code
        {
            get { return m_sCode; }
        }

        public StatusType Status
        {
            get { return m_nStatus; }
        }

        public string Information
        {
            get { return m_sInformation; }
        }
    }
}
