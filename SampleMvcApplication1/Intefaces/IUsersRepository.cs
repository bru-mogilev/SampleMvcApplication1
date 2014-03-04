using System.Collections.Generic;

using SampleMvcApplication1.DataModels;

namespace SampleMvcApplication1.Intefaces
{
    public interface IUsersRepository
    {
        IEnumerable<UserDataModel> GetUsers();

        UserDataModel GetUser(int userId);

        int AddUser(UserDataModel user);

        void UpdateUser(UserDataModel user);
    }
}
