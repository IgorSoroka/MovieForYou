using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.TMDb;
using System.Text;
using System.Threading.Tasks;

namespace MovieForYou
{
    public class FullDataMovie
    {
        public bool Adult { get; }
        public AlternativeTitles AlternativeTitles { get; }
        public string Backdrop { get; }
        public Collection BelongsTo { get; }
        public int Budget { get; }
        public IEnumerable<Company> Companies { get; }
        public IEnumerable<Country> Countries { get; }
        public MediaCredits Credits { get; }
        public ExternalIds External { get; }
        public IEnumerable<Genre> Genres { get; }
        public string HomePage { get; }
        public Images Images { get; }
        public string Imdb { get; }
        public Keywords Keywords { get; }
        public IEnumerable<Language> Languages { get; }
        public string OriginalTitle { get; }
        public string Overview { get; }
        public decimal Popularity { get; }
        public string Poster { get; }
        public DateTime? ReleaseDate { get; }
        public Releases Releases { get; }
        public long Revenue { get; }
        public int? Runtime { get; }
        public string Status { get; }
        public string TagLine { get; }
        public string Title { get; }
        public Translations Translations { get; }
        public Videos Videos { get; }
        public decimal VoteAverage { get; }
        public int VoteCount { get; }
    }
}
