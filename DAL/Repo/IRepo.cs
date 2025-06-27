using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface IRepo<Type, ID, Ret>
    {
        Ret Add(Type item);
        Ret Update(Type item);
        Ret Delete(ID id);
        Ret GetById(ID id);
        List<Type> GetAll();
    }
}
