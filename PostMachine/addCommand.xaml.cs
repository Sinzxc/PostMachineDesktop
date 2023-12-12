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
using System.Windows.Shapes;

namespace PostMachine
{
    /// <summary>
    /// Логика взаимодействия для addCommand.xaml
    /// </summary>
    public partial class addCommand : Window
    {
       
        public addCommand()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MainWindow.command_id == -1) {
                MessageBox.Show("Вы не выбрали команду");
                return;
            }
            if (MainWindow.command_id != 4)
            {
                if (linklabel.Text.Length!=0)
                {
                    MainWindow.link = Convert.ToInt32(linklabel.Text.ToString());
                    DialogResult = true;
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Вы не ввели ссылку");
                }
            }
            else
            {
                if (linklabel.Text.Length != 0&&link2input.Text.Length!=0)
                {
                    MainWindow.link = Convert.ToInt32(linklabel.Text.ToString());
                    MainWindow.link2 = Convert.ToInt32(link2input.Text.ToString());
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Вы не ввели ссылку");
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                MainWindow.command_id = comboBox.SelectedIndex;

                if (MainWindow.command_id == 4)
                {

                    link2label.Visibility = Visibility.Visible;
                    link2input.Visibility = Visibility.Visible;
                }
                else
                {
                    link2label.Visibility = Visibility.Hidden;
                    link2input.Visibility = Visibility.Hidden;
                }
            }
           
        }
    }
}
