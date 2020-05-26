using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.ComponentModel;

namespace lab_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BackgroundWorker worker = new BackgroundWorker();

        private int count = 0;
        public volatile bool grow = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            int count = Convert.ToInt32(e.Argument);

            while(true)
            {
                if (worker.CancellationPending == true)
                {
                    break;
                }

                if (count == 0 || count == 1000)
                {
                    grow = !grow;
                }

                count = grow ? ++count : --count;

                worker.ReportProgress(count / 10, count);

                System.Threading.Thread.Sleep(10);

            }

           e.Result = count;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            count = Convert.ToInt32(e.UserState);
            lCount.Content = count;
            pbProgress.Value = e.ProgressPercentage;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lCount.Content = e.Result;
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy != true)
            {
                worker.RunWorkerAsync(count);
            }
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }
    }
}
