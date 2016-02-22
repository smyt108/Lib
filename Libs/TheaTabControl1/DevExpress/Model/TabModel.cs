using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.Model
{
    public class TabModel : NotificationObject
    {
        private string name = "New Tab \r\n(please rename)";
        private List<object> detailData;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        public List<object> DetailData
        {
            get
            {
                detailData.Add("123");
                detailData.Add("234");
                return detailData;
            }

            set
            {
                if (detailData != value)
                {
                    detailData = value;
                    RaisePropertyChanged(() => DetailData);
                }
            }
        }
    }
}
