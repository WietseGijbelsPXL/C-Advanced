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

            var test = JsonSerializer.Deserialize<DogResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

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

        public async Task<string> GetRandomImageSource(Dog dog)
        {
            string url = $@"https://dog.ceo/api/breed/{dog.Name}/images/random";
            if (!string.IsNullOrWhiteSpace(dog.SubBreed))
            {
                url = $@"https://dog.ceo/api/breed/{dog.Name}/{dog.SubBreed}/images/random";
            }

            HttpClient httpClient = new HttpClient();

            string imageurl = await httpClient.GetStringAsync(url);
            ImageSourceResponse imgResponse = JsonSerializer.Deserialize<ImageSourceResponse>(imageurl, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return imgResponse.Message;
        }
    }
}
