using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Collections.ObjectModel;

namespace BasicLibrary
{
    public static class DataModelTransformer
    {
    }

    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }
    }

    public static class DataTableToList<T> where T : new()
    {
        /// <summary>
        /// Get column name collection
        /// </summary>
        private static IList<string> GetColumnNames(DataColumnCollection dcc)
        {
            IList<string> list = new List<string>();
            foreach (DataColumn dc in dcc)
            {
                list.Add(dc.ColumnName);
            }
            return list;
        }

        /// <summary>
        ///Property name and type name key value pair collection
        /// </summary>
        private static Hashtable GetColumnType(DataColumnCollection dcc)
        {
            if (dcc == null || dcc.Count == 0)
            {
                return null;
            }
            IList<string> colNameList = GetColumnNames(dcc);

            Type t = typeof(T);
            PropertyInfo[] properties = t.GetProperties();
            Hashtable hashtable = new Hashtable();
            int i = 0;
            foreach (PropertyInfo p in properties)
            {
                foreach (string col in colNameList)
                {
                    if (col.ToLower().Contains(p.Name.ToLower()))
                    {
                        hashtable.Add(col, p.PropertyType.ToString() + i++);
                    }
                }
            }

            return hashtable;
        }

        /// <summary>
        /// DataTable convert to IList
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ToList(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            PropertyInfo[] properties = typeof(T).GetProperties();
            Hashtable hh = GetColumnType(dt.Columns);
            IList<string> colNames = GetColumnNames(hh);
            List<T> list = new List<T>();
            T model = default(T);
            foreach (DataRow dr in dt.Rows)
            {
                model = new T();//Create entity instance
                int i = 0;
                foreach (PropertyInfo p in properties)
                {
                    if (p.PropertyType == typeof(string))
                    {
                        p.SetValue(model, dr[colNames[i++]], null);
                    }
                    else if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(model, int.Parse(dr[colNames[i++]].ToString()), null);
                    }
                    else if (p.PropertyType == typeof(DateTime))
                    {
                        p.SetValue(model, DateTime.Parse(dr[colNames[i++]].ToString()), null);
                    }
                    else if (p.PropertyType == typeof(float))
                    {
                        p.SetValue(model, float.Parse(dr[colNames[i++]].ToString()), null);
                    }
                    else if (p.PropertyType == typeof(double))
                    {
                        p.SetValue(model, double.Parse(dr[colNames[i++]].ToString()), null);
                    }
                    else if (p.PropertyType == typeof(bool))
                    {
                        p.SetValue(model, bool.Parse(dr[colNames[i++]].ToString()), null);
                    }
                }

                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// Get column name collection
        /// </summary>
        private static IList<string> GetColumnNames(Hashtable hh)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            IList<string> ilist = new List<string>();
            int i = 0;
            foreach (PropertyInfo p in properties)
            {
                ilist.Add(GetKey(p.PropertyType.ToString() + i++, hh));
            }
            return ilist;
        }

        /// <summary>
        /// Get key by value
        /// </summary>
        private static string GetKey(string val, Hashtable tb)
        {
            foreach (DictionaryEntry de in tb)
            {
                if (de.Value.ToString() == val)
                {
                    return de.Key.ToString();
                }
            }
            return null;
        }
    }
}
