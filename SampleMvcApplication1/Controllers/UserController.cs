using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly IEnumerable<UserModel> _users;

        public UserController()
        {
            _users = new[]
            {
                new UserModel { UserId = 4,  UserName = "Arden",       Email = "Curae@nec.edu" },
                new UserModel { UserId = 5,  UserName = "Tanner",      Email = "vulputate.ullamcorper@volutpatnunc.co.uk" },
                new UserModel { UserId = 6,  UserName = "Stone",       Email = "ac.orci@ornareelitelit.org" },
                new UserModel { UserId = 7,  UserName = "Buckminster", Email = "Sed@condimentumDonec.co.uk" },
                new UserModel { UserId = 8,  UserName = "Basil",       Email = "non.lorem.vitae@pellentesque.net" },
                new UserModel { UserId = 9,  UserName = "Palmer",      Email = "inceptos.hymenaeos.Mauris@dictumeuplacerat.co.uk" },
                new UserModel { UserId = 10, UserName = "Jonah",       Email = "Cum@ligulaAliquamerat.edu" },
                new UserModel { UserId = 11, UserName = "Ronan",       Email = "sem.elit@accumsan.ca" },
                new UserModel { UserId = 12, UserName = "Matthew",     Email = "Maecenas.ornare@convallisestvitae.org" },
                new UserModel { UserId = 13, UserName = "Keegan",      Email = "et@faucibusutnulla.edu" }
            };
        }

        public ActionResult Index()
        {
            return View(_users);
        }

        public ActionResult Info(int id)
        {
            var user = _users.FirstOrDefault(usr => usr.UserId == id);

            return View(user);
        }
    }
}
