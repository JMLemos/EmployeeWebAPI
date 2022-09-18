using EmployeeWebApi.DTO;
using EmployeeWebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.Interfaces
{
    public interface IUserRepository
    {

        //public Task <Users> Get(string username, string password);

        public Task<IQueryable<Users>> Get(int page, int maxResults);

        public Task<Users> GetLogin(UserDTO userDTO);

        public Task<Users> Insert(Users user);
    }
}