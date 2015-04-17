using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TasksManager.DataModel
{
    public class IntervalExecInfoModel : ExecInfoModelBase
    {
        [XmlAttribute]
        public int Interval { get; set; }
    }
}
