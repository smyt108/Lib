using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BasicLibrary
{
    public static class DataTableExtension
    {
        public static void ConvertDBNull(this DataTable table)
        {
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        if (row[col.ColumnName] == DBNull.Value && (col.DataType == typeof(decimal) ||
                            col.DataType == typeof(double) || col.DataType == typeof(Int32)))
                        {
                            row[col.ColumnName] = 0;
                        }
                        else if (row[col.ColumnName] == DBNull.Value && (col.DataType == typeof(string)))
                        {
                            row[col.ColumnName] = "";
                        }
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
