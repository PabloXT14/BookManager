using BookManager.Domain.Entities;

namespace BookManager.Application.UseCases.Users.GetByName;

public interface IGetByNameUseCase
{
    Task<User> Execute(string name);
}