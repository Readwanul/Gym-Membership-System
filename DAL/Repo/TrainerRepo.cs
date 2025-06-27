using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TrainerRepo : Repo, IRepo<Trainer, int, Trainer>, IAuth
    {
        public Trainer Add(Trainer item)
        {
            db.Trainers.Add(item);
            if (db.SaveChanges() > 0)
            {
                return item;
            }
            return null;
        }

        public Trainer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }

        public Trainer GetById(int id)
        {
            return db.Trainers.Find(id);
        }

        public Trainer Update(Trainer item)
        {
            throw new NotImplementedException();
        }
        public Trainer Login(string username, string password)
        {
            var Trainer = (from u in  db.Trainers
                           where u.Email == username && u.Password == password
                           select u).FirstOrDefault();
            if (Trainer != null)
            {
                return Trainer;
            }
            return null;


        }
    }
}
