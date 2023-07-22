using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Countdown_Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int second = 59, minute = 59, hour = 2;

        private void txtSecond_Initialized(object sender, EventArgs e)
        {
            txtSecond.Text = "58";
        }

        private void txtSecond_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            Task secondTask = Task.Run(() =>
            {
                second = second == 0 ? 59 : second - 1;
                Thread.Sleep(1000);
            });

            txtSecond.Text = second.ToString();
        }


        public MainWindow()
        {
            InitializeComponent();
            Task init = Task.Run(() => { 
                Thread.Sleep(1000);
            });
        }
    }
}
