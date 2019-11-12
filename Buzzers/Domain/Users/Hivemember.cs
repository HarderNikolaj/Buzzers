using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public abstract class Hivemember : IEditableObject
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public Gender Gender { get; set; }
        public Preferences Preferences { get; set; }
        public List<string> Images { get; set; }

        private Hivemember _backup;

        public Hivemember() 
        {
            Preferences = new Preferences();
        }

        public void BeginEdit()
        {
            _backup = MemberwiseClone() as Hivemember;
        }


        //TODO: fix this shit
        public void CancelEdit()
        {
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                prop.SetValue(prop.Name, _backup.GetType().GetProperty(prop.Name));
            }
            _backup = null;
        }

        public void EndEdit()
        {
            _backup = null;
        }
        public int GetAge() 
        {
            var Age = DateTime.Today.Year - BirthDate.Year;
            return Age;
        }
    }
}
