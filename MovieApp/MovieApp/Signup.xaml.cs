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

namespace MovieApp
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        MovieSystemEntities Db = new MovieSystemEntities();
        public Signup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.NavigationService.Navigate(l);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (passwordtxt.Text == "" || emailtxt.Text == "" || nametxt.Text == "")
            {
                MessageBox.Show("Some fileds are reqiured");
                return;
            }

            var user = Db.Users.FirstOrDefault(u => u.userName == nametxt.Text);

            if(user != null)
            {
                MessageBox.Show("User Alredy Exists");
                return;
            }


            User newUser = new User() { 
            userName=nametxt.Text,
            userPassword=passwordtxt.Text,  
            userEmail = emailtxt.Text
            };


            Db.Users.Add(newUser);
            Db.SaveChanges();
            MessageBox.Show("Signed up Succsessfully");
            Login l = new Login();
            this.NavigationService.Navigate(l);
        }
    }
}
