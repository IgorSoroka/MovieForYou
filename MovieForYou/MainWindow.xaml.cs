using MovieForYou.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieForYou
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceClient first = new ServiceClient("fa314d1331397149188e07fbec92930d");

        List<string> firstcoll = new List<string>();

        CancellationToken token = new CancellationToken();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var movie = await first.Movies.GetAsync(100, null, true, token);
            var mediacredit = await first.Movies.GetCreditsAsync(100, token);

            //просто скачиваем и ставим в экран постер для проверки работы
            string path = System.IO.Path.Combine("Pictures", movie.Poster.TrimStart('/'));
            await DownloadImage(movie.Poster, path, token);
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"D:\Курсы\MovieForYou\MovieForYou\bin\Debug\Pictures\qV7QaSf7f7yC2lc985zfyOJIAIN.jpg"); ;
            myBitmapImage.EndInit();

            //переводим команду и актеров фильма в списки соответствующих объектов классов DataCrew и DataCast из DATA для привязки
            IEnumerable<MediaCrew> crew = mediacredit.OfType<MediaCrew>();
            List<DataCrew> datacrew = ConvertToDataCrew(crew);
            IEnumerable<MediaCast> cast = (mediacredit.OfType<MediaCast>()).Take(5);
            List<DataCast> datacast = ConvertToDataCast(cast);
            //скачиваем и сохраняем фото актеров и команды
            await CastDownloader(cast);
            await CrewDownloader(crew);

            imgMain.Source = myBitmapImage;
            lbCast.ItemsSource = datacast;
            lbCrew.ItemsSource = datacrew;
            this.DataContext = movie;
        }

        static async Task DownloadImage(string filename, string localpath, CancellationToken cancellationToken)
        {
            if (!File.Exists(localpath))
            {
                string folder = System.IO.Path.GetDirectoryName(localpath);
                Directory.CreateDirectory(folder);

                var storage = new StorageClient();
                using (var fileStream = new FileStream(localpath, FileMode.Create, FileAccess.Write, FileShare.None, short.MaxValue, true))
                {
                    try
                    {
                        await storage.DownloadAsync(filename, fileStream, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.TraceError(ex.ToString());
                    }
                }
            }
        }

        public List<DataCast> ConvertToDataCast(IEnumerable<MediaCast> cast)
        {
            List<DataCast> test = new List<DataCast>();

            foreach (var item in cast)
            {
                string path = null;
                if (!string.IsNullOrEmpty(item.Profile))
                {
                    path = System.IO.Path.Combine(@"D:\Курсы\MovieForYou\MovieForYou\bin\Debug\Pictures\", item.Profile.TrimStart('/'));
                }
                test.Add(new DataCast { CreditId = item.CreditId, Id = item.Id, Name = item.Name, Path = path, Character = item.Character });
            }

            return test;
        }

        public List<DataCrew> ConvertToDataCrew(IEnumerable<MediaCrew> crew)
        {
            List<DataCrew> test = new List<DataCrew>();

            foreach (var item in crew)
            {
                string path = null;
                if (!string.IsNullOrEmpty(item.Profile))
                {
                    path = System.IO.Path.Combine(@"D:\Курсы\MovieForYou\MovieForYou\bin\Debug\Pictures\", item.Profile.TrimStart('/'));
                }
                test.Add(new DataCrew { CreditId = item.CreditId, Id = item.Id, Name = item.Name, Path = path, Department = item.Department, Job = item.Job });
            }

            return test;
        }

        public async Task CastDownloader(IEnumerable<MediaCast> cast)
        {
            foreach (var item in cast)
            {
                if (!string.IsNullOrEmpty(item.Profile))
                {
                    string filepath = System.IO.Path.Combine("Pictures", item.Profile.TrimStart('/'));
                    await DownloadImage(item.Profile, filepath, token);
                }
            }
        }

        public async Task CrewDownloader(IEnumerable<MediaCrew> crew)
        {
            foreach (var item in crew)
            {
                if (!string.IsNullOrEmpty(item.Profile))
                {
                    string filepath = System.IO.Path.Combine("Pictures", item.Profile.TrimStart('/'));
                    await DownloadImage(item.Profile, filepath, token);
                }
            }
        }
    }
}
