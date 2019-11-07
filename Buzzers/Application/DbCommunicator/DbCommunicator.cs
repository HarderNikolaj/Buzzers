using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MapperClasses;
using Domain.Users;

namespace Application.DbCommunicator
{
    public class DbCommunicator : IDbCommunicator
    {
        public void CreateHivemember(Bee member)
        {
            using (var context = new Entities())
            {
                context.hivemembers.Add(HivememberEntityMapper.MapBeeToHivemember(member));
                context.SaveChanges();
            }
        }

        public void CreateHoneypot(Honeypot member)
        {
            using (var context = new Entities())
            {
                context.hivemembers.Add(HivememberEntityMapper.MapHoneypotToHivemember(member));
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new Entities())
            {
                
            }
        }
    }
}
