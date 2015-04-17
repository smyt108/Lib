using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;

namespace ExcelController
{
    public interface IExcelManager
    {
        dynamic openExcel(string path, bool visible);

        void CreatePivot(System.Data.DataTable source, PivotTableConfig config);

        void CreatePivot<T>(IEnumerable<T> source, PivotTableConfig config);

        void SetCellValue(Worksheet targetSheet, string cell, object value);
    }
}
