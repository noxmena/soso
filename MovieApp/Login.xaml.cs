using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace MovieApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MovieSystemEntities Db = new MovieSystemEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Signup S = new Signup();
            this.NavigationService.Navigate(S);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

            if(emailtxt.Text == "" || passwordtxt.Text == "")
            {
                MessageBox.Show("Fileds Are Reqiured");
                return;
            }

            if(emailtxt.Text == "1" && passwordtxt.Text == "1")
            {
                Admin a = new Admin();
                MessageBox.Show("Login As Admin Successfully");
                this.NavigationService.Navigate(a);
                return;
            }

            var user = Db.Users.Where(u => u.userEmail == emailtxt.Text && u.userPassword == passwordtxt.Text).FirstOrDefault();

            if(user == null)
            {
                MessageBox.Show("User is not valid");
                return;
            }
            AllMovies all = new AllMovies(user.userID);
            this.NavigationService.Navigate(all);
            }catch(Exception entity)
            {
                MessageBox.Show($"Error in {entity}");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ForgetPassword p = new ForgetPassword();
            this.NavigationService.Navigate(p);
        }
    }
}
