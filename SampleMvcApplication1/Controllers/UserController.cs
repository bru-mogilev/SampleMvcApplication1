using System.Web.Mvc;
using SampleMvcApplication1.ApplicationServices.Queries;
using SampleMvcApplication1.ApplicationServices.Tasks;
using SampleMvcApplication1.Intefaces;
using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersQuery _usersQuery;

        private readonly IAddUserTask _addUserTask;

        private readonly IUpdateUserTask _updateUserTask;

        public UserController()
        {
            _usersQuery = new UsersQuery();
            _addUserTask = new AddUserTask();
            _updateUserTask = new UpdateUserTask();
        }

        public ActionResult Index()
        {
            var users = _usersQuery.GetUsers();
            return View(users);
        }

        public ActionResult Info(int id)
        {
            var user = _usersQuery.GetUser(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var user = _usersQuery.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(UserModel model)
        {
            _updateUserTask.UpdateUser(model);
            return RedirectToAction("Info", new { id = model.UserId });
        }

        [HttpGet]
        public ActionResult Add()
        {
            var empty = new UserModel();
            return View(empty);
        }

        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            var newUserId = _addUserTask.AddUser(model);
            return RedirectToAction("Info", new { id = newUserId });
        }
    }
}
