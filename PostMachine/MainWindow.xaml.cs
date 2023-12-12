using PostMachine.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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


namespace PostMachine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int command_id = -1;
        public static int link;
        public static int link2;
        private List<Section> line = new List<Section>();
        static private int lineSize = 100;
        private Carriage carriage = new Carriage(0);
        private Commands commands = new Commands();
        private int lastCommandComplete = 0;
         public MainWindow()
        {
            InitializeComponent();
            for (int i = -(lineSize / 2); i <= lineSize / 2; i++)
            {
                line.Add(new Section(i));
            }
            LineInit();
            noNameStackScroller.ScrollToHorizontalOffset((noNameStackScroller.Width * 8.4) / 2);
            AddTestCommands();
            CommandsInit();
        }

        private void Task_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                // При нажатии на ваш пользовательский taskBar, вызываем DragMove для перемещения окна
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void btnReset_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RefreshLine();
        }

        private void btnMinus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            commands.RemoveLastCommand();
            CommandsInit();
        }

        private void btnPlus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            addCommand add=new addCommand();
            add.ShowDialog();
            bool result = add.DialogResult.Value;
            if (result == true)
            {
                if(command_id!=4)
                    commands.AddCommand(command_id,link) ;
                else
                    commands.AddCommand(command_id, link,link2);

                LineInit();
                CommandsInit();
            }
        }

        private async void btnStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool ended=false;
            for (int i = 0;i< commands.GetCommands().Count;i++)
            {
                if (commands.GetCommands()[i].GetOperationId() == 5)
                {
                    ended = true;
                }
            }
            if (ended == false)
            {
                MessageBox.Show("Добавьте конец");
                return;
            }    
            while (commands.GetCommands()[lastCommandComplete].GetOperationId()!=5)
            {
                ApplyCommands();
                
            }
            lastCommandComplete = 0;
        }


        private void AddTestCommands()
        {
            commands.AddCommand(4, 1, 2);
            commands.AddCommand(2, 0);
            commands.AddCommand(0, 3);
            commands.AddCommand(5, 0);
        }


        private void btnNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (commands.GetCommands().Count != 0)
                ApplyCommands();
        }

        private void noNameStackScroller_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                noNameStackScroller.LineRight();
            }
            else
            {
                noNameStackScroller.LineLeft();
            }

            e.Handled = true;
        }
        private void RefreshLine() { 

            if (line.Count == 0)
                return;

            for (int i = 0; i < line.Count; i++)
            {
                line[i].SetUncheck();
            }

            if (carriage.GetCarriageLocation() != 0)
            {
                carriage.SetNewLocation(0);
            }

            lastCommandComplete = 0;
            LineInit();
            CommandsInit();
        }

        private void CommandsInit()
        {
            statusPack.Children.Clear();
            functionPack.Children.Clear();
            transitionPack.Children.Clear();
            numberPack.Children.Clear();
            for (int i = -1; i < commands.GetCommands().Count; i++)
            {
                if (i == -1) {
                    Label texth = new Label();
                    texth.Content = "Status";
                    texth.Foreground = Brushes.White;
                    texth.HorizontalAlignment = HorizontalAlignment.Center;
                    statusPack.Children.Add(texth);
                    Label texth2 = new Label();
                    texth2.Content = "Number";
                    texth2.Foreground = Brushes.White;
                    texth2.HorizontalAlignment = HorizontalAlignment.Center;
                    numberPack.Children.Add(texth2);
                    Label texth3 = new Label();
                    texth3.Content = "Function";
                    texth3.Foreground = Brushes.White;
                    texth3.HorizontalAlignment = HorizontalAlignment.Center;
                    functionPack.Children.Add(texth3);
                    Label texth4 = new Label();
                    texth4.Content = "Transitions";
                    texth4.Foreground = Brushes.White;
                    texth4.HorizontalAlignment = HorizontalAlignment.Center;
                    transitionPack.Children.Add(texth4);
                    continue;
                }
                Image img = new Image();
                BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/res/image/select.png"));
                img.Width = label2.Height-10;
                img.Height = label2.Height - 5;
                
                if (i == lastCommandComplete) {
                    img.Source = bitmapImage;
                    statusPack.Children.Add(img);
                }
                else
                {
                   statusPack.Children.Add(img);
                }
                Label text= new Label();
                text.Content = i.ToString();
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.Foreground = Brushes.White;
                numberPack.Children.Add(text);
                Label text2 = new Label();
                text2.Content = commands.GetCommands()[i].GetOperationIcon();
                text2.HorizontalAlignment = HorizontalAlignment.Center;
                text2.Foreground = Brushes.White;
                functionPack.Children.Add(text2);
                Label text3 = new Label();
                if (commands.GetCommands()[i].GetOperationId() != 4)
                {
                    text3.Content = commands.GetCommands()[i].GetLink();
                    text3.HorizontalAlignment = HorizontalAlignment.Center;
                    text3.Foreground = Brushes.White;
                    transitionPack.Children.Add(text3);
                }
                else
                {
                    text3.Content = commands.GetCommands()[i].GetLink()+" , "+ commands.GetCommands()[i].GetLink2();
                    text3.HorizontalAlignment = HorizontalAlignment.Center;
                    text3.Foreground = Brushes.White;
                    transitionPack.Children.Add(text3);
                }
                
            }
            
        }


        private void ApplyCommands()
        {

            if (commands.GetCommands()[lastCommandComplete].GetOperationId() == 0 && (carriage.GetCarriageLocation() != -lineSize/2))
                carriage.CarriageLeft();

            if (commands.GetCommands()[lastCommandComplete].GetOperationId() == 1 && (carriage.GetCarriageLocation() != lineSize / 2))
                carriage.CarriageRight();

            if (commands.GetCommands()[lastCommandComplete].GetOperationId() == 2)
            {
                line[carriage.GetCarriageLocation()+lineSize/2].SetCheck();
            }

            if (commands.GetCommands()[lastCommandComplete].GetOperationId() == 3)
            {
                line[carriage.GetCarriageLocation() + lineSize / 2].SetUncheck();
            }

            if (lastCommandComplete >= 0 && lastCommandComplete < commands.GetCommands().Count - 1 && commands.GetCommands()[lastCommandComplete].GetOperationId() != 5 && commands.GetCommands()[lastCommandComplete].GetOperationId() != 4)
                lastCommandComplete = commands.GetCommands()[lastCommandComplete].GetLink();
            else
            {
                if (commands.GetCommands()[lastCommandComplete].GetOperationId() != 4)
                {
                    lastCommandComplete = 0;
                }
                else
                {
                    if (!line[carriage.GetCarriageLocation() + lineSize / 2].GetChecked()) {

                       lastCommandComplete= commands.GetCommands()[lastCommandComplete].GetLink();
                    }
                    else
                    {
                        lastCommandComplete = commands.GetCommands()[lastCommandComplete].GetLink2();
                    }
                         
                       
                }
            }
            LineInit();
            CommandsInit();
        }

        private void LineInit()
        {
            StackPanel myStackPanel = Noname; // Замените YourStackPanelName на имя вашего StackPanel из XAML
            BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/res/image/carrige.png"));
            myStackPanel.Children.Clear();

            for (int i = -lineSize/2; i <= lineSize/2; i++)
            {

                CustomButton newButton = new CustomButton(i, line[i+lineSize/2].GetChecked());
                newButton.ID = i;
                newButton.Click += (sender, e) =>
                {
                    line[newButton.ID+lineSize/2].Check();
                    LineInit();
                };

                Label label = new Label();
                Image carriege = new Image();
                carriege.Source = bitmapImage;
                if (carriage.GetCarriageLocation() != i)
                {
                    carriege.Visibility = Visibility.Hidden;
                }
                 
                label.Content = $"{i}";
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.Foreground = Brushes.White;
                StackPanel newStackPanel = new StackPanel();
                newStackPanel.Children.Add(label);
                newStackPanel.Children.Add(newButton);
                newStackPanel.Children.Add(carriege);
                myStackPanel.Children.Add(newStackPanel);     
            }
        }

        private void rightSide_MouseDown(object sender, MouseButtonEventArgs e)
        {
            noNameStackScroller.ScrollToRightEnd();
        }

        private void leftSide_MouseDown(object sender, MouseButtonEventArgs e)
        {
            noNameStackScroller.ScrollToHome();
        }

        private void leftSide_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            noNameStackScroller.ScrollToHorizontalOffset((noNameStackScroller.Width * 8.4) / 2);
        }
    }
}
