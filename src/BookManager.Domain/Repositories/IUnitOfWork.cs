namespace BookManager.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}