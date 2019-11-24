using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DbCommunicator
{
    public interface IDbCommunicator
    {
        void CreateMember(Bee hivemember, string password);
        void CreateMember(Honeypot hivemember, string password);
        void Edit(Hivemember hivemember);
        bool Delete(int id);
        Hivemember Login(string email, string pass);
        Honeypot FindHoneypot(int id);
        Bee FindBee(int id);
        void CreateBuzz(Hivemember buzzer, Hivemember buzze, Boolean buzz);
        List<getmatches_Result> GetMatches(Hivemember user);
        List<message> GetMessages(Hivemember user, Hivemember chatPartner);
        void SendMessage(Hivemember sender, Hivemember reciever, string message);
        randommemberstory GetMemberstory();
        List<String> GetImages(int UserId);
    }
}
