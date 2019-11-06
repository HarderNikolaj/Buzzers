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
    }
}
