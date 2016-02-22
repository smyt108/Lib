using DevExpress.Model;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.CommonControls
{
    public class CompositeControlCollection : NotificationObject
    {
        public ObservableCollection<BaseModel> ListBoxItems
        {
            get
            {
                return new ObservableCollection<BaseModel>(dic.Values);
            }
        }

        private Dictionary<string, BaseModel> dic = new Dictionary<string, BaseModel>();

        public void Add(BaseModel model)
        {
            dic.Add(model.UniqId, model);
            RaisePropertyChanged(() => ListBoxItems);
        }

        public T Get<T>(string key)
        {
            return ((CustomerModel<T>)dic[key]).IndicatorValue;
        }

        public void Set<T>(string key, T value)
        {
            ((CustomerModel<T>)dic[key]).IndicatorValue = value;
        }
    }
}
