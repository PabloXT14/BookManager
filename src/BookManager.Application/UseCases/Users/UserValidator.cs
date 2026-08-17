using BookManager.Communication.Requests;
using FluentValidation;

namespace BookManager.Application.UseCases.Users;

public class UserValidator : AbstractValidator<RequestUserJson>
{
    public UserValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("O nome do usuário não pode estar vazio.")
            .Length(3, 50).WithMessage("O nome do usuário deve ter entre 3 e 50 caracteres.");
    }
}