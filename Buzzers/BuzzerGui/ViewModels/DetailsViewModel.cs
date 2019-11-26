using Application;
using BuzzerGui.Utility;
using BuzzerGui.Utility.Messages;
using Domain.Users;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace BuzzerGui.ViewModels
{
    public class DetailsViewModel : ViewModelBase, INavigationViewModel
    {
        private IAccountManager _manager;
        private Hivemember _user;


        public Hivemember User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangeProfilePictureCommand { get; private set; }
        public ICommand SaveChangesCommand { get; private set; }
        public ICommand CancelChangesCommand { get; private set; }

        public DetailsViewModel(IAccountManager manager)
        {
            _manager = manager;

            ChangeProfilePictureCommand = new DelegateCommand(ChangeProfilePicture);
            SaveChangesCommand = new DelegateCommand(SaveChanges);
            CancelChangesCommand = new DelegateCommand(CancelChanges);

            Messenger.Default.Register<DetailsMessage>(this, CurrentUser);
        }

        private void ChangeProfilePicture()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                User.Images[0] = dialog.FileName;
                Messenger.Default.Send(new BitmapImage(new Uri(User.Images[0], UriKind.Absolute)));
            }
        }

        private void SaveChanges()
        {
            _manager.Edit(User);
            User.EndEdit();
        }

        private void CancelChanges()
        {
            User.CancelEdit();
            OnPropertyChanged("User");
        }

        private void CurrentUser(DetailsMessage obj)
        {
            User = obj.Hivemember;
            User.BeginEdit();
        }
    }
}
