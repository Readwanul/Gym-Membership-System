using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AttendenceRepo : Repo, IRepo<Attendence, int, Attendence>
    {
        public Attendence Add(Attendence item)
        {
            db.Attendences.Add(item);
            if (db.SaveChanges() > 0)
            {
                return item;
            }
            return null;
        }

        public Attendence Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Attendence> GetAll()
        {
            return db.Attendences.ToList();
        }

        public Attendence GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Attendence Update(Attendence item)
        {
            throw new NotImplementedException();
        }
    }
}
