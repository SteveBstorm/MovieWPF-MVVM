using DAL.Entities;
using DAL.Services;
using MVVMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CorrectifMovieCollection.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private MovieService _movieService;

        public MainViewModel()
        {
            _movieService = new MovieService();
            GetValues();
        }

      

        private ObservableCollection<DetailViewModel> _movieList;

        public ObservableCollection<DetailViewModel> MovieList
        {
            get { return _movieList; }
            set
            {
                if (value != _movieList)
                {
                    _movieList = value;
                    RaisePropertyChanged(nameof(MovieList));

                }
            }
        }

        public void GetValues()
        {
            MovieList = new ObservableCollection<DetailViewModel>();
            foreach (Movie movie in _movieService.GetAll())
            {
                MovieList.Add(new DetailViewModel(movie));
            }
        }

        private string _title, _synopsis, _realisator;
        private int _releaseYear;

        #region Properties
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }

        public string Synopsis
        {
            get { return _synopsis; }
            set
            {
                if (value != _synopsis)
                {
                    _synopsis = value;
                    RaisePropertyChanged(nameof(Synopsis));
                }
            }
        }

        public string Realisator
        {
            get { return _realisator; }
            set
            {
                if (value != _realisator)
                {
                    _realisator = value;
                    RaisePropertyChanged(nameof(Realisator));
                }
            }
        }

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set
            {
                if (value != _releaseYear)
                {
                    _releaseYear = value;
                    RaisePropertyChanged(nameof(ReleaseYear));
                }
            }
        }
        #endregion

        private ICommand _ajout;

        public ICommand Ajout
        {
            get { return _ajout ?? (_ajout = new RelayCommand(AddMovie)); }
        }

       
        

        public void AddMovie()
        {
            Movie newMovie = new Movie()
            {
                Title = Title,
                Synopsis = Synopsis,
                ReleaseYear = ReleaseYear,
                Realisator = Realisator
            };

            _movieService.Insert(newMovie);

            GetValues();
        }
    }
}
