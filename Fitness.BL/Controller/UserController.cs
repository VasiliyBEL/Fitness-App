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
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Users of App.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Current User.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Flag for new User.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new Controller of User.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser is null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Get saved List of Users.
        /// </summary>
        /// <returns> User. </returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Check

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }

        /// <summary>
        /// Save User Data.
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
    }
}
