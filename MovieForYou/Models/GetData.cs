using System;
using System.Collections.Generic;
using System.IO;
using System.Net.TMDb;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace MovieForYou.Models
{
    public class GetData
    {
        ServiceClient first = new ServiceClient("fa314d1331397149188e07fbec92930d");
        CancellationToken token = new CancellationToken();

        public async Task<List<Movie>> GetPopularMoviesData()
        {
            Movies movies = await first.Movies.GetPopularAsync(null, 1, token);
            List<Movie> popularMovies = movies.Results.ToList<Movie>();
            return popularMovies;
        }

        public async Task<List<Movie>> GetNewMoviesData()
        {
            Movies movies = await first.Movies.GetNowPlayingAsync(null, 1, token);
            List<Movie> newMovies = movies.Results.ToList<Movie>();
            return newMovies;
        }

        public async Task<List<Movie>> GetTopRatedMoviesData()
        {
            Movies movies = await first.Movies.GetTopRatedAsync(null, 1, token);
            List<Movie> topMovies = movies.Results.ToList<Movie>();
            return topMovies;
        }

        public async Task<List<Movie>> GetUpCommingMoviesData()
        {
            Movies movies = await first.Movies.GetUpcomingAsync(null, 1, token);
            List<Movie> upcomingMovies = movies.Results.ToList<Movie>();
            return upcomingMovies;
        }

        public async Task<Movie> GetDirectMoveData(int id)
        {
            Movie movie = await first.Movies.GetAsync(id, null, true, token);
            return movie;
        }

        public async Task<List<Show>> GetPopularShowsData()
        {
            Shows shows = await first.Shows.GetPopularAsync(null, 1, token);
            List<Show> popularShows = shows.Results.ToList<Show>();
            return popularShows;
        }

        public async Task<List<Show>> GetNowShowsData()
        {
            Shows shows = await first.Shows.GetAiringAsync(null, 1, null, token);
            List<Show> nowShows = shows.Results.ToList<Show>();
            return nowShows;
        }

        public async Task<List<Show>> GetTopRatedShowsData()
        {
            Shows shows = await first.Shows.GetTopRatedAsync(null, 1, token);
            List<Show> topRatedShows = shows.Results.ToList<Show>();
            return topRatedShows;
        }
        
        public async Task<Show> GetDirectShowData(int id)
        {
            Show show = await first.Shows.GetAsync(id, null, true, token);
            return show;
        }

        public async Task<Person> GetDirectActorData(int id)
        {
            Person actor = await first.People.GetAsync(id, true, token);
            return actor;
        }

        public async Task<List<PersonCredit>> GetDirectActorMoviesList(int id)
        {
            IEnumerable<PersonCredit> movies = await first.People.GetCreditsAsync(id, null, (DataInfoType)1, token);
            List<PersonCredit> actorMovies = movies.ToList<PersonCredit>();
            return actorMovies;
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
    }
}

