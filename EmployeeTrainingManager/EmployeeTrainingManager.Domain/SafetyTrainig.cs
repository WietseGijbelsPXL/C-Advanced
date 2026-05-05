using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrainingManager.Domain
{
    public class SafetyTrainig:Training
    {
        public string RiskLevel { get; set; }

        public SafetyTrainig()
        {
            
        }

        public SafetyTrainig(int durationInHours, string id, string title, string trainerName, string risklevel) : base(durationInHours, id, title, trainerName)
        {
            RiskLevel = risklevel;
        }

        public string ShowInfo()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
