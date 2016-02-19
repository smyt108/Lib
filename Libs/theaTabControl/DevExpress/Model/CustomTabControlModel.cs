using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DevExpress.Model
{
    public class CustomTabControlModel
    {
        private ObservableCollection<TabModel> listTabItem;
        public ObservableCollection<TabModel> ListTabItem
        {
            get
            {
                if (listTabItem == null)
                {
                    listTabItem = new ObservableCollection<TabModel>();
                    var itemsView = (IEditableCollectionView)CollectionViewSource.GetDefaultView(listTabItem);
                    itemsView.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
                }

                return listTabItem;
            }
        }
    }
}
