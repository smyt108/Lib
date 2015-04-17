using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using BasicLibrary;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;

namespace ExcelController
{
    public class ExcelManager : IExcelManager
    {
        private const string PIVOT_PREFIX="Pivot_";
 
        static object useDefault = Type.Missing;
        dynamic excel = null, errorCheckingOptions = null, workbooks = null;

        private string FilePath;
        private XLWorkbook WorkBook;

        public ExcelManager()
        {
            GetExcelProcessInstance();

            WorkBook = new XLWorkbook();
        }

        public ExcelManager(string path)
            : this()
        {
            FilePath = path;
        }

        public dynamic openExcel(string path, bool visible)
        {
            try
            {
                workbooks = excel.Workbooks;
                return workbooks.Open(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                excel.Visible = visible;

                ReleaseComObjects(new object[] { workbooks, errorCheckingOptions, excel });
            }
        }

        public void CreatePivot(System.Data.DataTable dataSource, PivotTableConfig config)
        {
            var sheet = WorkBook.Worksheets.Add(dataSource.TableName);

            var source = sheet.Cell(1, 1).InsertTable(dataSource, dataSource.TableName, true);

            var range = source.DataRange;

            var dataRange = sheet.Range(sheet.Cell(1, 1), range.LastCell());

            var ptSheet = WorkBook.Worksheets.Add(PIVOT_PREFIX + dataSource.TableName);

            var pt = ptSheet.PivotTables.AddNew(config.PivotName, ptSheet.Cell(1, 1), dataRange);

            foreach (var item in config.PivotColumns)
            {
                pt.ColumnLabels.Add(item);
            }

            foreach (var item in config.PivotRows)
            {
                pt.RowLabels.Add(item);
            }

            foreach (var item in config.PivotValues)
            {
                pt.Values.Add(item);
            }

            FilePath = FolderExt.getUniqueXlsxFileName();
            WorkBook.SaveAs(FilePath);
            openExcel(FilePath, true);
        }

        public void CreatePivot<T>(IEnumerable<T> source, PivotTableConfig config)
        {
            throw new NotImplementedException();
        }

        public void SetCellValue(Worksheet targetSheet, string cell, object value)
        {
            targetSheet.get_Range(cell, useDefault).set_Value(
                XlRangeValueDataType.xlRangeValueDefault, value);
        }

        private void GetExcelProcessInstance()
        {
            Process[] excelProcesses = Process.GetProcessesByName("excel");
            if (excelProcesses.Length > 0)
            {
                DateTime latestStartTime = excelProcesses.Max(p => p.StartTime);
                Process latestExcelProcess = excelProcesses.FirstOrDefault(p => p.StartTime == latestStartTime);
                if (latestExcelProcess != null) excel = latestExcelProcess.ExcelApplication();
            }

            if (excel == null)
            {
                Type excelClassType = Type.GetTypeFromProgID("Excel.Application");

                excel = Activator.CreateInstance(excelClassType);
            }

            errorCheckingOptions = excel.ErrorCheckingOptions;
            errorCheckingOptions.TextDate = false;
        }

        private void ReleaseComObjects(object[] comObjects)
        {
            try
            {
                foreach (var item in comObjects)
                {
                    if (item != null)
                    {
                        Marshal.ReleaseComObject(item);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
