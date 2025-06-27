using System;
using DAL.Table;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface IAuth
    {
        Trainer Login(string username, string password);
    }
}
