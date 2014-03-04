using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

using SampleMvcApplication1.DataModels;
using SampleMvcApplication1.Intefaces;

namespace SampleMvcApplication1.ApplicationServices.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private const string FilePath = "~/users.xml";

        private static readonly ConcurrentBag<UserDataModel> Users;

        private static readonly object FileLocker = new object();

        private static readonly string VirtualPath;

        static UsersRepository()
        {
            VirtualPath = HttpContext.Current.Server.MapPath(FilePath);

            if (File.Exists(VirtualPath) && new FileInfo(VirtualPath).Length > 0)
            {
                try
                {
                    var reader = new XmlSerializer(typeof(UserDataModel[]));
                    using (var file = new StreamReader(VirtualPath))
                    {
                        Users = new ConcurrentBag<UserDataModel>(reader.Deserialize(file) as UserDataModel[]);
                    }

                    return;
                }
                catch (InvalidOperationException)
                {
                    // Если мы попали сюда, то востановление данных не возможно.
                }
            }

            File.Create(VirtualPath).Close();
            Users = new ConcurrentBag<UserDataModel>();
        }

        public IEnumerable<UserDataModel> GetUsers()
        {
            return Users;
        }

        public UserDataModel GetUser(int userId)
        {
            var user = Users.First(u => u.UserId == userId);
            return user;
        }

        public int AddUser(UserDataModel user)
        {
            // Генерация id для нового пользователя.
            var userId = 0;
            if (Users.Count > 0)
            {
                // id будет на 1 больше чем у пользователя с максимальным id.
                var maxUserId = Users.Max(u => u.UserId);
                userId = maxUserId + 1;
            }

            user.UserId = userId;

            Users.Add(user);

            UpdateFile();

            return userId;
        }

        public void UpdateUser(UserDataModel user)
        {
            var oldUserData = Users.First(u => u.UserId == user.UserId);

            oldUserData.Description = user.Description;
            oldUserData.Email = user.Email;
            oldUserData.UserName = user.UserName;

            UpdateFile();
        }

        private static void UpdateFile()
        {
            lock (FileLocker)
            {
                var writer = new XmlSerializer(typeof(UserDataModel[]));

                using (var file = new StreamWriter(VirtualPath))
                {
                    writer.Serialize(file, Users.ToArray());
                }
            }
        }
    }
}
