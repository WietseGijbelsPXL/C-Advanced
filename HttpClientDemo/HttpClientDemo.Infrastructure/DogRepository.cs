using HttpClientDemo.Domain.DTO;
using HttpClientDemo.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HttpClientDemo.Infrastructure
{
    public class DogRepository
    {

        public async Task<List<Dog>> GetData()
        {
            List<Dog> dogs = new List<Dog>();
            HttpClient httpClient = new HttpClient();

            string content = await httpClient.GetStringAsync("https://dog.ceo/api/breeds/list/all");

            var test = JsonSerializer.Deserialize<DogDTO>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach (var dog in test.Message)
            {
                if (dog.Value.Count > 0)
                {
                    foreach (var item in dog.Value)
                    {
                        dogs.Add(new Dog() { Name = dog.Key, SubBreed = item });
                    }
                }
                else
                {
                    dogs.Add(new Dog() { Name = dog.Key });
                }
            }
            return dogs;
        }

        public async Task<string> GetRandomImageSource()
        {
            HttpClient httpClient = new HttpClient();

            ImageSourceDTO imageSource = await httpClient.GetFromJsonAsync<ImageSourceDTO>("https://dog.ceo/api/breeds/image/random", new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

            return imageSource.Message;
        }
    }
}
