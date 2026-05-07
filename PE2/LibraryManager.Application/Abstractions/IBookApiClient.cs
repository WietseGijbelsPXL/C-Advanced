using LibraryManager.Domain.Results;

namespace LibraryManager.Application.Abstractions
{
    public interface IBookApiClient
    {
        Task<BookResult> GetBookByIsbnAsync(string isbn);
    }
}