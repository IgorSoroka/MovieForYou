using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.TMDb;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieForYou.Models
{
    public class GetData
    {
        ServiceClient first = new ServiceClient("fa314d1331397149188e07fbec92930d");
        CancellationToken token = new CancellationToken();

        public async Task<List<MainDataMovie>> GetPopularMoviesData()
        {
            List<MainDataMovie> popularMovies = new List<MainDataMovie>();
            Movies movies = await first.Movies.GetPopularAsync(null, 1, token);

            foreach (var item in movies.Results)
            {
                string path = null;
                if (!string.IsNullOrEmpty(item.Poster))
                {
                    //сделать, чтобы путь работал корректно на всех машинах
                    path = System.IO.Path.Combine(@"D:\Курсы\MovieForYou\MovieForYou\bin\Debug\Pictures\", item.Poster.TrimStart('/'));
                }
                popularMovies.Add(new MainDataMovie { Title = item.Title, OriginalTitle = item.OriginalTitle, Poster = path, ReleaseDate = item.ReleaseDate, VoteAverage = item.VoteAverage });
            }

            await DownloaderAsync(movies);
            return popularMovies;
        }

        //переделать, чтобы принимал любое множество
        public async Task DownloaderAsync(Movies movies)
        {
            foreach (var item in movies.Results)
            {
                if (!string.IsNullOrEmpty(item.Poster))
                {
                    string filepath = System.IO.Path.Combine("Pictures", item.Poster.TrimStart('/'));
                    await DownloadImage(item.Poster, filepath, token);
                }
            }
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

        //поменять на 1 метод-загрузчик
        public async Task CastDownloaderAsync(IEnumerable<MediaCast> cast)
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

        //поменять на 1 метод-загрузчик
        public async Task CrewDownloaderAsync(IEnumerable<MediaCrew> crew)
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

