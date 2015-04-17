using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TasksManager.DataModel
{
    public class ExecInfoModelBase
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Path { get; set; }
        [XmlAttribute]
        public string Arguments { get; set; }
    }
}
