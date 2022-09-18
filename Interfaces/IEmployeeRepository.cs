using EmployeeWebApi.DTO;
using EmployeeWebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.Interfaces
{
    public interface IEmployeeRepository
    {

        public Task<IQueryable<Employee>> Get(int page, int maxResults);

        public Task<Employee?> getById(int id);

        public Task<Employee?> Insert(EmployeeDTO employeeDTO);

        public Task<Employee?> Update(int id, EmployeeDTO employeeDTO);

        public Task<Employee> UpdatePatch(int id, LoginDTO loginDTO);

        public Task<Employee> Delete(int id);
    }
}