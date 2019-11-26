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
        private string _nickname;
        public int Id { get; set; }
        public string Nickname
        {
            get
            {
                if (_nickname is null)
                {
                    return FirstName + " " + LastName;
                }
                return _nickname;
            }
            set
            {
                if (value != null)
                {
                    _nickname = value;
                }
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public Gender Gender { get; set; }
        public Preferences Preferences { get; set; }
        public List<string> Images { get; set; }

        private Hivemember _backup;
        public int Age { get; set; }

        public Hivemember()
        {
            Age = GetAge();
            Preferences = new Preferences();
        }

        public void BeginEdit()
        {
            _backup = MemberwiseClone() as Hivemember;
        }

        public void CancelEdit()
        {
            Nickname = _backup.Nickname;
            FirstName = _backup.FirstName;
            LastName = _backup.LastName;
            BirthDate = _backup.BirthDate;
            Bio = _backup.Bio;
            Images = _backup.Images;
            Preferences = _backup.Preferences;

            _backup = MemberwiseClone() as Hivemember;
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
