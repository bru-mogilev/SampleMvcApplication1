using SampleMvcApplication1.DataModels;
using SampleMvcApplication1.Intefaces;
using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.ApplicationServices.Mapping
{
    public class UserDataModelMapper : IMapper<UserModel, UserDataModel>
    {
        public UserDataModel Map(UserModel model)
        {
            var dataModel = new UserDataModel
                            {
                                Email = model.Email,
                                UserId = model.UserId,
                                UserName = model.UserName,
                                Description = model.Description
                            };

            return dataModel;
        }
    }
}
