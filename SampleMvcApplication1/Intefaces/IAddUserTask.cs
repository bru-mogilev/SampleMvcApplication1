using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.Intefaces
{
    public interface IAddUserTask
    {
        int AddUser(UserModel user);
    }
}
