using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
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
        public static Bee MapHivememberToBee(hivemember hivemember) 
        {
            var converted = new Bee()
            {
                FirstName = hivemember.firstname,
                LastName = hivemember.lastname,
                Nickname = hivemember.nick,
                Email = hivemember.email,
                BirthDate = hivemember.birthdate,
                Gender = (Gender)hivemember.genderid
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
        public static Honeypot MapHivememberToHoneypot(hivemember hivemember)
        {
            var converted = new Honeypot()
            {
                FirstName = hivemember.firstname,
                LastName = hivemember.lastname,
                Nickname = hivemember.nick,
                Email = hivemember.email,
                BirthDate = hivemember.birthdate,
                Gender = (Gender)hivemember.genderid,
                JobTitle = hivemember.jobtitle
            };
            return converted;
        }
    }
}
