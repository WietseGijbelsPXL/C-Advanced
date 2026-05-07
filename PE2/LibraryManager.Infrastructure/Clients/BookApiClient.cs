using LibraryManager.Domain.Results;
using LibraryManager.Infrastructure.Clients.Models;
using System.Net.Http.Json;
using System.Linq;
using System.Text.Json;
using LibraryManager.Application.Abstractions;

namespace LibraryManager.Infrastructure.Clients
{
    public class BookApiClient : IBookApiClient
    {


        private BookResult MapToBookResult(string isbn, OpenLibraryBookDto openLibraryBook)
        {
            return new BookResult
            {
                Title = openLibraryBook.Title,
                Authors = openLibraryBook.Authors != null && openLibraryBook.Authors.Any()
                                ? string.Join(", ", openLibraryBook.Authors.Select(a => a.Name ?? "Unknown"))
                                : string.Empty,
                Genre = openLibraryBook.Subjects != null && openLibraryBook.Subjects.Any()
                                ? openLibraryBook.Subjects.First().Name
                                : string.Empty,
                Year = openLibraryBook.PublishDate != null
                                ? ExtractYear(openLibraryBook.PublishDate)
                                : null,
                ISBN = isbn
            };
        }

        private int? ExtractYear(string publishDate)
        {
            if (string.IsNullOrWhiteSpace(publishDate))
                return null;

            var yearString = new string(publishDate.Where(char.IsDigit).ToArray());

            if (yearString.Length >= 4 && int.TryParse(yearString.Substring(0, 4), out var year))
            {
                return year;
            }

            return null;
        }

        public async Task<BookResult> GetBookByIsbnAsync(string isbn)
        {
            string key = $"ISBN:{new string(isbn.Where(c => char.IsDigit(c)).ToArray())}";

            HttpClient httpClient = new HttpClient();

            string content = await httpClient.GetStringAsync($"https://openlibrary.org/api/books?bibkeys={key}&format=json&jscmd=data");

            var response = JsonSerializer.Deserialize<Dictionary<string, OpenLibraryBookDto>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            OpenLibraryBookDto libraryBookDto = response.GetValueOrDefault(key);
            return MapToBookResult(isbn, libraryBookDto);
        }
    }
}
