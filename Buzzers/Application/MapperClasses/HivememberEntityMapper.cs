using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MapperClasses
{
    public static class HivememberEntityMapper
    {
        public static hivemember MapBeeToHivemember(Bee bee)
        {
            var converted = new hivemember()
            {
                firstname = bee.FirstName,
                lastname = bee.LastName,
                nick = bee.Nickname,
                email = bee.Email,
                birthdate = bee.BirthDate,
                genderid = (int)bee.Gender,
                usertypeid = 1
            };
            return converted;
        }

        public static hivemember MapHoneypotToHivemember(Honeypot honeypot)
        {
            var converted = new hivemember()
            {
                firstname = honeypot.FirstName,
                lastname = honeypot.LastName,
                nick = honeypot.Nickname,
                email = honeypot.Email,
                birthdate = honeypot.BirthDate,
                genderid = (int)honeypot.Gender,
                usertypeid = 2,
                jobtitle = honeypot.JobTitle
            };
            return converted;
        }
    }
}
