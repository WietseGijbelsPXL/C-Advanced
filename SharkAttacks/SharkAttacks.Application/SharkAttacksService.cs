using SharkAttacks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkAttacks.Application
{
    public class SharkAttacksService
    {
        SharkAttacksRepository _repo = new SharkAttacksRepository();

        public int GetTotalAttacks()
        {
            return _repo.GetTotalAttacks();
        }

        public int GetFatalAttacks()
        {
            return _repo.GetFatalAttacks();
        }

        public Dictionary<int, int> GetAttacksByYear()
        {
            return _repo.GetAttacksByYear();
        }

        public Dictionary<string, int> GetAttacksByActivity()
        {
            return _repo.GetAttacksByActivity();
        }
    }
}
