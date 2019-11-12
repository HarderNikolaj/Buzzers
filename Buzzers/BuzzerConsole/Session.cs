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
    class Session : ISession
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
                Console.WriteLine("1: Login.\n2: Create New User\n9: Buzz-out.");
                var answer = Console.ReadKey().KeyChar;
                switch (answer)
                {
                    case '1':
                        Login();
                        break;
                    case '2':
                        CreateUser();
                        break;
                    case '9':
                        Environment.Exit(0);
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
                Console.WriteLine("1: Browse Buzzer.\n2: View your preferences.\n3: View your beetails.\n4: View Matches\n9: Log out.");
                char answer;
                answer = Console.ReadKey(true).KeyChar;
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
                        BeetailsMenu();
                        break;
                    case '4':
                        MatchMenu();
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
                Header();
                Console.WriteLine("There are no more users that meet your preferences.\nTry lowering your standards if you want to get some.");
                Console.ReadKey();
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
                preferenceAnswer = Console.ReadKey(true).KeyChar;
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
            UserLoggedIn.BeginEdit();
            char beetailsAnswer;
            do
            {
                Header();
                Console.WriteLine($"(1) Nickname: {UserLoggedIn.Nickname ?? "Not Set"}\n(2) Bio: {UserLoggedIn.Bio ?? "Not Set"}\n(8) Submit Changes.\n(9) Discard Changes.");
                beetailsAnswer = Console.ReadKey(true).KeyChar;
                switch (beetailsAnswer)
                {
                    case '1':
                        Console.WriteLine("Enter a new nickname");
                        UserLoggedIn.Nickname = Console.ReadLine();
                        break;
                    case '2':
                        Console.WriteLine("Enter a new Bio");
                        UserLoggedIn.Bio = Console.ReadLine();
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

            } while (beetailsAnswer != '9' && beetailsAnswer != '8');
        }
        private void BuzzMenu(Hivemember potentialMatch)
        {
            Console.WriteLine("(1) Buzz\n(2) Reject\n(9) Return");
            char buzzAnswer;
            do
            {
                buzzAnswer = Console.ReadKey(true).KeyChar;
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
        private void MatchMenu()
        {
            Header();
            var matches = _manager.GetMatches(UserLoggedIn);
            Console.WriteLine("Your Matches:");
            foreach (var item in matches)
            {
                Console.WriteLine((item.Nickname ?? item.FirstName) + " - " + item.Id);

            }
            Console.WriteLine("Press 1 to select match\nPress any other key to return");
            char result = Console.ReadKey().KeyChar;
            switch (result)
            {
                case '1':
                    Console.WriteLine("Type ID of the match.");
                    int matchId;
                    if (int.TryParse(Console.ReadLine(), out matchId))
                    {
                        ChatMenu(matches.Find(i => i.Id == matchId));
                    }
                    break;
                default:
                    break;
            }
        }
        private void ChatMenu(Hivemember hivemember)
        {
            Header();
            Console.WriteLine($"You are in a chat with {hivemember.Nickname ?? hivemember.FirstName}\n");
            foreach (var item in _manager.GetMessages(UserLoggedIn, hivemember))
            {
                if (item.senderid == UserLoggedIn.Id)
                {
                    Console.WriteLine($"Meassage from you {item.timestamp}:\n{item.text}\n");
                }
                else
                {
                    Console.WriteLine($"Meassage from {hivemember.Nickname ?? hivemember.FirstName} {item.timestamp}:\n{item.text}\n");
                }
            }
            Console.WriteLine("9: Return\nPress any other button to start chatting");
            char result;
            result = Console.ReadKey().KeyChar;
            while (result != '9')
            {
                Console.WriteLine();
                var message = Console.ReadLine();
                _manager.SendMessage(UserLoggedIn, hivemember, message);
                ChatMenu(hivemember);
            }
        }
    }
}