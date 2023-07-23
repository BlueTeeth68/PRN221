using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        public int Minute { get; set; } = 10;
        public int Second { get; set; } = 0;
        public int MiliSecond { get; set; } = 0;

        private Task MinuteTask;
        private Task SecondTask;
        private Task MiliSecondTask;

        private bool isStop = false;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            txtMinute.Text = string.Format("{0}", Minute.ToString().PadLeft(2, '0'));
            txtSecond.Text = string.Format("{0}", Second.ToString().PadLeft(2, '0'));
            txtMiliSecond.Text = string.Format("{0}", MiliSecond.ToString().PadLeft(2, '0'));
        }

        private void SecondChange()
        {
            while (!isStop)
            {

                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    if (Second == 0)
                    {
                        Second = 59;
                    }
                    else
                    {
                        Second--;
                    }
                    txtSecond.Text = string.Format("{0}", Second.ToString().PadLeft(2, '0'));
                }));

                Thread.Sleep(1000);
            }
        }

        private void MiliSecondChange()
        {
            while (!isStop)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    if (MiliSecond == 0)
                    {
                        MiliSecond = 9;
                    }
                    else
                    {
                        MiliSecond--;
                    }
                    txtMiliSecond.Text = MiliSecond + "0";
                }));

                Thread.Sleep(100);
            }
        }

        private void MinuteChange()
        {
            while (!isStop)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {

                    Minute--;
                    txtMinute.Text = string.Format("{0}", Minute.ToString().PadLeft(2, '0'));
                }));

                Thread.Sleep(1000 * 60);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            isStop = false;
            MinuteTask = new Task(() => MinuteChange());
            SecondTask = new Task(() => SecondChange());
            MiliSecondTask = new Task(() => MiliSecondChange());

            MinuteTask.Start();
            SecondTask.Start();
            MiliSecondTask.Start();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            isStop = true;
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            isStop = true;
            Minute = 10;
            Second = 0;
            MiliSecond = 0;
            txtMinute.Text = string.Format("{0}", Minute.ToString().PadLeft(2, '0'));
            txtSecond.Text = string.Format("{0}", Second.ToString().PadLeft(2, '0'));
            txtMiliSecond.Text = string.Format("{0}", MiliSecond.ToString().PadLeft(2, '0'));

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = true;

        }
    }
}
