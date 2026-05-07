using LibraryManager.Domain.Entities;
using LibraryManager.Application.Abstractions;

namespace LibraryManager.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly List<Member> _members = new List<Member>();

        public MemberRepository()
        {
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            _members.Add(new Member(Guid.NewGuid(), "John", "Doe"));
            _members.Add(new Member(Guid.NewGuid(), "Jane", "Smith"));
            _members.Add(new Member(Guid.NewGuid(), "Alice", "Johnson"));
            _members.Add(new Member(Guid.NewGuid(), "Bob", "Williams"));
            _members.Add(new Member(Guid.NewGuid(), "Carol", "Brown"));
            _members.Add(new Member(Guid.NewGuid(), "David", "Jones"));
            _members.Add(new Member(Guid.NewGuid(), "Emma", "Garcia"));
            _members.Add(new Member(Guid.NewGuid(), "Frank", "Miller"));
            _members.Add(new Member(Guid.NewGuid(), "Grace", "Davis"));
            _members.Add(new Member(Guid.NewGuid(), "Henry", "Rodriguez"));
        }

        public IEnumerable<Member> GetAll()
        {
            return _members.ToList();
        }
    }
}
