using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using BasicLibrary;
using ClosedXML.Excel;
using System.Data;
using ExcelController;
using System.Collections.ObjectModel;

namespace DataCompare
{
    public class Testing
    {
        public Testing()
        {
            //DBConnHelper dwHelper = new DBConnHelper(Constants.dwConnString);
            //DataSet dwDS = dwHelper.ExecQuery(Constants.stgQuery, 60);
            //System.Data.DataTable dwDT = dwDS.Tables[0];
            //dwDT.TableName = "FactTable";
            //dwDT.ConvertDBNull();

            DBConnHelper uatHelper = new DBConnHelper("Constants.uatConnString");
            DataSet uatDS = uatHelper.ExecQuery("Constants.uatQuery", 600);
            System.Data.DataTable uatDT = uatDS.Tables[0];
            uatDT.TableName = "RRRTable";
            uatDT.ConvertDBNull();

            //System.Data.DataTable unionDT = dwDT.AsEnumerable().Union(uatDT.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            //unionDT.TableName = "UnionTable";

            //System.Data.DataTable expDT = dwDT.AsEnumerable().Except(uatDT.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            //expDT.TableName = "EXPTable";

            ExcelController.PivotTableConfig ptconfi = new ExcelController.PivotTableConfig();
            ptconfi.PivotName = "Pivot_Testing";
            ptconfi.PivotColumns = new System.Collections.ObjectModel.ObservableCollection<string>();
            ptconfi.PivotColumns.Add("Scenario");
            ptconfi.PivotRows = new System.Collections.ObjectModel.ObservableCollection<string>();
            ptconfi.PivotRows.Add("Desk");
            ptconfi.PivotRows.Add("Account");
            ptconfi.PivotValues = new System.Collections.ObjectModel.ObservableCollection<string>();
            ptconfi.PivotValues.Add("EffectiveDV01");
            ptconfi.PivotValues.Add("Convexity");
            ptconfi.PivotValues.Add("Duration");

            IExcelManager em = new ExcelManager();
            em.CreatePivot(uatDT, ptconfi);
        }
    }
}
