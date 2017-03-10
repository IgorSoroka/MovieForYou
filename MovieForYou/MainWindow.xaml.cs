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

            IEnumerable<MediaCrew> crew = mediacredit.OfType<MediaCrew>();

            foreach (var item in crew)
            {
                if (!string.IsNullOrEmpty(item.Profile))
                {
                    string filepath = System.IO.Path.Combine("Pictures", item.Profile.TrimStart('/'));
                    await DownloadImage(item.Profile, filepath, token);
                }
            }

            string path = System.IO.Path.Combine("Pictures", movie.Poster.TrimStart('/'));
            await DownloadImage(movie.Poster, path, token);

            //BitmapImage logo = new BitmapImage();

            //string one = string.Join("Picture", many);

            //logo.BeginInit();
            //logo.UriSource = new Uri(path);
            //logo.EndInit();

            //imgMain.Source = logo;

            //imgMain.Source = path;

            lbCast.ItemsSource = mediacredit.Take(5);
            lbCrew.ItemsSource = crew;

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
     }        
}

