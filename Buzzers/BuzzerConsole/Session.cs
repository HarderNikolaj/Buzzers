using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using Application;
using Domain.Enums;

namespace BuzzerConsole
{
    class Session
    {
        private Hivemember UserLoggedIn { get; set; }
        private IAccountManager _manager { get; set; }

        public Session(IAccountManager accountManager)
        {
            _manager = accountManager;
        }

        private void Header()
        {
            Console.Clear();
            if (UserLoggedIn == null)
                Console.WriteLine("Buzzers - Login");
            else
                Console.Write($"Buzzers - {UserLoggedIn.Nickname ?? UserLoggedIn.FirstName}\n\n");
        }

        private void Login()
        {
            Header();
            Console.Write("Email: ");
            var login = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();

            UserLoggedIn = _manager.Login(login, password);
        }
        private void CreateUser()
        {
            try
            {
                Header();
                Console.WriteLine("Firstname: ");
                var firstname = Console.ReadLine();
                Console.WriteLine("Lastname: ");
                var lastname = Console.ReadLine();
                Console.WriteLine("Email: ");
                var email = Console.ReadLine();
                Console.WriteLine("Password: ");
                var password = Console.ReadLine();
                Console.WriteLine("Gender (1: Female / 2: Male: ");
                int gender;
                int.TryParse(Console.ReadLine(), out gender);
                Console.WriteLine("Birthdate (\"dd/MM/YYYY\"): ");
                var birthdate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Usertype(1: Bee / 2: Honeypot");
                int usertype;
                int.TryParse(Console.ReadLine(), out usertype);
                if (usertype == 1)
                {
                    var newMember = new Bee()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Gender = (Gender)gender,
                        Email = email,
                        BirthDate = birthdate,
                    };
                    _manager.CreateUser(newMember, password);
                }
                else if (usertype == 2)
                {
                    Console.WriteLine("Jobtitle: ");
                    var jobTitle = Console.ReadLine();

                    var newMember = new Honeypot()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Gender = (Gender)gender,
                        Email = email,
                        BirthDate = birthdate,
                        JobTitle = jobTitle
                    };
                    _manager.CreateUser(newMember, password);
                }
        }
            catch (Exception)
            {
                Header();
        Console.WriteLine("Something went wrong. Please try again.");
                System.Threading.Thread.Sleep(2000);
            }

}
        public void LoginScreen()
        {
            while (UserLoggedIn is null)
            {
                Console.Clear();
                Header();
                Console.WriteLine("1: Login.\n2: Create New User.");
                var answer = Console.ReadKey().KeyChar;
                switch (answer)
                {
                    case '1':
                        Login();
                        break;
                    case '2':
                        CreateUser();
                        break;
                    default:
                        break;
                }
            }
            MainScreen();
        }
        private void MainScreen()
        {
            while (UserLoggedIn != null)
            {
                Header();
                Console.WriteLine("1: Browse Buzzer.\n2: View your preferences.\n3: View your beetails.\n9: Log out.");
                var answer = Console.ReadKey().KeyChar;
                switch (answer)
                {
                    case '1':
                        Hivemember PotentialMatch = null;
                        if (UserLoggedIn.GetType().ToString() == "Domain.Users.Honeypot")
                        {
                            PotentialMatch = _manager.GetBee(UserLoggedIn.Id);
                        }
                        else if (UserLoggedIn.GetType().ToString() == "Domain.Users.Bee")
                        {
                            PotentialMatch = _manager.GetHoneypot(UserLoggedIn.Id);
                        }
                        DisplayBee(PotentialMatch);
                        if (PotentialMatch != null)
                        {
                            BuzzMenu(PotentialMatch);
                        }
                        break;
                    case '2':
                        PreferenceMenu();
                        break;
                    case '3':
                        break;
                    case '9':
                        UserLoggedIn = null;
                        LoginScreen();
                        break;
                    default:
                        break;

                }
            }
        }
        private void DisplayBee(Hivemember User)
        {
            if (User == null)
            {
                Console.WriteLine("There are no more users that meet your preferences.\nTry lowering your standards if you want to get some.");
            }
            else
            {

                Header();
                Console.WriteLine($"Name: {User.Nickname ?? User.FirstName + ' ' + User.LastName}\nAge: {User.GetAge()}");
                if (User.GetType().ToString() == "Honeypot")
                {
                    var user = (Honeypot)User;
                    Console.WriteLine($"Job: {user.JobTitle}");
                }
                else if (User.GetType().ToString() == "Bee")
                {
                    var user = (Bee)User;
                    Console.WriteLine($"Weight: {user.Weight}");
                }
            }

        }
        private void PreferenceMenu()
        {
            UserLoggedIn.BeginEdit();
            char preferenceAnswer;
            do
            {
                Header();
                Console.WriteLine($"Interested in:\n(1) Males: {UserLoggedIn.Preferences.AttractionMales.ToString() ?? "Not set"}\n(2) Females: {UserLoggedIn.Preferences.AttracitonFemales.ToString() ?? "Not set"}\n(8) Submit Changes.\n(9) Discard Changes.");
                preferenceAnswer = Console.ReadKey().KeyChar;
                switch (preferenceAnswer)
                {
                    case '1':
                        UserLoggedIn.Preferences.AttractionMales = !UserLoggedIn.Preferences.AttractionMales;
                        break;
                    case '2':
                        UserLoggedIn.Preferences.AttracitonFemales = !UserLoggedIn.Preferences.AttracitonFemales;
                        break;
                    case '8':
                        _manager.Edit(UserLoggedIn);
                        UserLoggedIn.EndEdit();
                        break;
                    case '9':
                        UserLoggedIn.CancelEdit();
                        break;
                    default:
                        break;
                }

            } while (preferenceAnswer != '9' && preferenceAnswer != '8');
        }

        private void BeetailsMenu()
        {
            Header();
            Console.WriteLine($"(1) Nickname: {UserLoggedIn.Nickname.ToString() ?? "Not Set"}\n(2) Bio: {UserLoggedIn.Bio.ToString() ?? "Not Set"}");
        }

        private void BuzzMenu(Hivemember potentialMatch)
        {
            Console.WriteLine("(1) Buzz\n(2) Reject\n(9) Return");
            char buzzAnswer;
            do
            {
                buzzAnswer = Console.ReadKey().KeyChar;
                switch (buzzAnswer)
                {
                    case '1':
                        _manager.Buzz(UserLoggedIn, potentialMatch, true);
                        break;
                    case '2':
                        _manager.Buzz(UserLoggedIn, potentialMatch, true);
                        break;
                    default:
                        break;
                }
            } while (buzzAnswer != '1' && buzzAnswer != '2' && buzzAnswer != '9');

        }
    }

}