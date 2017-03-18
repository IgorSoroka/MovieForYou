using System.Collections.Generic;
using System.Linq;
using MovieForYou.Models;
using System.Net.TMDb;

namespace MovieForYou
{
    public class MovieForYouViewModel : ViewModelBase
    {
        private Movie _selectedMovie;

        public Movie SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged("SelectedMovie");
            }
        }

        private Movie _direcctMovie;

        public Movie DirectMovie
        {
            get
            {
                return _direcctMovie;
            }
            set
            {
                _direcctMovie = value;
                OnPropertyChanged("DirectMovie");
            }
        }

        private List<Movie> _movies;

        public List<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
                OnPropertyChanged("Movies");
            }
        }

        private List<MediaCast> _cast;

        public List<MediaCast> Cast
        {
            get
            {
                return _cast;
            }
            set
            {
                _cast = value;
                OnPropertyChanged("Cast");
            }
        }

        private List<MediaCrew> _crew;

        public List<MediaCrew> Crew
        {
            get
            {
                return _crew;
            }
            set
            {
                _crew = value;
                OnPropertyChanged("Crew");
            }
        }

        private RelayCommand _showPopFilms;

        public RelayCommand ShowPopFilms
        {
            get
            {
                if (_showPopFilms == null)
                    _showPopFilms = new RelayCommand(ExecuteShowPopFilms);
                return _showPopFilms;
            }
        }

        private async void ExecuteShowPopFilms(object param)
        {
            GetData data = new GetData();//переделать
            Movies = await data.GetPopularMoviesData();//сделать метод статическим
        }

        private RelayCommand _showDirectMovie;

        public RelayCommand ShowDirectMovie
        {
            get
            {
                if (_showDirectMovie == null)
                    _showDirectMovie = new RelayCommand(ExecuteShowDirectMovie);
                return _showDirectMovie;
            }
        }

        private async void ExecuteShowDirectMovie(object param)
        {
            GetData data = new GetData();//переделать
            Movie fullDataMovie = await data.GetDirectMoveData(SelectedMovie.Id);//сделать метод статическим

            Crew = fullDataMovie.Credits.Crew.ToList<MediaCrew>();
            Cast = fullDataMovie.Credits.Cast.ToList<MediaCast>();

            DirectMovie = fullDataMovie;}
    }
}