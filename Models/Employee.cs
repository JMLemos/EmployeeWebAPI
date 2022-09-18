using EmployeeWebApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeWebApi.Models
{
    public class Employee
    {
        [Key]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("senha")]
        public string Senha { get; set; }

        [JsonPropertyName("cargo")]
        public string Cargo { get; set; }



        public Employee(int id, EmployeeDTO employeeDTO)
        {
            Id = id;
            Name = employeeDTO.Name;
            Email = employeeDTO.Email;
            Gender = employeeDTO.Gender;
            Login = employeeDTO.Login;
            Senha = employeeDTO.Senha;
            Cargo = employeeDTO.Cargo;

        }

        public Employee()
        {

        }
    }

    
}
