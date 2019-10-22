using Explore.Api.Token;
using System.Web.Http;

namespace Explore.Api.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public ResponseVM UserLogin(string Name, string Password)
        {
            var objlst = new { Status = 1 }; // Do your Db operations and get Data of user
            if (objlst.Status == -1) return new ResponseVM
            {
                Status = "Invalid",
                Message = "Invalid User."
            };
            if (objlst.Status == 0) return new ResponseVM
            {
                Status = "Inactive",
                Message = "User Inactive."
            };
            else return new ResponseVM
            {
                Status = "Success",
                Message = TokenManager.GenerateToken(1, "SaiKumar")
            };
        }

        [TokenAuthorization]
        [HttpGet]
        public string GetData()
        {
            return "Valid";
        }
    }
}
