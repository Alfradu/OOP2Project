using Library.Models;

namespace Library.Repositories
{
    /// <summary>
    /// Factory for creating a context that is shared among the repositories.
    /// </summary>
    class RepositoryFactory
    {
        private LibraryContext context;

        /// <param name="c">A Librarycontext that will be shared among repositories</param>
        public RepositoryFactory(LibraryContext c)
        {
            this.context = c;
        }

        public BookRepository CreateBookRepository() => new BookRepository(context);
        public BookCopyRepository CreateBookCopyRepository() => new BookCopyRepository(context);
        public AuthorRepository CreateAuthorRepository() => new AuthorRepository(context);
        public MemberRepository CreateMemberRepository() => new MemberRepository(context);
        public LoanRepository CreateLoanRepository() => new LoanRepository(context);
    }
}
