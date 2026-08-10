using BookManager.Communication.Requests;

namespace BookManager.Application.UseCases.Books.Register;

public interface IRegisterBookUseCase
{
    Task Execute(RequestBookJson request);
}