using Microsoft.Practices.Unity;
using Prism.Regions;
using System.Windows;

namespace MovieForYou.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        IRegion _region;

        private ActorSearchView _actorSearchViewView;
        private MovieSearchView _movieSearchViewView;
        private MoviesList _moviesList;
        private MovieView _movieView;
        private ShowsList _showsList;
        private ShowView _showView;
        private ActorView _actorView;

        public MainWindow(IUnityContainer container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _actorSearchViewView = _container.Resolve<ActorSearchView>();
            _movieSearchViewView = _container.Resolve<MovieSearchView>();
            _moviesList = _container.Resolve<MoviesList>();
            _movieView = _container.Resolve<MovieView>();
            _showsList = _container.Resolve<ShowsList>();
            _showView = _container.Resolve<ShowView>();
            _actorView = _container.Resolve<ActorView>();

            _region = _regionManager.Regions["ContentRegion"];

            _region.Add(_actorSearchViewView);
            _region.Add(_movieSearchViewView);
            _region.Add(_moviesList);
            _region.Add(_movieView);
            _region.Add(_showsList);
            _region.Add(_showView);
            _region.Add(_actorView);
        }

        private void RibbonButton2_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_moviesList);
        }

        private void RibbonButton3_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_showsList);
        }

        private void DetailedInfo_OnClick(object sender, RoutedEventArgs e)
        {
            _region.Activate(_movieView);
        }

        private void DetailedInfoShow_OnClick(object sender, RoutedEventArgs e)
        {
            _region.Activate(_showView);
        }

        private void DetailedInfoActor_OnClick(object sender, RoutedEventArgs e)
        {
            _region.Activate(_actorView);
        }
    }
}

