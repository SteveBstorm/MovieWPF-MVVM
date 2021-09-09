using DAL.Entities;
using MVVMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CorrectifMovieCollection.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        private Movie _entity;

        public string Title
        {
            get { return _entity.Title; }
            set { _entity.Title = value; }
        }

        public string Realisator
        {
            get { return _entity.Realisator; }
            set { _entity.Realisator = value; }

        }

        public int ReleaseYear
        {
            get { return _entity.ReleaseYear; }
            set { _entity.ReleaseYear = value; }

        }

        public string Synopsis
        {
            get { return _entity.Synopsis; }
            set { _entity.Synopsis = value; }

        }

        public DetailViewModel(Movie m)
        {
            _entity = m;
        }

        private ICommand _detailCommand;

        public ICommand Detail
        {
            get { return _detailCommand ?? (_detailCommand = new RelayCommand(GetDetails)); }
        }

        public void GetDetails()
        {
            DetailView dv = new DetailView();
            dv.DataContext = this;
            dv.Show();
        }
    }
}
