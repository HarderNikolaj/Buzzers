using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain;

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
        public static Bee MapHivememberToBee(hivemember hivemember, string image)
        {
            var converted = new Bee()
            {
                Id = hivemember.id,
                FirstName = hivemember.firstname,
                LastName = hivemember.lastname,
                Nickname = hivemember.nick,
                Email = hivemember.email,
                BirthDate = hivemember.birthdate,
                Gender = (Gender)hivemember.genderid,
                Preferences = MapEntityToDomainPreferences(hivemember.preference),
                Images = new List<string> { image }
            };
            return converted;
        }

        public static hivemember MapHoneypotToHivemember(Honeypot honeypot, string image)
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
                jobtitle = honeypot.JobTitle,

            };
            return converted;
        }
        public static Honeypot MapHivememberToHoneypot(hivemember hivemember, string image)
        {
            var converted = new Honeypot()
            {
                Id = hivemember.id,
                FirstName = hivemember.firstname,
                LastName = hivemember.lastname,
                Nickname = hivemember.nick,
                Email = hivemember.email,
                BirthDate = hivemember.birthdate,
                Gender = (Gender)hivemember.genderid,
                JobTitle = hivemember.jobtitle,
                Preferences = MapEntityToDomainPreferences(hivemember.preference),
                Images = new List<string> { image }

            };
            return converted;
        }

        public static Preferences MapEntityToDomainPreferences(preference p)
        {
            return new Preferences()
            {
                Id = p.id,
                AttracitonFemales = p.attractionfemale,
                AttractionMales = p.attractionmale
            };
        }
        public static List<ChatMessage> MapEnitityMessageToChatMessage(List<message> messages, Hivemember user, Hivemember chatPartner)
        {
            List<ChatMessage> chatMessages = new List<ChatMessage>();
            foreach (var item in messages)
            {
                if (item.senderid == user.Id)
                {
                    chatMessages.Add(new ChatMessage()
                    {
                        Sender = user,
                        Reciever = chatPartner,
                        Message = item.text,
                        Timestamp = item.timestamp
                    });
                }
                else
                {
                    chatMessages.Add(new ChatMessage()
                    {
                        Sender = chatPartner,
                        Reciever = user,
                        Message = item.text,
                        Timestamp = item.timestamp
                    });
                }
            }
            return chatMessages;
        }
    }
}
