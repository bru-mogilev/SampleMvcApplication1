using System.Collections.Generic;

using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.Intefaces
{
    public interface IUsersQuery
    {
        IEnumerable<UserModel> GetUsers();

        UserModel GetUser(int userId);
    }
}
