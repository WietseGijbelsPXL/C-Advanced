using HttpClientDemo.Domain.Models;
using HttpClientDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo.Application
{
    public class DogService
    {
        private DogRepository _dogRepository = new DogRepository();
        public List<Dog> Dogs { get; private set; }
        public string ImageSource { get; private set; }

        public async Task GetAll()
        {
            Dogs = await _dogRepository.GetData();
        }

        public async Task GetRandomImageSouce()
        {
            ImageSource = await _dogRepository.GetRandomImageSource();
        }
    }
}
