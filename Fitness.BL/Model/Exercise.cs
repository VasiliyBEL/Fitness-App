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
        public DateTime Start { get; }

        public DateTime Finish { get; }

        public Activity Activity { get; }

        public User User { get; }

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
