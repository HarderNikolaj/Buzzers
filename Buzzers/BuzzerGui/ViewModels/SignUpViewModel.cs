using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.ViewModels
{
    public class SignUpViewModel : ViewModelBase, INavigationViewModel
    {
        private IAccountManager _manager;

        public SignUpViewModel(IAccountManager manager)
        {
            _manager = manager;
        }
    }
}
