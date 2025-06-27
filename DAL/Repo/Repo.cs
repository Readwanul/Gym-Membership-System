using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class Repo
    {
        internal GymContext db;
        internal Repo()
        {
            db = new GymContext();
        }
    }
}
