using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TasksManager.DataModel
{
    [XmlRoot("ExecConfigurations")]
    public class ExecConfigurationsModel
    {
        [XmlArray("ExecCollection")]
        [XmlArrayItem("Exec")]
        public List<ExecInfoModel> ExecCollection { get; set; }

        [XmlArray("DailyExecCollection")]
        [XmlArrayItem("DailyExec")]
        public List<DailyExecInfoModel> DailyExecCollection { get; set; }

        [XmlArray("IntervalExecCollection")]
        [XmlArrayItem("IntervalExec")]
        public List<IntervalExecInfoModel> IntervalExecCollection { get; set; }
    }
}
