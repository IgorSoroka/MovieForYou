using MovieForYou.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.TMDb;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieForYou
{
    public class MovieForYouViewModel : ViewModelBase
    {
        ServiceClient first = new ServiceClient("fa314d1331397149188e07fbec92930d");
        CancellationToken token = new CancellationToken();

        private MainDataMovie selectedMovie;

        public MainDataMovie SelectedMovie
        {
            get
            {
                return selectedMovie;
            }
            set
            {
                selectedMovie = value;
                OnPropertyChanged("SelectedMovie");
            }
        }

        private List<MainDataMovie> movies;

        public List<MainDataMovie> Movies
        {
            get
            {
                return movies;
            }
            set
            {
                movies = value;
                OnPropertyChanged("Movies");
            }
        }

        private RelayCommand showPopFilms;

        public RelayCommand ShowPopFilms
        {
            get
            {
                if (showPopFilms == null)
                    showPopFilms = new RelayCommand(ExecuteShowPopFilms);
                return showPopFilms;
            }
        }

        private async void ExecuteShowPopFilms(object param)
        {
            GetData data = new GetData();
            Movies = await data.GetPopularMoviesData();

            List<MainDataMovie> test = new List<MainDataMovie>();
        }
    }
}

