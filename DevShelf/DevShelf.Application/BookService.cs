using DevShelf.Application.Models;
using DevShelf.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(BookRepository repository)
        {
            _repository = repository;
        }

        public BookResult GetBooks(BookRequest request)
        {
            BookResult result = new BookResult();

            //TODO: filter and sort the collection of books from the repository
            //TODO: complete the result object

            result.Books = _repository.GetBooks().Where(b => b.Rating >= request.RatingFilter);

            if (!string.IsNullOrWhiteSpace(request.TitleFilter)) result.Books = result.Books.Where(b => b.Title.ToLower().Contains(request.TitleFilter.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.AuthorFilter)) result.Books = result.Books.Where(b => b.Author == request.AuthorFilter);

            if (!string.IsNullOrWhiteSpace(request.OrderBy) && request.OrderBy == "Year")
            {
                if (request.OrderDirection == "asc") { result.Books = result.Books.OrderBy(b => b.Year); }
                else result.Books = result.Books.OrderByDescending(b => b.Year);
            }

            result.TotalPages = result.Books.Count() % request.BooksPerPage == 0 ? result.Books.Count() / request.BooksPerPage : result.Books.Count() / request.BooksPerPage + 1;
            result.CurrentPage = request.Page;
            result.Books = result.Books.Skip((result.CurrentPage - 1) * request.BooksPerPage).Take(request.BooksPerPage);

            return result;
        }

        public IEnumerable<string> GetAllAuthors()
        {
            //TODO: Return a list of unique authors
            return _repository.GetBooks().Select(b => b.Author).Distinct();
        }
    }
}
