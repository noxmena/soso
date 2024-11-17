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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        MovieSystemEntities Db = new MovieSystemEntities();
        public Admin()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            Movies.ItemsSource = Db.Movies.Select(x => new { x.MId,x.Mname, x.Mcategory, x.Myear, x.Mproducer ,x.userId }).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(producertxt.Text == "" || nametxt.Text == "" || yeartxt.Text == "" || categorytxt.Text == "")
            {
                MessageBox.Show("Fields reqiured");
                return;
            }

            var Movie = Db.Movies.FirstOrDefault(mo => mo.Mname == nametxt.Text);

            if(Movie != null)
            {
                MessageBox.Show("Name already exists");
                return;
            }

            Movy m = new Movy()
            {
                Mcategory = categorytxt.Text,
                Mproducer = producertxt.Text,
                Mname = nametxt.Text,   
                Myear = yeartxt.Text
            };

            Db.Movies.Add(m);
            Db.SaveChanges();
            Refresh();
            MessageBox.Show("Added Succfully");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(nametxt.Text == "")
            {
                MessageBox.Show("Flied Name is reiuqed");
                return;
            }

            var movie = Db.Movies.FirstOrDefault(x => x.Mname == nametxt.Text);
            Db.Movies.Remove(movie);
            Db.SaveChanges();
            Refresh();
            MessageBox.Show("Deleted Successfully");
        }
    }
}
