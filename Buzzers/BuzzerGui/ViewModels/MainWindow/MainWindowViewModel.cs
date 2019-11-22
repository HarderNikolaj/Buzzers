using Application;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BuzzerGui.Utility;
using Domain.Users;

namespace BuzzerGui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private List<INavigationViewModel> _viewModels;
        private INavigationViewModel _currentViewModel;

        public Hivemember userloggedin;
        public Hivemember Userloggedin
        {
            get => userloggedin;
            set
            {
            }
        }

        public List<INavigationViewModel> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new List<INavigationViewModel>();
                }
                return _viewModels;
            }
        }
        public INavigationViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(IAccountManager manager)
        {
            ViewModels.Add(new LoginViewModel(manager));
            CurrentViewModel = ViewModels[0];
            Messenger.Default.Register<Hivemember>(this, NewUser);

        }

        private void NewUser(Hivemember obj)
        {
            userloggedin = obj;
        }

        private void ChangeViewModel(INavigationViewModel viewModel)
        {
            if (!ViewModels.Contains(viewModel))
            {
                ViewModels.Add(viewModel);
            }
            CurrentViewModel = ViewModels.FirstOrDefault(vm => vm == viewModel);
        }
    }
}
