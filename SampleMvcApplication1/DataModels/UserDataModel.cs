using System;

namespace SampleMvcApplication1.DataModels
{
    [Serializable]
    public class UserDataModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
    }
}
