using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class PlanRepo : Repo, IRepo<Plan, int, Plan>
    {
        public Plan Add(Plan item)
        {
            db.Plans.Add(item);
            if (db.SaveChanges() > 0)
            {
                return item;
            }
            return null;
        }

        public Plan Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Plan> GetAll()
        {
            return db.Plans.ToList();
        }

        public Plan GetById(int id)
        {
            return db.Plans.Find(id);
        }

        public Plan Update(Plan item)
        {
            var existingPlan = db.Plans.Find(item.PlanId);
            if (existingPlan != null)
            {
                existingPlan.Title = item.Title;
                existingPlan.Description = item.Description;
                existingPlan.Price = item.Price;
                existingPlan.Trainer_Class = item.Trainer_Class;
                if (db.SaveChanges() > 0)
                {
                    return existingPlan;
                }
            }
            return null;
        }
    }
}
