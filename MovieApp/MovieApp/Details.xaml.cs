using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Page
    {
        int userId;
        int Mid;
        MovieSystemEntities Db = new MovieSystemEntities();
        public Details(int Mid , int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.Mid = Mid;
            Render(this.Mid);
        }

        public void Render(int Mid)
        {
            var m = Db.Movies.FirstOrDefault(Movie => Movie.MId == Mid);
            nametxt.Content = m.Mname;
            categorytxt.Content = m.Mcategory;
            producertxt.Content = m.Mproducer;
            yeartxt.Content = m.Myear;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllMovies all = new AllMovies(userId);
            this.NavigationService.Navigate(all);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var m = Db.Movies.FirstOrDefault(Movie => Movie.MId == Mid);
            m.userId = userId;
            Db.SaveChanges();
        }
    }
}
