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

namespace lab_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dictionary<string, object> menu = new Dictionary<string, object>();

        private Coffee coffee;
        public MainWindow()
        {
            InitializeComponent();

            menu.Add("Американо", new Coffee("Американо", 20));
            menu.Add("Капучино", new Coffee("Капучино", 30));
            menu.Add("Эспрессо", new Coffee("Эспрессо", 25));
            menu.Add("Какао", new Coffee("Какао", 15));

        }

        private void selectCoffee(string coffeeTipe) 
        {
            Coffee coffee = menu[coffeeTipe] as Coffee;
        }

        private void rbCoffee_Click(object sender, RoutedEventArgs e)
        {
            string coffeeTipe = (sender as RadioButton).Content as string;
            this.coffee = menu[coffeeTipe] as Coffee;

            lPrice.Content = coffee.Price;

            CheckSum();
        }

        private void BEnterMoney_Click(object sender, RoutedEventArgs e)
        {
            lMoney.Content = Convert.ToInt32(lMoney.Content) + Convert.ToInt32(tbMoney.Text);

            CheckSum();
        }

        private void CheckSum()
        {
            int price = Convert.ToInt32(lPrice.Content);
            int sum = Convert.ToInt32(lMoney.Content);

            if (sum >= price)
            {
                lChange.Content = sum - price;
                bOk.IsEnabled = true;
            }
            else
            {
                lChange.Content = 0;
                bOk.IsEnabled = false;
            }
        }

        private void BOk(object sender, RoutedEventArgs e)
        {
            string str = "Напиток " + coffee.Name;

            if (cbSugar.IsChecked == true)
            {
                str += " с сахаром";

                if (cbMilk.IsChecked == true)
                {
                    str += " и молоком";
                }
            }
            else if (cbMilk.IsChecked == true)
            {
                str += " с молоком";
            }

            str += " готов!\n Сдача: " + lChange.Content;
            lChange.Content = 0;
            lMoney.Content = 0;

            MessageBox.Show(str);
        }
    }
}
