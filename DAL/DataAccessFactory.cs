using DAL.Repo;
using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Trainer, int, Trainer> TrainerData()
        {
            return new Repo.TrainerRepo();
        }
        public static IRepo<Plan, int, Plan> PlanData()
        {
            return new Repo.PlanRepo();
        }
        public static IRepo<Member, int, Member> MemberData()
        {
            return new Repo.MemberRepo();
        }
        public static IRepo<Attendence, int, Attendence> AttendanceData()
        {
            return new Repo.AttendenceRepo();
        }
        public static IAuth AuthData()
        {
            return new Repo.TrainerRepo();
        }

    }
}
