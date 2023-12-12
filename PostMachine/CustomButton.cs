using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PostMachine
{
    internal class CustomButton : Button
    {
        public int ID;
        public CustomButton(int id,bool cheked)
        {
            // Настройка внешнего вида кнопки
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#202335"));
            this.Background = brush;
            this.Foreground = Brushes.White;
            this.BorderBrush = Brushes.White;
            this.BorderThickness = new Thickness(1);
            Style = (Style)FindResource("ButtonStyle");

            Border border = (Border)Template?.FindName("border", this);
            if (border != null)
                border.CornerRadius = new CornerRadius(10);

            try
            {

                // Создание изображения и установка его источника
                Image img = new Image();
                BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/res/image/section.png"));
                img.Source = bitmapImage;

                // Установка изображения как содержимого кнопки
                if (cheked == true)
                {
                    this.Content = img;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
            }
        }
    }
}
