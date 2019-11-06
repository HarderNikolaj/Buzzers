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
        public void CreateBee(Bee member)
        {
            using (var context = new buzzerbaseEntities())
            {
                context.hivemembers.Add(HivememberEntityMapper.MapBeeToHivemember(member));
                context.SaveChanges();
            }
        }

        public void CreateHoneypot(Honeypot hivemember)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
