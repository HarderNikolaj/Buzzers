using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.ViewModels
{
    public class DetailsViewModel : ViewModelBase, INavigationViewModel
    {
        private IAccountManager _manager;
        public DetailsViewModel(IAccountManager manager)
        {
            _manager = manager;
        }
    }
}
