using System;
using System.Collections.Generic;
using System.IO;
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
            //var movie = await first.Movies.GetAsync(100, null, true, token);
            //var mediacredit = await first.Movies.GetCreditsAsync(100, token);

            ////просто скачиваем и ставим в экран постер для проверки работы
            //string path = System.IO.Path.Combine("Pictures", movie.Poster.TrimStart('/'));
            //await DownloadImage(movie.Poster, path, token);
            //BitmapImage myBitmapImage = new BitmapImage();
            //myBitmapImage.BeginInit();
            //myBitmapImage.UriSource = new Uri(@"D:\Курсы\MovieForYou\MovieForYou\bin\Debug\Pictures\qV7QaSf7f7yC2lc985zfyOJIAIN.jpg"); ;
            //myBitmapImage.EndInit();

            ////переводим команду и актеров фильма в списки соответствующих объектов классов DataCrew и DataCast из DATA для привязки
            //IEnumerable<MediaCrew> crew = mediacredit.OfType<MediaCrew>();
            //List<DataCrew> datacrew = ConvertToDataCrew(crew);
            //IEnumerable<MediaCast> cast = (mediacredit.OfType<MediaCast>()).Take(5);
            //List<DataCast> datacast = ConvertToDataCast(cast);
            ////скачиваем и сохраняем фото актеров и команды
            //await CastDownloader(cast);
            //await CrewDownloader(crew);

            //imgMain.Source = myBitmapImage;
            //lbCast.ItemsSource = datacast;
            //lbCrew.ItemsSource = datacrew;
            //this.DataContext = movie;
        }
    }
}
