using EmployeeWebApi.DTO;
using EmployeeWebApi.Interfaces;
using EmployeeWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.Repositories
{
    public class EmployeeRepository 
    {
        private readonly Utils _utils;
        private readonly List<Employee> _database;

        public EmployeeRepository()
        {
            _utils = new Utils();
            _database = _utils.Deserialize();
        }

        private void saveDataBase()
        {
            _utils.Serealize(_database);     
        }

        public Task<IQueryable<Employee>> Get(int page, int maxResults)
        {
            return Task.Run(() =>
            {
                var data = _database.AsQueryable().Skip((page - 1) * maxResults).Take(maxResults);
                return data.Any() ? data : new List<Employee>().AsQueryable();
            });
        }

        public Task<Employee?> getById(int id)
        {
            return Task.Run(() =>
            {
                var consult = _database.FirstOrDefault(x => x.Id == id);

                return consult;
            });
        }

        public Task<Employee?> Insert(EmployeeDTO employeeDTO)
        {

            return Task.Run(() =>
            {

                var result =CreateEmployee(employeeDTO);
                
                _database.Add(result);

                this.saveDataBase();

                return result;
            });

        }

        public Task<Employee?> Update(int id, EmployeeDTO employeeDTO)
        {
            return Task.Run(() =>
            {
                var consult = _database.FirstOrDefault(x => x.Id == id);
               
                UpdateEmployee(consult, employeeDTO);
                
                this.saveDataBase();

                return consult;
            });
        }

        public Task<Employee> UpdatePatch(int id, LoginDTO loginDTO)
        {
            return Task.Run(() =>
            {
                var consult = _database.FirstOrDefault(x => x.Id == id);

                UpdatePatch(consult, loginDTO);

                this.saveDataBase();

                return consult;
            });
        }

        public Task<Employee> Delete(int id)
        {
            return Task.Run(() =>
            {
                var consult = _database.FirstOrDefault(x => x.Id == id);

                _database.Remove(consult);

                this.saveDataBase();

                return consult;
            });
        }



        public void UpdatePatch(Employee employee, LoginDTO loginDTO)
        {
            employee.Login = loginDTO.Login;
            employee.Senha = loginDTO.Senha;

        }

        public void UpdateEmployee(Employee employee, EmployeeDTO employeeDTO)
        {
            employee.Name = employeeDTO.Name;
            employee.Email = employeeDTO.Email;
            employee.Gender = employeeDTO.Gender;
            employee.Login = employeeDTO.Login;
            employee.Senha = employeeDTO.Senha;
            employee.Cargo = employeeDTO.Cargo;

        }


        public Employee CreateEmployee(EmployeeDTO employeeDTO)
        {
            var id = _database.Count() + 1;

            var employee = new Employee(id, employeeDTO);
                        
            return employee;
        }
    }
}
