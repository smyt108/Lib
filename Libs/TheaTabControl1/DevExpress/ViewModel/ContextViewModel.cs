using DevExpress.Model;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.ViewModel
{
    public class ContextViewModel : NotificationObject
    {
        private CustomTabControlModel listTab;
        public CustomTabControlModel ListTab
        {
            get { return listTab; }
            set
            {
                if (value != null)
                {
                    listTab = value;
                    RaisePropertyChanged(() => ListTab);
                }
            }
        }
    }
}
