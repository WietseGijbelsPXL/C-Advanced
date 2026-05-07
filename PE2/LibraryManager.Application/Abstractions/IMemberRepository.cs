using LibraryManager.Domain.Entities;

namespace LibraryManager.Application.Abstractions
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
    }
}