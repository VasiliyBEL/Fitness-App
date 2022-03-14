using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Controller of User.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of App.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Create new Controller of User.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: Проверка ЮЗЕРНЕЙМА!
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Load User Data.
        /// </summary>
        /// <returns> User. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                // TODO: Что делать если не прочитали ЮЗЕРА?
            }
        }

        /// <summary>
        /// Save User Data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
