using System.Collections.Generic;
using System.Linq;

using SampleMvcApplication1.ApplicationServices.Mapping;
using SampleMvcApplication1.ApplicationServices.Repositories;
using SampleMvcApplication1.DataModels;
using SampleMvcApplication1.Intefaces;
using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.ApplicationServices.Queries
{
    public class UsersQuery : IUsersQuery
    {
        private readonly UsersRepository _usersRepository;

        private readonly IMapper<UserDataModel, UserModel> _userModelMapper;

        public UsersQuery()
        {
            _usersRepository = new UsersRepository();
            _userModelMapper = new UserModelMapper();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _usersRepository.GetUsers();
            var mappedUsers = users.Select(_userModelMapper.Map);

            return mappedUsers;
        }

        public UserModel GetUser(int userId)
        {
            var user = _usersRepository.GetUser(userId);
            var mappedUser = _userModelMapper.Map(user);

            return mappedUser;
        }
    }
}
