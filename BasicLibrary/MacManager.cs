using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace BasicLibrary
{
    public class MacManager
    {
        private static MacManager _instance;

        private MacManager()
        {
        }

        public static MacManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MacManager();
            }

            return _instance;
        }

        #region Public Method(s)

        public string GetLocalMacAddr()
        {
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection mngerObjCollection = managementClass.GetInstances();

            StringBuilder sb = new StringBuilder();

            foreach (ManagementObject obj in mngerObjCollection)
            {
                //If have vitual machine, will get several mac address.
                //One for local Ethernet Adapter address.
                //Others for VM machine.
                if ((bool)obj["IPEnabled"])
                {
                    sb.Append(obj["MacAddress"].ToString());
                }

                obj.Dispose();
            }

            return (sb.ToString());
        }

        #endregion

        #region Private Method(s)

        #endregion
    }
}
