using LibraryManager.Application.Abstractions;
using LibraryManager.Domain.Common;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Services
{
    public class LibraryService
    {
        private ILibraryItemRepository _libraryItemRepository;
        private IBookApiClient _bookApiClient;

        public LibraryService(ILibraryItemRepository libraryItemRepository, IBookApiClient bookApiClient)
        {
            _libraryItemRepository = libraryItemRepository;
            _bookApiClient = bookApiClient;
        }

        public async Task<Book> CreateBookFromOpenLibraryAsync(string isbn, string location)
        {
            BookResult bookResult = await _bookApiClient.GetBookByIsbnAsync(isbn);
            return new Book(bookResult, location);
        }

        public IEnumerable<LibraryItem> GetAllItems()
        {
            return _libraryItemRepository.GetAll();
        }

        public void AddItem(LibraryItem item)
        {
            _libraryItemRepository.Add(item);
        }

        public void UpdateItem(LibraryItem item)
        {
            _libraryItemRepository.Update(item);
        }

        public void LoanItem(Guid itemId, Member member, DateTime startDate)
        {
            LibraryItem libItem = _libraryItemRepository.GetById(itemId);
            if(libItem is ILoanable && ((ILoanable)libItem).IsAvailable )
            {
                ((ILoanable)libItem).LoanTo(member, startDate);
                _libraryItemRepository.Update(libItem);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void ReturnItem(Guid itemId)
        {
            LibraryItem libItem = _libraryItemRepository.GetById(itemId);
            if (libItem is ILoanable && !((ILoanable)libItem).IsAvailable)
            {
                ((ILoanable)libItem).Return();
                _libraryItemRepository.Update(libItem);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
