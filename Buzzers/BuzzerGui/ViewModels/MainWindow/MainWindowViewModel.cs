using Application;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DBObjects;

namespace BuzzerGui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private IAccountManager _manager;

        private string _email;
        private string _password;

        public MainWindowViewModel()
        {
            var Story = _manager.GetMemberstory();
        }
        public MemberStory Story { get; set; }
       
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand LogInCommand { get; private set; }

        public MainWindowViewModel(IAccountManager manager)
        {
            _manager = manager;
            
            LogInCommand = new DelegateCommand(() => LogIn());
        }

        private void LogIn()
        {
            var member = _manager.Login(_email, _password);
        }
    }
}
