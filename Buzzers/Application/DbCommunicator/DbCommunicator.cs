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
        public void CreateMember(Bee member, string password)
        {
            using (var context = new Entities())
            {
                context.CreateUserWithLogin(1, (int)member.Gender, member.FirstName, member.LastName, member.Email, member.BirthDate, null, password);
            }
        }

        public void CreateMember(Honeypot member, string password)
        {
            using (var context = new Entities())
            {
                context.CreateUserWithLogin(2, (int)member.Gender, member.FirstName, member.LastName, member.Email, member.BirthDate, member.JobTitle, password);
            }
        }

        public void Edit(Hivemember hivemember)
        {
            using (var context = new Entities())
            {
                var toChange = context.hivemembers.SingleOrDefault(a => a.id == hivemember.Id);
                if (toChange != null)
                {
                    toChange.bio = hivemember.Bio;
                    toChange.nick = hivemember.Nickname;
                    toChange.preference.attractionfemale = hivemember.Preferences.AttracitonFemales;
                    toChange.preference.attractionmale = hivemember.Preferences.AttractionMales;

                    context.SaveChanges();
                }
            }
        }

        public bool Delete(int id)
        {
            using (var context = new Entities())
            {
                var toDelete = context.hivemembers.SingleOrDefault(a => a.id == id);

                if (toDelete == null)
                    return false;

                context.hivemembers.Remove(toDelete);
                context.SaveChanges();

                return true;
            }
        }

        //TODO hent brugerpreference mm. fra database og brug denne data til at kalde stored procedure
        public Bee FindBee(int id)
        {
            using (var context = new Entities())
            {
                var result = context.GetPotentialMatch(id).FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                if (result.weight == null)
                {
                    result.weight = 0;
                }
                var bee = new Bee()
                {
                    Id = result.id,
                    FirstName = result.firstname,
                    LastName = result.lastname,
                    Nickname = result.nick,
                    BirthDate = result.birthdate,
                    Weight = (int)result.weight
                };
                return bee;
            }
        }

        //TODO hent brugerpreference mm. fra database og brug denne data til at kalde stored procedure
        public Honeypot FindHoneypot(int id)
        {
            using (var context = new Entities())
            {
                var result = context.GetPotentialMatch(id).FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                var honeypot = new Honeypot()
                {
                    Id = result.id,
                    FirstName = result.firstname,
                    LastName = result.lastname,
                    Nickname = result.nick,
                    BirthDate = result.birthdate,
                    JobTitle = result.jobtitle
                };
                return honeypot;
            }
        }

        public Hivemember Login(string email, string password)
        {
            using (var context = new Entities())
            {
                var queer = context.hivemembers
                    .Where(a => a.email == email)
                    .FirstOrDefault();

                if (queer == null) return null;

                var query = context.userlogins
                    .Where(e => e.userid == queer.id && e.pass == password)
                    .FirstOrDefault();
                if (query == null)
                {
                    return null;
                }
                if (query.hivemember.usertypeid == 1)
                {
                    return HivememberEntityMapper.MapHivememberToBee(query.hivemember);
                }
                else if (query.hivemember.usertypeid == 2)
                {
                    return HivememberEntityMapper.MapHivememberToHoneypot(query.hivemember);
                }
                else
                {
                    return null;
                }
            }
        }

        public void CreateBuzz(Hivemember buzzer, Hivemember buzzee, Boolean buzz)
        {
            using (var context = new Entities())
            {
                context.buzzs.Add(new buzz()
                {
                    buzzerid = buzzer.Id,
                    buzzeeid = buzzee.Id,
                    isbuzzon = buzz,
                    timestamp = DateTime.Now
                });
                context.SaveChanges();
            }
        }

        public List<getmatches_Result> GetMatches(Hivemember user)
        {
            using (var context = new Entities())
            {
                return context.getmatches(user.Id).ToList();
            }
        }

        public List<message> GetMessages(Hivemember user, Hivemember chatPartner)
        {
            using (var context = new Entities())
            {
                return context.messages
                     .Where(m => m.recieverid == user.Id && m.senderid == chatPartner.Id || m.recieverid == chatPartner.Id && m.senderid == user.Id)
                     .OrderBy(m => m.timestamp)
                     .ToList();
            }
        }

        public void SendMessage(Hivemember sender, Hivemember reciever, string message)
        {
            using (var context = new Entities())
            {
                context.messages.Add(
                    new message()
                    {
                        senderid = sender.Id,
                        recieverid = reciever.Id,
                        text = message,
                        isread = false,
                        timestamp = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
        public memberstory GetMemberstory() 
        {
            using (var context = new Entities())
            {
                throw new NotImplementedException();
                //return context.randommemberstory();

            }
        }
    }
}
