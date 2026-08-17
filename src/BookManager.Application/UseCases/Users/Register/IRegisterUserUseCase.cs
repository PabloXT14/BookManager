using BookManager.Communication.Requests;

namespace BookManager.Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    Task Execute(RequestUserJson request);
}