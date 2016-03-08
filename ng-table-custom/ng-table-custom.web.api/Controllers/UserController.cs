namespace ng_table_custom.web.api.Controllers
{
    using AutoMapper;
    using data.Entities;
    using service.user;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using viewmodel;

    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("byid/{id:int}")]
        [ResponseType(typeof(UserVM))]
        public async Task<IHttpActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var userVM = Mapper.Map<User, UserVM>(user);
                return Ok(userVM);
            }
        }

        [HttpGet]
        [Route("all")]
        [ResponseType(typeof(List<UserVM>))]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users == null || users.Count <= 0)
            {
                return NotFound();
            }
            else
            {
                var userVMs = Mapper.Map<List<User>, List<UserVM>>(users);
                return Ok(userVMs);
            }
        }
    }
}
