using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicLibrary;

namespace DataCompare.ViewModels
{
    public class PivotViewModel : ViewModelBase
    {
        public PivotViewModel(string sqlFilePath)
        {
            SQLQuery = File.ReadAllText(sqlFilePath, Encoding.UTF8);
        }

        private string _sqlQuery;
        public string SQLQuery
        {
            get { return _sqlQuery; }
            set
            {
                if (value != _sqlQuery)
                {
                    _sqlQuery = value;
                    OnPropertyChanged(() => this.SQLQuery);
                }
            }
        }

        private string _connString;
        public string ConnString
        {
            get { return _sqlQuery; }
            set
            {
                if (value != _connString)
                {
                    _connString = value;
                    OnPropertyChanged(() => this.ConnString);
                }
            }
        }
    }
}
