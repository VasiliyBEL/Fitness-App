using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // Check

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

    }
}
