using EmployeeWebApi.Models;
using System.Collections.Generic;

using EmployeeWebApi.DTO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Utils _utils;
        private readonly List<Users> _databaseUsers;

        public UserRepository()
        {
            _utils = new Utils();
            _databaseUsers = _utils.DeserializeUsers();


        }

        private void saveDataBase()
        {
            _utils.SerealizeUsers(_databaseUsers);
        }

        
        public Task<IQueryable<Users>> Get(int page, int maxResults)
        {
            return Task.Run(() =>
            {
                var data = _databaseUsers.AsQueryable().Skip((page - 1) * maxResults).Take(maxResults);
                return data.Any() ? data : new List<Users>().AsQueryable();

            });
        }

        public Task<Users> GetLogin(UserDTO userDTO)
        {
            return Task.Run(() =>
            {
                var user = _databaseUsers.FirstOrDefault(item => item.Username.Equals(userDTO.Username) && item.Password.Equals(userDTO.Password));
                return user;
            });
        }


        public Task<Users> Insert(Users user)
        {
            return Task.Run(() =>
            {
                _databaseUsers.Add(user);

                saveDataBase();

                return user;
            });
        }



    }


}

