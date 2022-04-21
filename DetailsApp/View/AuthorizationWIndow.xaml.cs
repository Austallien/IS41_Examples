using DetailsApp.Model.Entity;
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

namespace DetailsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWIndow.xaml
    /// </summary>
    public partial class AuthorizationWIndow : Window
    {
        public AuthorizationWIndow()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new TradeCompanyEntities())
            {
                var user = context.User.FirstOrDefault(u => u.Login.Equals(textBoxLogin.Text)
                    && u.Password.Equals(textBoxPassword.Text));

                if(user != null)
                {
                    switch ((Model.Role)user.RoleId)
                    {
                        case Model.Role.Director:
                            new DirectorWindow().Show();
                            break;
                        case Model.Role.Accountant:
                            new AccountantWindow().Show();
                            break;
                        case Model.Role.Customer:
                            new CustomerWindow().Show();
                            break;
                        case Model.Role.MaintenceWorker:
                            new MaintanceWorkerWindow().Show();
                            break;
                        default:
                            MessageBox.Show("Роль пользователя не найдена");
                            break;
                    }
                }
                else MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
