using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLazyControl.Model;

namespace MvvmLazyControl.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isLazyViewVisible;
        private RelayCommand _loadLazyViewCmd;
        private IWorkVm _workVm;

        public bool IsLazyViewVisible
        {
            get { return _isLazyViewVisible; }
            set { Set(ref _isLazyViewVisible, value); }
        }

        public IWorkVm WorkVm
        {
            get { return _workVm; }
            set { Set(ref _workVm, value); }
        }
        public ICommand LoadLazyViewCmd => _loadLazyViewCmd ?? (_loadLazyViewCmd = new RelayCommand(() =>
                                           {
                                               this.IsLazyViewVisible = true;
                                               this.WorkVm = new WorkVm2();
                                           }));
        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
           
        }

       
    }
}