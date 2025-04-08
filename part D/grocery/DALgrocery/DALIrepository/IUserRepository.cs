using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALrepository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        User GetByUsername(string username);
        List<User> GetAll();
        void Update(User user);
        void Delete(int id);
    }
}
