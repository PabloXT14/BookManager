using BookManager.Application.UseCases.Users.GetByName;
using BookManager.Application.UseCases.Users.Register;
using BookManager.Communication.Requests;
using BookManager.Domain.Entities;

namespace BookManager.Web.States;

public class UserState
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    private readonly IGetByNameUseCase _getByNameUseCase;

    public UserState(RegisterUserUseCase registerUserUseCase, IGetByNameUseCase getByNameUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
        _getByNameUseCase = getByNameUseCase;
    }

    public event Action? OnChange;
    public void NotifyStateChanged() => OnChange?.Invoke();

    public User? CurrentUser { get; private set; }

    public void SetCurrentUser(User user)
    {
        CurrentUser = user;
        NotifyStateChanged();
    }

    public void ClearCurrentUser()
    {
        CurrentUser = null;
        NotifyStateChanged();
    }

    public async Task GenerateTestUser()
    {
        var request = new RequestUserJson
        {
            Name = "John Doe",
        };

        await _registerUserUseCase.Execute(request);

        var user = await _getByNameUseCase.Execute(request.Name);

        SetCurrentUser(user);
    }
}