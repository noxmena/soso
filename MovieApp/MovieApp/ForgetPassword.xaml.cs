using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace MovieApp
{
    /// <summary>
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Page
    {
        MovieSystemEntities Db = new MovieSystemEntities();
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(passwordtxt.Text == "" || emailtxt.Text =="")
            {
                MessageBox.Show("Field reqiued");
                return;
            }

            var user = Db.Users.FirstOrDefault(u => u.userEmail == emailtxt.Text);
            
            if(user == null)
            {
                MessageBox.Show("Email is invalid");
                return;
            }
            user.userPassword = passwordtxt.Text;
            Db.SaveChanges();
            this.NavigationService.Navigate(new Login());
        }
    }
}
