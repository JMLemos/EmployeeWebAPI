using System.Threading.Tasks;

namespace EmployeeWebApi.Interfaces
{
    public interface ITokenService
    {

        public Task<string> ConstruirToken();


    }
}