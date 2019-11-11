using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;


namespace BuzzerConsole
{
    class Session
    {
        public Hivemember UserLoggedIn { get; set; }

        private void Header() 
        {
            if (UserLoggedIn == null)
                Console.WriteLine("Buzzers - Login");
            else
                Console.Write($"Buzzers - {UserLoggedIn.Nickname ?? UserLoggedIn.FirstName}\n\n");
        }
        
        public void LoginScreen() 
        {
            Header();
            Console.Write("Email:´");
            var login = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            
        }
    }
}

