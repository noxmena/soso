using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AllMovies.xaml
    /// </summary>
    public partial class AllMovies : Page
    {
        int userId;
        MovieSystemEntities Db = new MovieSystemEntities();
        public AllMovies(int userid)
        {
            InitializeComponent();
            Refresh();
            var list = Db.Movies.Select(movie => movie.Mcategory).Distinct().ToList();
            list.Add("");
            compo.ItemsSource = list;
            userId = userid;
        }

        public void Refresh()
        {
            Movies.ItemsSource = Db.Movies.Select(movie => new { movie.MId, movie.Mcategory, movie.Mname }).ToList();
        }

        private void compo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (compo.SelectedItem.ToString() == "")
            {
                Movies.ItemsSource = Db.Movies.Select(movie => new { movie.MId, movie.Mcategory, movie.Mname }).ToList();
                return;
            }
            var M = Db.Movies.Where(m => m.Mcategory == compo.SelectedItem.ToString()).Select(mo => new { mo.userId, mo.Mcategory, mo.Mname });
            Movies.ItemsSource = M.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (m_id.Text == "")
            {
                MessageBox.Show("Fields are reqiued");
                return;
            }

            int id = int.Parse(m_id.Text);
            var movie = Db.Movies.Where(m => m.MId == id).Select(emovie => new { emovie.MId, emovie.Mcategory, emovie.Mname }).ToList();

            if (movie == null)
            {
                MessageBox.Show("Error");
                return;
            }
            Movies.ItemsSource = movie;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (m_id.Text == "")
            {
                MessageBox.Show("Fields are reqiued");
                return;
            }
            int id = int.Parse(m_id.Text);
            var movie = Db.Movies.FirstOrDefault(m => m.MId == id);


            var userEcistes = Db.Users.FirstOrDefault(user => user.userID == movie.userId);


            if (userEcistes == null)
            {
                Details D = new Details(movie.MId , userId);
                this.NavigationService.Navigate(D);
                return;
            }
            MessageBox.Show($"Book Already By {userEcistes.userName}");
        }
    }
}
