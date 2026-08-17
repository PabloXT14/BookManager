using BookManager.Domain.Entities;
using BookManager.Domain.Repositories.Users;
using BookManager.Exception.ExceptionsBase;

namespace BookManager.Application.UseCases.Users.GetByName;

public class GetByNameUseCase : IGetByNameUseCase
{
    private readonly IUsersRepository _usersRepository;

    public GetByNameUseCase(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<User> Execute(string name)
    {
        var user = await _usersRepository.GetByName(name);

        if (user == null)
        {
            throw new NotFoundException($"Usuário com o nome '{name}' não encontrado.");
        }

        return user;
    }
}