using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Domain
{
    public class Training
    {
        public int DurationInHours { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string TrainerName { get; set; }

        protected Training()
        {
            
        }

        protected Training(int durationInHours, string id, string title, string trainerName)
        {
            DurationInHours = durationInHours;
            Id = id;
            Title = title;
            TrainerName = trainerName;
        }
    }
}
