using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BuzzerGui.ViewModels
{
    public interface IMainWindowViewModel
    {
        string Email { get; set; }
        string Password { get; set; }
        DelegateCommand LogInCommand { get; }
        MemberStory Story { get; }
    }
}
