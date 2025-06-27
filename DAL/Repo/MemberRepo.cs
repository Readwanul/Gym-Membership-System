using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class MemberRepo:Repo,IRepo<Member, int, Member>
    {
        public Member Add(Member item)
        {
            db.Members.Add(item);
            if (db.SaveChanges() > 0)
            {
                return item;
            }
            return null;
        }
        public Member Delete(int id)
        {
            var mm= GetById(id);
            db.Members.Remove(mm);
            db.SaveChanges();
            return mm;
        }
        public List<Member> GetAll()
        {
            return db.Members.ToList();
        }
        public Member GetById(int id)
        {
            return db.Members.Find(id);
        }
        public Member Update(Member item)
        {
            var existingMember = db.Members.Find(item.Id);
            if (existingMember != null)
            {
                existingMember.Name = item.Name;
                existingMember.Age = item.Age;
                existingMember.Email = item.Email;
                existingMember.PlanId = item.PlanId;
                existingMember.TrainerId = item.TrainerId;
                existingMember.Membership_status = item.Membership_status;
                existingMember.JoinedAt = item.JoinedAt;
                if (db.SaveChanges() > 0)
                {
                    return existingMember;
                }
            }
            return null;
        }
    }

}
