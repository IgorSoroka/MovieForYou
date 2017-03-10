using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.TMDb;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieForYou.Views
{
    /// <summary>
    /// Логика взаимодействия для MovieView.xaml
    /// </summary>
    public partial class MovieView : Window
    {
        ServiceClient first = new ServiceClient("fa314d1331397149188e07fbec92930d");
        List<string> firstcoll = new List<string>();
        CancellationToken token = new CancellationToken();

        public MovieView()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var movie = await first.Movies.GetAsync(100, null, true, token);

            this.DataContext = movie;

            //foreach (Movie m in movies.Results)
            //{
            //    var movie = await first.Movies.GetAsync(m.Id, null, true, token);

            //    firstcoll.Add(movie.Title);
            //}

            //lbMain.ItemsSource = firstcoll;
            //проверка коммита
        }
    }
}
