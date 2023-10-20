using Microsoft.AspNetCore.Mvc;
using new_project.Data;
using new_project.Models;

namespace new_projectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly new_projectContext _context;
        public UserController (new_projectContext context){
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public List<UserDatum> GetUserData(){
            var response = _context.UserData.ToList();
            return response;
        }

        [HttpPost]
        [Route("Post")]
        public string PostUserData(UserDatum data){

            _context.UserData.Add(data);
            int state = _context.SaveChanges();
            return state > 0 ? "Success" : "Failed";
        }
    }
}