using SampleMvcApplication1.DataModels;
using SampleMvcApplication1.Intefaces;
using SampleMvcApplication1.Models;

namespace SampleMvcApplication1.ApplicationServices.Mapping
{
    public class UserModelMapper : IMapper<UserDataModel, UserModel>
    {
        public UserModel Map(UserDataModel dataModel)
        {
            var model = new UserModel
                            {
                                Email = dataModel.Email,
                                UserId = dataModel.UserId,
                                UserName = dataModel.UserName,
                                Description = dataModel.Description
                            };

            return model;
        }
    }
}
