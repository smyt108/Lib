using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BasicLibrary;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;

namespace ExcelController
{
    public class PivotTableConfig : ViewModelBase
    {
        private ObservableCollection<string> _pivotRows;
        public ObservableCollection<string> PivotRows
        {
            get { return _pivotRows; }
            set
            {
                if (value != _pivotRows)
                {
                    _pivotRows = value;
                    OnPropertyChanged(()=>this.PivotRows);
                }
            }
        }

        private ObservableCollection<string> _pivotColumns;
        public ObservableCollection<string> PivotColumns
        {
            get { return _pivotColumns; }
            set
            {
                if (value != _pivotColumns)
                {
                    _pivotColumns = value;
                    OnPropertyChanged(() => this.PivotColumns);
                }
            }
        }

        private ObservableCollection<string> _pivotValues;
        public ObservableCollection<string> PivotValues
        {
            get { return _pivotValues; }
            set
            {
                if (value != _pivotValues)
                {
                    _pivotValues = value;
                    OnPropertyChanged(() => this.PivotValues);
                }
            }
        }

        public string PivotName { get; set; }
    }
}
