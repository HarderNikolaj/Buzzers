using Domain.Enums;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IAccountManager
    {
        bool CreateUser(Hivemember hivemember, string password);
        bool DeleteUser(int id);
        void Edit(Hivemember hivemember);
        Hivemember Login(string email, string password);
        Bee GetBee(int id);
        Honeypot GetHoneypot(int id);
        void Buzz(Hivemember Buzzer, Hivemember Buzzee, Boolean Buzz);
        List<Hivemember> GetMatches(Hivemember user);
        List<message> GetMessages(Hivemember user, Hivemember chatPartner);
        void SendMessage(Hivemember sender, Hivemember reciever, string message);
        MemberStory GetMemberStory();
        List<ChatMessage> GetChatMessages(Hivemember user, Hivemember chatPartner);

    }
}
