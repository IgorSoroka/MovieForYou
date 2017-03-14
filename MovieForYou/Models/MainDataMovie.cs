using System;
using System.Collections.Generic;
using System.Net.TMDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieForYou.Models
{
    public class MainDataMovie
    {
        //public IEnumerable<Country> Countries { get; }
        //public MediaCredits Credits { get; }        
        //public IEnumerable<Genre> Genres { get; }
        //public string Overview { get; }
        //public decimal Popularity { get; }
        //public int? Runtime { get; }

        public MainDataMovie() { }

        public MainDataMovie(string OriginalTitle, string Poster, DateTime? ReleaseDate, string Title, decimal VoteAverage)
        {
            this.OriginalTitle = OriginalTitle;
            this.Poster = Poster;
            this.ReleaseDate = ReleaseDate;
            this.Title = Title;
            this.VoteAverage = VoteAverage;
        }

        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Poster { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal VoteAverage { get; set; }
    }
}
