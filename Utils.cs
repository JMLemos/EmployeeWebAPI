using EmployeeWebApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace EmployeeWebApi
{
    public class Utils
    {
        public List<Employee> Deserialize()
        {
            using var reader = new StreamReader("./dataEmployee.json");
            var json = reader.ReadToEnd();
            var employee = JsonSerializer.Deserialize<List<Employee>>(json);

            reader.Dispose();

            return employee;

        }

        public void Serealize(List<Employee> employee)
        {
            var json = JsonSerializer.Serialize(employee);
            File.WriteAllText("./dataEmployee.json", json);
        }


        public List<Users> DeserializeUsers()
        {
            using var reader = new StreamReader("./dataUsers.json");
            var json = reader.ReadToEnd();
            var users = JsonSerializer.Deserialize<List<Users>>(json);
            reader.Dispose();

            return users;

           
                      

        }

        public void SerealizeUsers(List<Users> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText("./dataUsers.json", json);
        }
    }
}
