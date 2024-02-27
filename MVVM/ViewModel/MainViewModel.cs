using CalculatorApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.MVVM.ViewModel
{
    class MainViewModel : ObservebleObject
    {

        public RelayCommand HomeViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                onPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(x =>
            {
                CurrentView = HomeVm;
            });

        }
    }
}
