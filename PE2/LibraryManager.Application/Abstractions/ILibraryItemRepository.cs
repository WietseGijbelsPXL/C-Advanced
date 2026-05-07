using LibraryManager.Domain.Common;

namespace LibraryManager.Application.Abstractions
{
    public interface ILibraryItemRepository
    {
        void Add(LibraryItem item);
        IEnumerable<LibraryItem> GetAll();
        LibraryItem GetById(Guid id);
        void Update(LibraryItem updatedItem);
    }
}