using BussinessObjects;
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

namespace WPFView
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(Page));
        }

        private void OnSignIn(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            var result = AuthenticationBussiness.ProcessSignIn(email, password);
            
            if (result.Role == AccountRole.Customer)
            {
                if (result.Details == null) return;

                var customerWindow = new CustomerWindow(result.Details);
                customerWindow.Show();

                var parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            } else if (result.Role == AccountRole.Administrator)
            {
                var adminWindow = new AdministratorWindow();
                adminWindow.Show();

                var parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            } else
            {
                MessageBox.Show("Wrong email or password.");
            }
        }
            
        private void OnCancel(object sender, RoutedEventArgs e)
        {

        }
    }
}
