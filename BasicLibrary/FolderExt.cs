using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BasicLibrary
{
    public class FolderExt
    {
        public static string getUniqueXlsxFileName()
        {
            Random r = new Random();
            string uniqueFileName = "";
            int count = 0;
            do
            {
                if (count > 10000)
                {
                    throw new Exception("Please delete some <extension>.xlsx files from your C:\temp folder and then press OK");
                }
                count++;

                uniqueFileName = @"C:\temp\" + r.Next(0, 1000000) + ".xlsx";
            }
            while (File.Exists(uniqueFileName));
            return uniqueFileName;
        }
    }
}
