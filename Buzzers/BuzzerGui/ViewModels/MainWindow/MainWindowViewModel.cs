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
using System.Windows.Media.Imaging;

namespace BuzzerGui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private List<INavigationViewModel> _viewModels;
        private INavigationViewModel _currentViewModel;
        private Hivemember _userLoggedIn;
        private BitmapImage _profilePicture;

        public Hivemember UserLoggedIn
        {
            get => _userLoggedIn;
            set
            {
                _userLoggedIn = value;
                OnPropertyChanged();
            }
        }
        public BitmapImage ProfilePicture
        {
            get => _profilePicture;
            set
            {
                _profilePicture = value;
                OnPropertyChanged();
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

        public ICommand BrowseViewCommand { get; private set; }
        public ICommand DetailsViewCommand { get; private set; }
        public ICommand MatchesViewCommand { get; private set; }
        public MainWindowViewModel(IAccountManager manager)
        {
            ViewModels.Add(new LoginViewModel(manager));
            ViewModels.Add(new BrowseViewModel(manager));
            ViewModels.Add(new SignUpViewModel(manager));
            ViewModels.Add(new DetailsViewModel(manager));
            ViewModels.Add(new MatchesViewModel(manager));
            CurrentViewModel = ViewModels[0];

            BrowseViewCommand = new DelegateCommand(SwitchToBrowseView);
            DetailsViewCommand = new DelegateCommand(SwitchToDetailsView);
            MatchesViewCommand = new DelegateCommand(SwitchToMatchesView);

            Messenger.Default.Register<SignUpMessage>(this, SwitchToSignUpView);
            Messenger.Default.Register<Hivemember>(this, NewUser);
            Messenger.Default.Register<BitmapImage>(this, NewProfilePicture);
            Messenger.Default.Register<UserCreatedMessage>(this, SwitchToLoginView);
        }

        private void NewProfilePicture(BitmapImage obj)
        {
            try
            {
                ProfilePicture = obj;
            }
            catch (Exception)
            {
            }
        }

        private void NewUser(Hivemember obj)
        {
            UserLoggedIn = obj;
            ProfilePicture = new BitmapImage(new Uri(obj.Images[0]));
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
        private void SwitchToDetailsView()
        {
            if (UserLoggedIn == null) return;

            ChangeViewModel(ViewModels[3]);
            Messenger.Default.Send(new DetailsMessage(UserLoggedIn));
            
        }


        private void SwitchToMatchesView()
        {
            ChangeViewModel(ViewModels[4]);
            Messenger.Default.Send(new MatchesMessage(UserLoggedIn));
        }
        private void SwitchToSignUpView(SignUpMessage s)
        {
            CurrentViewModel = ViewModels[2];
        }
        private void SwitchToLoginView(UserCreatedMessage e)
        {
            CurrentViewModel = ViewModels[0];
        }
    }
}
