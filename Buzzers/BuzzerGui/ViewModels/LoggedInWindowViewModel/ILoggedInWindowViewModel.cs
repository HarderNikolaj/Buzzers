using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzerGui.ViewModels
{
    public interface ILoggedInWindowViewModel
    {
        Hivemember LoggedInUser { get; set; }
    }
}
