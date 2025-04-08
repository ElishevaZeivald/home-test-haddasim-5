using DALgrocery.DALmodels;
using DALgrocery.DALrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmanager
{
    public class UserManager
    {
       
            private readonly UserRepository _userRepository;

            public UserManager(UserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public User CreateUser(string username, string password, string role)
            {
                var user = new User
                {
                    UserName = username,
                    Password = password,
                    Role = role
                };

                _userRepository.Add(user);
                return user;
            }

            public User GetUserById(int id)
            {
                return _userRepository.GetById(id);
            }

            public List<User> GetAllUsers()
            {
                return _userRepository.GetAll();
            }

            public bool ValidateUser(string username, string password)
            {
                var user = _userRepository.GetByUsername(username);
                if (user != null && user.Password == password)
                {
                    return true;
                }
                return false;
            }

        }
    }

