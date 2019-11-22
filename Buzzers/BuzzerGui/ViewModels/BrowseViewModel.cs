using Application;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuzzerGui.Utility;

namespace BuzzerGui.ViewModels
{
    public class BrowseViewModel : ViewModelBase
    {
        private Hivemember potentialMatch { get; set; }
        private IAccountManager _manager;
        public Hivemember PotentialMatch 
        { 
            get => potentialMatch;
            set 
            {
                if (true)
                {
                    _manager.GetBee(1);
                }
                else if (true)
                {
                    _manager.GetHoneypot(1);
                }
            }
        }

        public BrowseViewModel(IAccountManager accountManager) 
        {
            //Messenger.Default.
            _manager = accountManager;
        }
       
    }
}
