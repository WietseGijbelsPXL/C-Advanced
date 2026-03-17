using Fruitshop.Domain;
using Fruitshop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fruitshop.Application
{
    public class FruitService
    {
        FruitRepository _fruitRepo;

        public FruitService(FruitRepository fruitRepository)
        {
            _fruitRepo = fruitRepository;
        }

        public IEnumerable<Fruit> GetAllFruits()
        {
            return _fruitRepo.LoadAllFruits();
        }

        public void Delete(int id)
        {

        }

        public void Add(Fruit fruit)
        {
            _fruitRepo.Add(fruit);
        }

        public void Update(Fruit fruit)
        {
            _fruitRepo.Update(fruit);
        }
    }
}
