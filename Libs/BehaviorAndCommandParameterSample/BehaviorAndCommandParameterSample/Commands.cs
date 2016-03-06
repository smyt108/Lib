using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BehaviorAndCommandParameterSample
{
    public static class Commands
    {
        public static void ChangeBackgroundCommand(object payLoad)
        {
            DataGrid dg = payLoad as DataGrid;

            dg.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
        }
    }
}
