using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksManager.DataModel;
using System.Xml;
using System.Xml.Serialization;
using BasicLibrary;

namespace TasksManager
{
    public class ExecConfigReader
    {
        private const string FILE_FULLNAME = "ExecConfigurations.xml";

        private ExecConfigurationsModel _execConfigs;

        private static ExecConfigReader _instance;
        private ExecConfigReader()
        {
            _execConfigs = XMLHelper.XmlDeserializeFromFile<ExecConfigurationsModel>(FILE_FULLNAME, Encoding.UTF8);
        }

        public static ExecConfigReader GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ExecConfigReader();
            }

            return _instance;
        }

        public ExecConfigurationsModel GetExecModelByConfig()
        {
            return _execConfigs;
        }
    }
}
