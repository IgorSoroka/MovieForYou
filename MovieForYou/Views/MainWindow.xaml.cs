﻿using Microsoft.Practices.Unity;
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
        private ActorsList _actorsList;
        private Player _player;

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
            _actorsList = _container.Resolve<ActorsList>();
            //_player = _container.Resolve<Player>();

            _region = _regionManager.Regions["ContentRegion"];

            _region.Add(_moviesList);
            _region.Add(_movieSearchViewView);
            _region.Add(_actorSearchViewView);
            _region.Add(_movieView);
            _region.Add(_showsList);
            _region.Add(_showView);
            _region.Add(_actorView);
            _region.Add(_actorsList);
            //_region.Add(_player);
        }

        private void RibbonButton2_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_moviesList);
        }

        private void RibbonButton3_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_showsList);
        }

        private void RibbonButton4_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_movieSearchViewView);
        }

        private void RibbonButton5_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_actorSearchViewView);
        }

        private void RibbonButton6_Click(object sender, RoutedEventArgs e)
        {
            _region.Activate(_actorsList);
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

        private void Player_Click(object sender, RoutedEventArgs e)
        {
            string path = TraillerShow.Tag.ToString();
            _player = _container.Resolve<Player>(new ParameterOverride("str", path));
            _region.Add(_player);
            _region.Activate(_player);
        }
    }
}

