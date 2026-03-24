using HttpClientDemo.Domain.Models;
using HttpClientDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo.Application
{
    public class DogService
    {
        private DogRepository _dogRepository = new DogRepository();
        public List<Dog> Dogs { get; private set; }
        public Dog CurrentDog { get; private set; }

        public async Task InnitializeAsync()
        {
            Dogs = await _dogRepository.GetData();
            Dogs = Dogs.OrderBy(d => d.ToString()).ToList();
        }

        public async Task<string> GetNextDogImageAsync()
        {
            CurrentDog = GetRandomDog();
            return await _dogRepository.GetRandomImageSource(CurrentDog);
        }

        public bool Guess(Dog selectedDog)
        {
            return selectedDog.Equals(CurrentDog);
        }

        private Dog GetRandomDog()
        {
            Random random = new Random();
            return Dogs[random.Next(Dogs.Count)];
        }
    }
}
