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
        private static readonly IDictionary<int, string> _genres;

        static RepositoryGenres()
        {
            _genres = new Dictionary<int, string>();
            _genres.Add(1, "Боевик");
            _genres.Add(2, "Приключения");
            _genres.Add(3, "Мультфильм");
            _genres.Add(4, "Комедия");
            _genres.Add(5, "Криминал");
            _genres.Add(6, "Документальный");
            _genres.Add(7, "Драма");
            _genres.Add(8, "Семейный");
            _genres.Add(9, "Исторический");
            _genres.Add(10, "Ужасы");
            _genres.Add(11, "Мюзикл");
            _genres.Add(12, "Фэнтэзи");
            _genres.Add(13, "Мелодрама");
            _genres.Add(14, "Научная-фантастика");
            _genres.Add(15, "Телевизионный");
            _genres.Add(16, "Триллер");
            _genres.Add(17, "Военный");
            _genres.Add(18, "Вестерн");
        }

        public static int GetId(string name)
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
