using LibraryManager.Domain.Entities;

namespace LibraryManager.Domain.Common
{
    public interface ILoanable
    {
        bool IsAvailable { get; }
        string? LoanedBy { get; }
        DateTime? ReturnDate { get; }

        void LoanTo(Member member, DateTime startDate);
        void Return();
    }
}