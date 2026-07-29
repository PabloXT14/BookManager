using BookManager.Domain.Entities;

namespace BookManager.Domain.Repositories.Books;

public interface IBooksRepository
{
    Task<List<Book>> GetAll();
    Task<Book?> GetById(Guid id);
    Task Add(Book book);
    Task Update(Book book);
    Task Delete(Guid id);
}