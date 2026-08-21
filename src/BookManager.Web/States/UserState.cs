using BookManager.Application.UseCases.Users.GetByName;
using BookManager.Application.UseCases.Users.Register;
using BookManager.Communication.Requests;
using BookManager.Domain.Entities;
using BookManager.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Components;

namespace BookManager.Web.States;

public class UserState
{
    private readonly IRegisterUserUseCase _registerUserUseCase;
    private readonly IGetByNameUseCase _getByNameUseCase;

    public UserState(IRegisterUserUseCase registerUserUseCase, IGetByNameUseCase getByNameUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
        _getByNameUseCase = getByNameUseCase;
    }

    public event Action? OnChange;
    public void NotifyStateChanged() => OnChange?.Invoke();


    [PersistentState(AllowUpdates = true)]
    public User? CurrentUser { get; set; }

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
        try
        {
            var request = new RequestUserJson
            {
                Name = "John Doe",
            };

            await _registerUserUseCase.Execute(request);

            var user = await _getByNameUseCase.Execute(request.Name);

            SetCurrentUser(user);
        }
        catch (AlreadyExistsException)
        {
            // Handle the exception if the user already exists
            var user = await _getByNameUseCase.Execute("John Doe");
            SetCurrentUser(user);
        }
        catch (System.Exception)
        {
            // Handle other exceptions if necessary
            throw;
        }
    }
}