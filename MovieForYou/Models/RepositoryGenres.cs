using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieForYou.Models
{
    public class RepositoryGenres
    {
        private static readonly IDictionary<string, string> _genres;

        static RepositoryGenres()
        {
            _genres = new Dictionary<string, string>();
            _genres.Add("Action", "Боевик");
            _genres.Add("Adventure", "Приключения");
            _genres.Add("Animation", "Мультфильм");
            _genres.Add("Comedy", "Комедия");
            _genres.Add("Crime", "Криминал");
            _genres.Add("Documentary", "Документальный");
            _genres.Add("Drama", "Драма");
            _genres.Add("Family", "Семейный");
            _genres.Add("History", "Исторический");
            _genres.Add("Horror", "Ужасы");
            _genres.Add("Music", "Мюзикл");
            _genres.Add("Mystery", "Фэнтэзи");
            _genres.Add("Romance", "Мелодрама");
            _genres.Add("Science Fiction", "Научная-фантастика");
            _genres.Add("TV Movie", "Телевизионный");
            _genres.Add("Thriller", "Триллер");
            _genres.Add("War", "Военный");
            _genres.Add("Western", "Вестерн");
        }

        public static string GetEnglishName(string name)
        {
            return _genres.FirstOrDefault(x => x.Value == name).Key;
        }

        public static List<string> GetNames()
        {
            List<string> names = new List<string>();
            foreach (var item in _genres)
            {
                names.Add(item.Value);
            }
            return names;
        }
    }
}
