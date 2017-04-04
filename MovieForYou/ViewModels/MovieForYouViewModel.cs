using System;
using System.Collections.Generic;
using System.Linq;
using MovieForYou.Models;
using System.Net.TMDb;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieForYou
{
    public class MovieForYouViewModel : ViewModelBase
    {
        static readonly GetData data = new GetData();

        static MovieForYouViewModel()
        {
            GetTopMovies();
            GetBestMovies();
            GetFutureMovies();
            GetBestShows();
            GetPopularShows();
        }

        #region Properties_Movie

        private static List<Movie> _topPopMovies;

        public List<Movie> TopPopMovies
        {
            get
            {
                return _topPopMovies;
            }
        }

        private static List<Movie> _topBestMovies;

        public List<Movie> TopBestMovies
        {
            get
            {
                return _topBestMovies;
            }
        }

        private static List<Movie> _topFutureMovies;

        public List<Movie> TopFutureMovies
        {
            get
            {
                return _topFutureMovies;
            }
        }

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

        #endregion

        #region Properties_Show

        private static List<Show> _topPopShows;

        public List<Show> TopPopShows
        {
            get
            {
                return _topPopShows;
            }
        }

        private static List<Show> _topBestShows;

        public List<Show> TopBestShows
        {
            get
            {
                return _topBestShows;
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

        #endregion

        #region Properties_Other

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
                }
                return _genres;
            }
            set
            {
                _genres = value;
                OnPropertyChanged("Genres");
            }
        }

        private string _selectGenre;

        public string SelectGenre
        {
            get
            {
                return _selectGenre;
            }
            set
            {
                _selectGenre = value;
                OnPropertyChanged("SelectGenre");
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

        private Person _selectedSearchedActor;

        public Person SelectedSearchedActor
        {
            get
            {
                return _selectedSearchedActor;
            }
            set
            {
                _selectedSearchedActor = value;
                OnPropertyChanged("SelectedSearchedActor");
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

        private List<Person> _actorsList;

        public List<Person> ActorsList
        {
            get
            {
                return _actorsList;
            }
            set
            {
                _actorsList = value;
                OnPropertyChanged("ActorsList");
            }
        }

        private int? _selectedYear;

        public int? SelectedYear
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

        private int? _selectedFirstYear;

        public int? SelectedFirstYear
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

        private int? _selectedLastYear;

        public int? SelectedLastYear
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

        private decimal _selectedRating;

        public decimal SelectedRating
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

        private static List<Person> _popularActors;

        public List<Person> PopularActors
        {
            get
            {
                return _popularActors;
            }
            set
            {
                _popularActors = value;
                OnPropertyChanged("PopularActors");
            }
        }



        private string _actorName;

        public string ActorName
        {
            get
            {
                return _actorName;
            }
            set
            {
                _actorName = value;
                OnPropertyChanged("ActorName");
            }
        }


        #endregion

        #region Commands_Movie

        private RelayCommand _movieNameSearch;

        public RelayCommand MovieNameSearch
        {
            get
            {
                if (_movieNameSearch == null)
                    _movieNameSearch = new RelayCommand(ExecuteMovieNameSearch);
                return _movieNameSearch;
            }
        }

        private async void ExecuteMovieNameSearch(object param)
        {
            Movies = await data.GetMoviesByName(Name);
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
            Movies = await data.GetPopularMoviesData();//сделать метод статическим

            //DbWork newDbWork = new DbWork();
            //newDbWork.AddData();

            //GetData data1 = new GetData();
        }

        private RelayCommand _showDirectMovie;

        public RelayCommand ShowDirectMovie
        {
            get
            {
                if (_showDirectMovie == null)
                    _showDirectMovie = new RelayCommand(ExecuteShowDirectMovie, CanExecuteShowDirectMovie);
                return _showDirectMovie;
            }
        }

        private async void ExecuteShowDirectMovie(object param)
        {
            DirectMovie = null;
            Crew = null;
            Cast = null;

            if (SelectedMovie != null)
            {
                var fullDataMovie = await data.GetDirectMoveData(SelectedMovie.Id);//сделать метод статическим
                Crew = (fullDataMovie.Credits.Crew).Take(20).ToList<MediaCrew>();
                Cast = (fullDataMovie.Credits.Cast).Take(10).ToList<MediaCast>();
                DirectMovie = fullDataMovie;

                Video video = await data.GetTrailler(SelectedMovie.Id);
                if (video != null)
                {
                    VideoURL = video.Key;
                }
            }

            if (SelectedActorMovie != null)
            {
                var fullDataMovie = await data.GetDirectMoveData(SelectedActorMovie.Id);//сделать метод статическим
                Crew = (fullDataMovie.Credits.Crew).Take(20).ToList<MediaCrew>();
                Cast = (fullDataMovie.Credits.Cast).Take(10).ToList<MediaCast>();
                DirectMovie = fullDataMovie;

                Video video = await data.GetTrailler(SelectedMovie.Id);
                if (video != null)
                {
                    VideoURL = video.Key;
                }
            }

            SelectedMovie = null;
            SelectedActorMovie = null;
        }

        private bool CanExecuteShowDirectMovie(object param)
        {
            if (SelectedActorMovie == null && SelectedMovie == null)
                return false;
            else
                return true;
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
            Movies = await data.GetTopRatedMoviesData();//сделать метод статическим
        }

        #endregion

        #region Commands_Shows

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
            Shows = await data.GetTopRatedShowsData();//сделать метод статическим
        }

        private RelayCommand _showDirectShow;

        public RelayCommand ShowDirectShow
        {
            get
            {
                if (_showDirectShow == null)
                    _showDirectShow = new RelayCommand(ExecuteShowDirectShow, CanExecuteShowDirectShow);
                return _showDirectShow;
            }
        }

        private async void ExecuteShowDirectShow(object param)
        {
            DirectShow = null;
            Crew = null;
            Cast = null;
            var fullDataShow = await data.GetDirectShowData(SelectedShow.Id);//сделать метод статическим
            Crew = (fullDataShow.Credits.Crew).Take(20).ToList<MediaCrew>();
            Cast = (fullDataShow.Credits.Cast).Take(10).ToList<MediaCast>();
            DirectShow = fullDataShow;
        }

        private bool CanExecuteShowDirectShow(object param)
        {
            if (SelectedShow == null)
                return false;
            else
                return true;
        }

        #endregion

        #region Commands_Other

        private RelayCommand _showPopularActors;

        public RelayCommand ShowPopularActors
        {
            get
            {
                if (_showPopularActors == null)
                    _showPopularActors = new RelayCommand(ExecuteShowPopularActors);
                return _showPopularActors;
            }
        }

        private async void ExecuteShowPopularActors(object param)
        {
            _popularActors = await data.GetPopActors();
        }

        private RelayCommand _actorNameSearch;

        public RelayCommand ActorNameSearch
        {
            get
            {
                if (_actorNameSearch == null)
                    _actorNameSearch = new RelayCommand(ExecuteActorNameSearch);
                return _actorNameSearch;
            }
        }

        private async void ExecuteActorNameSearch(object param)
        {
            ActorsList = await data.GetActorsByName(ActorName);
        }

        private RelayCommand _showDirectActor;

        public RelayCommand ShowDirectActor
        {
            get
            {
                if (_showDirectActor == null)
                    _showDirectActor = new RelayCommand(ExecuteShowDirectActor, CanExecuteShowDirectActor);
                return _showDirectActor;
            }
        }

        private async void ExecuteShowDirectActor(object param)
        {
            DirectActor = null;
            ActorMovies = null;
            if (SelectedActor != null)
            {
                ActorMovies = await data.GetDirectActorMoviesList(SelectedActor.Id);
                DirectActor = await data.GetDirectActorData(SelectedActor.Id);
            }

            if (SelectedSearchedActor != null)
            {
                ActorMovies = await data.GetDirectActorMoviesList(SelectedSearchedActor.Id);
                DirectActor = await data.GetDirectActorData(SelectedSearchedActor.Id);
            }

            SelectedActor = null;
            SelectedSearchedActor = null;
        }

        private bool CanExecuteShowDirectActor(object param)
        {
            if (SelectedActor == null && SelectedSearchedActor == null)
                return false;
            else
                return true;
        }

        private RelayCommand _genreSearch;

        public RelayCommand GenreSearch
        {
            get
            {
                if (_genreSearch == null)
                    _genreSearch = new RelayCommand(ExecuteGenreSearch);
                return _genreSearch;
            }
        }

        private async void ExecuteGenreSearch(object param)
        {
            Movies = null;
            int genre = RepositoryGenres.GetGenreId(SelectGenre);
            Movies = await data.GetListOfMoviesByGenre(genre);
            SelectGenre = null;
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
            Movies = null;
            
            if (SelectedFirstYear == null && SelectedLastYear == null && SelectedYear == null)
                Movies = await data.GetSearchedMovies(SelectedRating);
            else if (SelectedYear != null)
                Movies = await data.GetSearchedMovies(SelectedYear, SelectedRating);
            else if (SelectedFirstYear != null || SelectedLastYear != null)
            {
                if(SelectedFirstYear != null && SelectedLastYear != null)
                    Movies = await data.GetSearchedMovies(SelectedFirstYear, SelectedLastYear, SelectedRating);
                else if (SelectedFirstYear != null && SelectedLastYear == null)
                    Movies = await data.GetSearchedMoviesFirstYear(SelectedFirstYear, SelectedRating);
                else if (SelectedFirstYear == null && SelectedLastYear != null)
                    Movies = await data.GetSearchedMoviesLastYear(SelectedLastYear, SelectedRating);
            }

            SelectedFirstYear = null;
            SelectedLastYear = null;
            SelectedYear = null;
        }

        #endregion

        #region Additional_Methods

        private static async void GetTopMovies()
        {
            List<Movie> intermediate = await data.GetPopularMoviesData();
            _topPopMovies = intermediate.Take(5).ToList<Movie>();
        }

        private static async void GetBestMovies()
        {
            List<Movie> intermediate = await data.GetTopRatedMoviesData();
            _topBestMovies = intermediate.Take(5).ToList<Movie>();
        }

        private static async void GetFutureMovies()
        {
            List<Movie> intermediate = await data.GetUpCommingMoviesData();
            _topFutureMovies = intermediate.Take(5).ToList<Movie>();
        }

        private static async void GetBestShows()
        {
            List<Show> intermediate = await data.GetTopRatedShowsData();
            _topBestShows = intermediate.Take(5).ToList<Show>();
        }

        private static async void GetPopularShows()
        {
            List<Show> intermediate = await data.GetPopularShowsData();
            _topPopShows = intermediate.Take(5).ToList<Show>();
        }

        //корректно ли использован метод????
        private async void GetGenres()
        {
            _genres = await data.GetGenres();
        }

        private List<int> GetYearsList()
        {
            List<int> years = new List<int>();
            for (int i = 2017; i >= 1900; i--)
            {
                years.Add(i);
            }
            return years;
        }

        #endregion

        private Uri _filmUri;

        public Uri FilmUri
        {
            get
            {
                return _filmUri;
            }
        }

        private RelayCommand _videoPlay;

        public RelayCommand VideoPlay
        {
            get
            {
                if (_videoPlay == null)
                    _videoPlay = new RelayCommand(ExecuteVideoPlay, CanExecuteVideoPlay);
                return _videoPlay;
            }
        }
        //Дописать метод под МВВМ
        private async void ExecuteVideoPlay(object param)
        {
            
        }

        private bool CanExecuteVideoPlay(object param)
        {
            if (VideoURL == null)
                return false;
            else
                return true;
        }

        private string _videoURL;

        public string VideoURL
        {
            get
            {
                return _videoURL;
            }
            set
            {
                _videoURL = value;
                OnPropertyChanged("VideoURL");
            }
        }

    }
}