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
using System.Windows.Input;
using BuzzerGui.Utility.Messages;

namespace BuzzerGui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private List<INavigationViewModel> _viewModels;
        private INavigationViewModel _currentViewModel;

        public Hivemember UserLoggedIn { get; set; }

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

        public ICommand BrowseViewCommand { get; private set; }

        public MainWindowViewModel(IAccountManager manager)
        {
            ViewModels.Add(new LoginViewModel(manager));
            ViewModels.Add(new BrowseViewModel(manager));
            ViewModels.Add(new SignUpViewModel(manager));
            CurrentViewModel = ViewModels[0];

            BrowseViewCommand = new DelegateCommand(SwitchToBrowseView);

            Messenger.Default.Register<SignUpMessage>(this, SwitchToSignUpView);
            Messenger.Default.Register<Hivemember>(this, NewUser);
        }

        private void NewUser(Hivemember obj)
        {
            UserLoggedIn = obj;
            SwitchToBrowseView();           
        }

        private void ChangeViewModel(INavigationViewModel viewModel)
        {
            if (UserLoggedIn == null) return;

            if (!ViewModels.Contains(viewModel))
            {
                ViewModels.Add(viewModel);
            }
            CurrentViewModel = ViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        private void SwitchToBrowseView()
        {
            if (UserLoggedIn == null) return;

            ChangeViewModel(ViewModels[1]);
            Messenger.Default.Send(new BrowseMessage(UserLoggedIn));
        }
        private void SwitchToSignUpView(SignUpMessage s)
        {
            CurrentViewModel = ViewModels[2];
        }
    }
}
