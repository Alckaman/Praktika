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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GAIEntities context;
        static int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            context = new GAIEntities();
         
        }

        private void Click(object sender, RoutedEventArgs e)
        {

            if (Login.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Поля пустые", "Ошибка!");
            }
            else
            {
                int result;
                if (int.TryParse(Login.Text, out result))
                {
                    counter++;
                    int numDriverDocument = Convert.ToInt32(Login.Text);
                    string pass = Password.Text;

                    Driver driver = context.Driver.ToList().Find(x => x.numDriverDocument == numDriverDocument);
                    if (counter >= 3)
                    {
                        Login.IsEnabled = false;
                        Login.Text = "";
                        Password.IsEnabled = false;
                        Password.Text = "";
                        Enter.IsEnabled = false;
                        MessageBox.Show("Превышено количество попыток(3)", "Критическая Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    if (driver == null)
                    {
                        MessageBox.Show("Пользователя с таким логином не существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {
                        if (driver.password.Equals(pass))
                        {
                            MessageBox.Show("Вход выполнен!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else MessageBox.Show("Введите числа", "Ошибка!");
            }
        }
        
        
    }
}
