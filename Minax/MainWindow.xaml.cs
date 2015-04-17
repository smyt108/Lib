using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using TasksManager;
using TasksManager.DataModel;

namespace Minax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon _notifyIcon;

        public MainWindow()
        {
            InitializeComponent();

            SetIcon();
        }

        private void SetIcon()
        {
            this._notifyIcon = new NotifyIcon();
            this._notifyIcon.Icon = new System.Drawing.Icon("Timer.ico");

            this._notifyIcon.Visible = true;
            _notifyIcon.MouseDoubleClick += OnNotifyIconDoubleClick;
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Focus();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
            }
        }
    }
}
