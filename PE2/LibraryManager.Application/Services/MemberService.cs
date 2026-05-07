using LibraryManager.Application.Abstractions;
using LibraryManager.Domain.Entities;

namespace LibraryManager.Application.Services
{
    public class MemberService 
    {
        private IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetAll();
        }
    }
}