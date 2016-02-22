using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DevExpress.Model;

namespace DevExpress.ViewModel
{
    public class MainViewModel : NotificationObject
    {
        public MainViewModel()
        {
            students = new ObservableCollection<Student>();
            Student a = new Student { Name = "linbin", Age = 10, City = "Shanghai", School = "SJTU", Sex = "Man", Born = DateTime.Parse("2015-01-02"), Test="Citi"};
            Student b = new Student { Name = "binbin", Age = 10, City = "Beijing", School = "XJTU", Sex = "Woman", Born = DateTime.Parse("2015-01-03"), Test = "CSTC" };
            Student c = new Student { Name = "tong", Age = 10, City = "Shenzhen", School = "Peking", Sex = "Man", Born = DateTime.Parse("2015-01-04"), Test = "Citi" };
            Student d = new Student { Name = "alaass", Age = 10, City = "Guangzhou", School = "Nanjing", Sex = "Woman", Born = DateTime.Parse("2015-01-05"), Test = "GSM" };
            students.Add(a);
            students.Add(b);
            students.Add(c);
            students.Add(d);
            typeList = new List<string> { "Citi", "CSTC", "GSM" };
            
            //queryPanelViewModel = new QueryPanelViewModel();
        }

        //private QueryPanelViewModel queryPanelViewModel;
        //public QueryPanelViewModel QueryPanelViewModel
        //{
        //    get { return queryPanelViewModel; }
        //    set
        //    {
        //        if(value!=queryPanelViewModel)
        //        {
        //            queryPanelViewModel = value;
        //            RaisePropertyChanged("QueryPanelViewModel");
        //        }
        //    }
        //}


        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value != null)
                    this.students = value;
            }
        }

                
        private List<string> typeList;
        public List<string> TypeList
        {
            get
            {
                return this.typeList;
            }
            set
            {
                if (value != null)
                    this.typeList = value;
            }
        }


        
    }
}
