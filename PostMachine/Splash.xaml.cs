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
using System.Windows.Shapes;

namespace PostMachine
{
    /// <summary>
    /// Логика взаимодействия для Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public Splash()
        {
            InitializeComponent();
            
            Thread t =new Thread(Wait);
            t.Start();
            
        }

        void Wait() {
            Thread.Sleep(2000);
            this.Dispatcher.Invoke(() =>
            {
                MainWindow w = new MainWindow();
                w.Show();
                this.Close();
            });
        }
    }
}
