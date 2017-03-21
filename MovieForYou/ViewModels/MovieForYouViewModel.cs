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

        private List<int> _yearsList;
        
        public List<int> YearsList
        {
            get
            {
                if (_yearsList == null)
                {
                    _yearsList = GetYearsList();
                }
                return _yearsList;
            }
            set
            {
                _yearsList = value;
                OnPropertyChanged("YearsList");
            }
        }

        private List<string> _genres;
        //правильно ли так пользоваться свойством
        public List<string> Genres
        {
            get
            {
                if (_genres == null)
                {
                    _genres = RepositoryGenres.GetNames();
                    //GetGenres();
                }
                return _genres;
            }
            set
            {
                _genres = value;
                OnPropertyChanged("Genres");
            }
        }

        private Show _selectedShow;

        public Show SelectedShow
        {
            get
            {
                return _selectedShow;
            }
            set
            {
                _selectedShow = value;
                OnPropertyChanged("SelectedShow");
            }
        }

        private Show _direcctShow;

        public Show DirectShow
        {
            get
            {
                return _direcctShow;
            }
            set
            {
                _direcctShow = value;
                OnPropertyChanged("DirectShow");
            }
        }

        private List<Show> _shows;

        public List<Show> Shows
        { 
            get
            {
                return _shows;
            }
            set
            {
                _shows = value;
                OnPropertyChanged("Shows");
            }
        }

        private PersonCredit _selectedActorMovie;

        public PersonCredit SelectedActorMovie
        {
            get
            {
                return _selectedActorMovie;
            }
            set
            {
                _selectedActorMovie = value;
                OnPropertyChanged("SelectedActorMovie");
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

        private MediaCast _selectedActor;

        public MediaCast SelectedActor
        {
            get
            {
                return _selectedActor;
            }
            set
            {
                _selectedActor = value;
                OnPropertyChanged("SelectedActor");
            }
        }

        private Person _direcctActor;

        public Person DirectActor
        {
            get
            {
                return _direcctActor;
            }
            set
            {
                _direcctActor = value;
                OnPropertyChanged("DirectActor");
            }
        }

        private List<PersonCredit> _actorMovies;

        public List<PersonCredit> ActorMovies
        {
            get
            {
                return _actorMovies;
            }
            set
            {
                _actorMovies = value;
                OnPropertyChanged("ActorMovies");
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
            Movies = null;
            var data = new GetData();//переделать
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
            DirectMovie = null;
            Crew = null;
            Cast = null;
            var data = new GetData();//переделать

            if (SelectedMovie != null)
            {
                var fullDataMovie = await data.GetDirectMoveData(SelectedMovie.Id);//сделать метод статическим
                Crew = fullDataMovie.Credits.Crew.ToList<MediaCrew>();
                Cast = fullDataMovie.Credits.Cast.ToList<MediaCast>();
                DirectMovie = fullDataMovie;
            }

            if (SelectedActorMovie != null)
            {
                var fullDataMovie = await data.GetDirectMoveData(SelectedActorMovie.Id);//сделать метод статическим
                Crew = fullDataMovie.Credits.Crew.ToList<MediaCrew>();
                Cast = fullDataMovie.Credits.Cast.ToList<MediaCast>();
                DirectMovie = fullDataMovie;
            }

            SelectedMovie = null;
            SelectedActorMovie = null;
        }

        private RelayCommand _showNowPlayingFilms;

        public RelayCommand ShowNowPlayingFilms
        {
            get
            {
                if (_showNowPlayingFilms == null)
                    _showNowPlayingFilms = new RelayCommand(ExecuteShowNowPlayingFilms);
                return _showNowPlayingFilms;
            }
        }

        private async void ExecuteShowNowPlayingFilms(object param)
        {
            Movies = null;
            var data = new GetData();//переделать
            Movies = await data.GetNewMoviesData();//сделать метод статическим
        }

        private RelayCommand _showNewFilms;

        public RelayCommand ShowNewFilms
        {
            get
            {
                if (_showNewFilms == null)
                    _showNewFilms = new RelayCommand(ExecuteShowNewFilms);
                return _showNewFilms;
            }
        }

        private async void ExecuteShowNewFilms(object param)
        {
            Movies = null;
            var data = new GetData();//переделать
            Movies = await data.GetUpCommingMoviesData();//сделать метод статическим
        }

        private RelayCommand _showBestFilms;

        public RelayCommand ShowBestFilms
        {
            get
            {
                if (_showBestFilms == null)
                    _showBestFilms = new RelayCommand(ExecuteShowBestFilms);
                return _showBestFilms;
            }
        }

        private async void ExecuteShowBestFilms(object param)
        {
            Movies = null;
            var data = new GetData();//переделать
            Movies = await data.GetTopRatedMoviesData();//сделать метод статическим
        }

        private RelayCommand _showPopShows;

        public RelayCommand ShowPopShows
        {
            get
            {
                if (_showPopShows == null)
                    _showPopShows = new RelayCommand(ExecuteShowPopShows);
                return _showPopShows;
            }
        }

        private async void ExecuteShowPopShows(object param)
        {
            Shows = null;
            var data = new GetData();//переделать
            Shows = await data.GetPopularShowsData();//сделать метод статическим
        }

        private RelayCommand _showNowShows;

        public RelayCommand ShowNowShows
        {
            get
            {
                if (_showNowShows == null)
                    _showNowShows = new RelayCommand(ExecuteShowNowShows);
                return _showNowShows;
            }
        }

        private async void ExecuteShowNowShows(object param)
        {
            Shows = null;
            var data = new GetData();//переделать
            Shows = await data.GetNowShowsData();//сделать метод статическим
        }

        private RelayCommand _showBestShows;

        public RelayCommand ShowBestShows
        {
            get
            {
                if (_showBestShows == null)
                    _showBestShows = new RelayCommand(ExecuteShowBestShows);
                return _showBestShows;
            }
        }

        private async void ExecuteShowBestShows(object param)
        {
            Shows = null;
            var data = new GetData();//переделать
            Shows = await data.GetTopRatedShowsData();//сделать метод статическим
        }

        private RelayCommand _showDirectShow;

        public RelayCommand ShowDirectShow
        {
            get
            {
                if (_showDirectShow == null)
                    _showDirectShow = new RelayCommand(ExecuteShowDirectShow);
                return _showDirectShow;
            }
        }

        private async void ExecuteShowDirectShow(object param)
        {
            DirectShow = null;
            Crew = null;
            Cast = null;
            var data = new GetData();//переделать
            var fullDataShow = await data.GetDirectShowData(SelectedShow.Id);//сделать метод статическим
            Crew = fullDataShow.Credits.Crew.ToList<MediaCrew>();
            Cast = fullDataShow.Credits.Cast.ToList<MediaCast>();
            DirectShow = fullDataShow;
        }

        private RelayCommand _showDirectActor;

        public RelayCommand ShowDirectActor
        {
            get
            {
                if (_showDirectActor == null)
                    _showDirectActor = new RelayCommand(ExecuteShowDirectActor);
                return _showDirectActor;
            }
        }

        private async void ExecuteShowDirectActor(object param)
        {
            DirectActor = null;
            ActorMovies = null;
            var data = new GetData();//переделать
            ActorMovies = await data.GetDirectActorMoviesList(SelectedActor.Id);
            DirectActor = await data.GetDirectActorData(SelectedActor.Id);
        }



        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private RelayCommand _search;

        public RelayCommand Search
        {
            get
            {
                if (_search == null)
                    _search = new RelayCommand(ExecuteSearch);
                return _search;
            }
        }

        private async void ExecuteSearch(object param)
        {

        }

        private RelayCommand _nameSearch;

        public RelayCommand NameSearch
        {
            get
            {
                if (_nameSearch == null)
                    _nameSearch = new RelayCommand(ExecuteNameSearch);
                return _nameSearch;
            }
        }

        private async void ExecuteNameSearch(object param)
        {
            GetData data = new GetData();
            Movies = await data.GetMoviesByName(Name);
        }

        private int _selectedYear;

        public int SelectedYear
        {
            get
            {
                return _selectedYear;
            }
            set
            {
                _selectedYear = value;
                OnPropertyChanged("SelectedYear");
            }
        }

        private int _selectedFirstYear;

        public int SelectedFirstYear
        {
            get
            {
                return _selectedFirstYear;
            }
            set
            {
                _selectedFirstYear = value;
                OnPropertyChanged("SelectedFirstYear");
            }
        }

        private int _selectedLastYear;

        public int SelectedLastYear
        {
            get
            {
                return _selectedLastYear;
            }
            set
            {
                _selectedLastYear = value;
                OnPropertyChanged("SelectedLastYear");
            }
        }

        private double _selectedRating;

        public double SelectedRating
        {
            get
            {
                return _selectedRating;
            }
            set
            {
                _selectedRating = value;
                OnPropertyChanged("SelectedRating");
            }
        }

        //корректно ли использован метод????
        private async void GetGenres()
        {
            GetData data = new GetData();
            _genres = await data.GetGenres();
        }

        private List<int> GetYearsList()
        {
            List<int> years = new List<int>();
            for (int i = 1900; i <= 2017; i++)
            {
                years.Add(i);
            }
            return years;
        }
    }
}