using SampleMvcApplication1.ApplicationServices.Mapping;
using SampleMvcApplication1.ApplicationServices.Repositories;
using SampleMvcApplication1.DataModels;
using SampleMvcApplication1.Intefaces;
using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.ApplicationServices.Tasks
{
    public class UpdateUserTask : IUpdateUserTask
    {
        private readonly IUsersRepository _usersRepository;

        private readonly IMapper<UserModel, UserDataModel> _userDataModelMapper;

        public UpdateUserTask()
        {
            _usersRepository = new UsersRepository();
            _userDataModelMapper = new UserDataModelMapper();
        }

        public void UpdateUser(UserModel user)
        {
            var userData = _userDataModelMapper.Map(user);
            _usersRepository.UpdateUser(userData);
        }
    }
}
