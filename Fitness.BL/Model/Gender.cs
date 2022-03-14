using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name of Gender.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create new Gender.
        /// </summary>
        /// <param name="name"> Name of Gender. </param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
