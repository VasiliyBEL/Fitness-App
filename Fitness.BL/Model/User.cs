using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Properties of User.
        /// <summary>
        /// Name of User.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gender of User.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Birthday of User. 
        /// </summary>
        public DateTime BirthDate { get; set;  }

        /// <summary>
        /// Weight of User.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height of User.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Age.
        /// DateTime nouDate = DateTime.Today;
        /// int age = nowDate.Year - birthDate.Year;
        /// if (birthDate > nowDate.AddYears(-age)) age--;
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion

        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="name"> Name of User. </param>
        /// <param name="gender"> Gender of User. </param>
        /// <param name="birthDate"> Birthday of User. </param>
        /// <param name="weight"> Weight of User. </param>
        /// <param name="height"> Height of User. </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Checking for mistakes.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }


            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше либо равен 0.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен 0.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
