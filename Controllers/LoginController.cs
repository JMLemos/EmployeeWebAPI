using EmployeeWebApi.DTO;
using EmployeeWebApi.Interfaces;
using EmployeeWebApi.Login;
using EmployeeWebApi.Models;
using EmployeeWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase 
    {
        private readonly Utils _utils;
        private readonly List<Users> _databaseUsers;
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;


        public LoginController(IUserRepository repository , ITokenService tokenService)
        {
            _utils = new Utils();
            _databaseUsers = new List<Users>();
            _repository = repository;
            _tokenService = tokenService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Users), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<dynamic>> Login([FromBody] UserDTO user)
        {

            var consult = await  _repository.GetLogin(user);

            if (consult == null)
                return Unauthorized( "User or Password invalid !");

            var token = await _tokenService.ConstruirToken();

            consult.Password = "";

            var result = new
            {
                user = consult, 
                token = token
            };

            return Ok(result);
        }


    }
}
