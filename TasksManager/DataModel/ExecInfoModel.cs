using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Globalization;

namespace TasksManager.DataModel
{
    public class ExecInfoModel : ExecInfoModelBase
    {
        [XmlAttribute]
        public string TimeLine { get; set; }
    }
}
