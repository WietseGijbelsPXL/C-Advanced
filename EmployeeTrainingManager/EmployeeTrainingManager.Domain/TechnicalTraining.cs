using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Domain
{
    public class TechnicalTraining: Training
    {
        public string Technology { get; set; }

        public string ShowInfo()
        {
            throw new NotImplementedException();
        }

        public TechnicalTraining()
        {
            
        }

        public TechnicalTraining(int durationInHours, string id, string title, string trainerName, string technology) : base(durationInHours, id, title, trainerName)
        {
            Technology = technology;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
