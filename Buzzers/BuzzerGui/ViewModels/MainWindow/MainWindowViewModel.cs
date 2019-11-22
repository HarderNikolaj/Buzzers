using Application;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BuzzerGui.Utility;

namespace BuzzerGui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private ViewModelBase _context;
        public ViewModelBase Context
        {
            get => _context;
            set
            {
                _context = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel LoginViewModel { get; private set; }
        public MainWindowViewModel()
        {
            LoginViewModel = new LoginViewModel();
            Context = LoginViewModel;
        }
    }
}
