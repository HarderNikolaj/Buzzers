using Application;
using BuzzerGui.Utility;
using Domain.Enums;
using Domain.Users;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuzzerGui.ViewModels
{
    public class SignUpViewModel : ViewModelBase, INavigationViewModel
    {
        private IAccountManager _manager;
        private UserType _userType;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public UserType UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                OnPropertyChanged();
            }
        }
        public Gender Gender { get; set; }
        public string ProfilePicturePath { get; set; }

        public ICommand SignUpCommand { get; private set; }
        public ICommand SelectProfilePictureCommand { get; private set; }

        public IList<UserType> UserTypes
        {
            get => Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();
        }
        public IList<Gender> Genders
        {
            get => Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
        }

        public SignUpViewModel(IAccountManager manager)
        {
            _manager = manager;

            SignUpCommand = new DelegateCommand(SignUp, CanSignUp).ObservesProperty(() => UserType);
            SelectProfilePictureCommand = new DelegateCommand(OpenFileExplorer);

            Birthday = DateTime.Today;
        }

        private void OpenFileExplorer()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                ProfilePicturePath = dialog.FileName;
            }
        }

        private void SignUp()
        {
            switch (UserType)
            {
                case UserType.Bee:
                    var bee = new Bee()
                    {
                        Images = new List<string>
                        {
                            ProfilePicturePath
                        },
                        
                        FirstName = FirstName,
                        LastName = LastName,
                        Gender = Gender,
                        Email = Email,
                        BirthDate = Birthday,
                        
                    };
                    _manager.CreateUser(bee, Password);
                    Messenger.Default.Send(bee);
                    break;
                case UserType.Honeypot:
                    var honeypot = new Honeypot()
                    {
                        Images = new List<string>
                        {
                            ProfilePicturePath
                        },

                        FirstName = FirstName,
                        LastName = LastName,
                        Gender = Gender,
                        Email = Email,
                        BirthDate = Birthday
                        //jobtitle
                    };
                    _manager.CreateUser(honeypot, Password);
                    Messenger.Default.Send(honeypot);
                    break;
                default:
                    break;
            }
        }

        private bool CanSignUp()
        {
            return UserType == UserType.Honeypot || UserType == UserType.Bee;
        }
    }
}
