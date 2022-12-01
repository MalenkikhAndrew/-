using System;
using System.Collections.Generic;
using System.Data;
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

namespace Калькулятор
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in GroupButton.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                string textButton1 = ((Button)e.OriginalSource).Content.ToString();
                if (textButton1 == "C")
                {
                    text.Clear(); //Отчистка строки
                }
                else if (textButton1 == "x")
                {
                    text.Text = text.Text.Substring(text.Text.Length - 1);
                }
                else if (textButton1 == "=")
                {
                    text.Text = new DataTable().Compute(text.Text, null).ToString();//Ответ
                }
                else text.Text += textButton1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//Некорректный ввод
            }
           
        }

       
    }
}
