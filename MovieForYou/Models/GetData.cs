using System;
using System.Collections.Generic;
using System.IO;
using System.Net.TMDb;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace MovieForYou.Models
{
    public class GetData
    {
        ServiceClient first = new ServiceClient("fa314d1331397149188e07fbec92930d");
        CancellationToken token = new CancellationToken();

        public async Task<List<Movie>> GetPopularMoviesData()
        {
            Movies movies = await first.Movies.GetPopularAsync("ru", 1, token);
            List<Movie> popularMovies = movies.Results.ToList<Movie>();
            return popularMovies;
        }

        public async Task<List<Movie>> GetNewMoviesData()
        {
            Movies movies = await first.Movies.GetNowPlayingAsync("ru", 1, token);
            List<Movie> newMovies = movies.Results.ToList<Movie>();
            return newMovies;
        }

        public async Task<List<Movie>> GetTopRatedMoviesData()
        {
            Movies movies = await first.Movies.GetTopRatedAsync("ru", 1, token);
            List<Movie> topMovies = movies.Results.ToList<Movie>();
            return topMovies;
        }

        public async Task<List<Movie>> GetUpCommingMoviesData()
        {
            Movies movies = await first.Movies.GetUpcomingAsync("ru", 1, token);
            List<Movie> upcomingMovies = movies.Results.ToList<Movie>();
            return upcomingMovies;
        }

        public async Task<Movie> GetDirectMoveData(int id)
        {
            Movie movie = await first.Movies.GetAsync(id, "ru", true, token);
            return movie;
        }

        public async Task<List<Show>> GetPopularShowsData()
        {
            Shows shows = await first.Shows.GetPopularAsync("ru", 1, token);
            List<Show> popularShows = shows.Results.ToList<Show>();
            return popularShows;
        }

        public async Task<List<Show>> GetNowShowsData()
        {
            Shows shows = await first.Shows.GetAiringAsync("ru", 1, null, token);
            List<Show> nowShows = shows.Results.ToList<Show>();
            return nowShows;
        }

        public async Task<List<Show>> GetTopRatedShowsData()
        {
            Shows shows = await first.Shows.GetTopRatedAsync("ru", 1, token);
            List<Show> topRatedShows = shows.Results.ToList<Show>();
            return topRatedShows;
        }
        
        public async Task<Show> GetDirectShowData(int id)
        {
            Show show = await first.Shows.GetAsync(id, "ru", true, token);
            return show;
        }

        public async Task<Person> GetDirectActorData(int id)
        {
            Person actor = await first.People.GetAsync(id, true, token);
            return actor;
        }

        public async Task<List<PersonCredit>> GetDirectActorMoviesList(int id)
        {
            IEnumerable<PersonCredit> movies = await first.People.GetCreditsAsync(id, "ru", (DataInfoType)1, token);
            List<PersonCredit> actorMovies = movies.ToList<PersonCredit>();
            return actorMovies;
        }

        public async Task<List<string>> GetGenres()
        {
            IEnumerable<Genre> genres = await first.Genres.GetAsync((DataInfoType)1, token);
            List<string> stringGenres = new List<string>();
            foreach (var item in genres)
            {
                stringGenres.Add(item.Name);
            }
            return stringGenres;
        }

        //переделать, чтобы принимал любое множество
        public async Task DownloaderAsync(Movies movies)
        {
            foreach (var item in movies.Results)
            {
                if (!string.IsNullOrEmpty(item.Poster))
                {
                    string filepath = System.IO.Path.Combine(Environment.CurrentDirectory, "Pictures", item.Poster.TrimStart('/'));
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

        public async Task<List<Movie>> GetMoviesByName(string name)
        {
            Movies movies = await first.Movies.SearchAsync(name, "ru", true, null, true, 1, token);
            List<Movie> searchrMovies = movies.Results.ToList<Movie>();
            return searchrMovies;
        }
    }
}

