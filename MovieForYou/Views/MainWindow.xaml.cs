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

        ActorSearchView _actorSearchViewView;
        MovieSearchView _movieSearchViewView;
        private MoviesList _moviesList;
        private MovieView _movieView;

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

            _region = _regionManager.Regions["ContentRegion"];

            _region.Add(_actorSearchViewView);
            _region.Add(_movieSearchViewView);
            _region.Add(_moviesList);
            _region.Add(_movieView);
        }

        private void RibbonButton1_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_actorSearchViewView);
        }

        private void RibbonButton2_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_moviesList);
        }

        private void DetailedInfo_OnClick(object sender, RoutedEventArgs e)
        {
            _region.Activate(_movieView);
        }
    }
}

