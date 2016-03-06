using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BehaviorAndCommandParameterSample
{
    public static class ChangeDataGridBackgroundBehavior
    {
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.RegisterAttached("Background", typeof(string), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridBackgroundChanged));

        public static string GetBackground(DependencyObject element)
        {
            return (string)element.GetValue(BackgroundProperty);
        }

        public static void SetBackground(DependencyObject element, string value)
        {
            element.SetValue(BackgroundProperty, value);
        }

        private static void DataGridBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGrid dg = d as DataGrid;
            dg.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(e.NewValue.ToString()));
        }
    }
}
