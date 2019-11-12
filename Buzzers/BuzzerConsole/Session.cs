using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using Application;
using Application.DbCommunicator;
using Domain.Enums;
using Application.MapperClasses;

namespace BuzzerConsole
{
    class Session
    {
        public Hivemember UserLoggedIn { get; set; }
        public IAccountManager Manager { get; set; }

        public Session(IAccountManager accountManager)
        {
            Manager = accountManager;
        }

        private void Header()
        {
            Console.Clear();
            if (UserLoggedIn == null)
                Console.WriteLine("Buzzers - Login");
            else
                Console.Write($"Buzzers - {UserLoggedIn.Nickname ?? UserLoggedIn.FirstName}\n\n");
        }

        public void Login()
        {
            Header();
            Console.Write("Email: ");
            var login = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            var userId = Manager.Login(login, password);
            using (var contexts = new Entities())
            {
                if (userId != 0)
                {
                    var User = contexts.hivemembers
                    .Where(i => i.id == userId)
                    .FirstOrDefault();
                    if (User.usertypeid == 1)
                    {
                        UserLoggedIn = HivememberEntityMapper.MapHivememberToBee(User);
                    }

                    else if (User.usertypeid == 2)
                    {
                        UserLoggedIn = HivememberEntityMapper.MapHivememberToHoneypot(User);
                    }

                }
            }
        }
        public void CreateUser()
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
                    Manager.CreateUser(newMember, password);
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
                    Manager.CreateUser(newMember, password);
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
        public void MainScreen()
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
                        if (UserLoggedIn.GetType().ToString() == "Honeypot")
                        {
                            PotentialMatch = Manager.GetBee(UserLoggedIn.Id);
                        }
                        else if (UserLoggedIn.GetType().ToString() == "Bee")
                        {
                            PotentialMatch = Manager.GetHoneypot(UserLoggedIn.Id);
                        }
                        DisplayBee(PotentialMatch);
                        //TODO Include Buzz selection
                        break;
                    case '2':
                        PreferenceMenu();
                        break;
                    case '3':
                        break;
                    case '9':
                        Manager.Logout();
                        break;
                    default:
                        break;

                }
            }
        }
        void DisplayBee(Hivemember User)
        {
            Header();
            Console.WriteLine($"Name: {User.Nickname ?? User.FirstName + ' ' + User.LastName}\nGender: {User.Gender}\nAge: {User.GetAge()}");
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
        void PreferenceMenu()
        {
            char preferenceAnswer;
            do
            {
                Header();
                Console.WriteLine($"Interested in:\n(1) Males: {UserLoggedIn.Preferences.AttractionMales.ToString() ?? "Not set"}\n(2) Females: {UserLoggedIn.Preferences.AttracitonFemales.ToString() ?? "Not set"}\n(9) Return");
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
                        //TODO submit changes
                        break;
                    case '8':
                        //TODO undo changes
                        break;
                    default:
                        break;
                }

            } while (preferenceAnswer != '9' || preferenceAnswer != '8');
        }
    }

}