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
        
        public async Task<Movie> GetDirectMoveData(int id)
        {
            Movie movie = await first.Movies.GetAsync(id, null, true, token);
            return movie;
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

