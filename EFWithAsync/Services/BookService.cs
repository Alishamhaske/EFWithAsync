using EFWithAsync.Models;
using EFWithAsync.Repository;

namespace EFWithAsync.Services
{
    public class BookService:IBookService
    {
        private readonly IBookRepository repo;
        public BookService( IBookRepository repo) 
        {
            this.repo=repo;
        }

        public async Task<int> AddBook(Book book)
        {
            return await repo.AddBook(book);
        }

        public Task<int> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
