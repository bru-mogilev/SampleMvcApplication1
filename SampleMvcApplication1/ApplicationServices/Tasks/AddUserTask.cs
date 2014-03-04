using SampleMvcApplication1.ApplicationServices.Mapping;
using SampleMvcApplication1.ApplicationServices.Repositories;
using SampleMvcApplication1.DataModels;
using SampleMvcApplication1.Intefaces;
using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.ApplicationServices.Tasks
{
    public class AddUserTask : IAddUserTask
    {
        private readonly IUsersRepository _usersRepository;

        private readonly IMapper<UserModel, UserDataModel> _userDataModelMapper;

        public AddUserTask()
        {
            _usersRepository = new UsersRepository();
            _userDataModelMapper = new UserDataModelMapper();
        }

        public int AddUser(UserModel user)
        {
            var userData = _userDataModelMapper.Map(user);
            var userId = _usersRepository.AddUser(userData);

            return userId;
        }
    }
}
