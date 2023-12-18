using EFWithAsync.Data;
using EFWithAsync.Models;
using Microsoft.EntityFrameworkCore;

namespace EFWithAsync.Repository
{
    public class BookRepository:IBookRepository
    {
        private readonly ApplicationDbContext db;
        public BookRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddBook(Book book)
        {
            db.Add(book);
            int result= await db.SaveChangesAsync();
            return result;
        }

        public  Task<int> DeleteBook(int id)
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
