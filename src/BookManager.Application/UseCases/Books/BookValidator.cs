using BookManager.Communication.Requests;
using FluentValidation;

namespace BookManager.Application.UseCases.Books;

public class BookValidator : AbstractValidator<RequestBookJson>
{
    public BookValidator()
    {
        RuleFor(book => book.Title)
            .NotEmpty().WithMessage("O título é obrigatório.")
            .MaximumLength(200).WithMessage("O título não pode exceder 200 caracteres.");

        RuleFor(book => book.Author)
            .NotEmpty().WithMessage("O autor é obrigatório.")
            .MaximumLength(100).WithMessage("O autor não pode exceder 100 caracteres.");

        RuleFor(book => book.Description)
            .MaximumLength(1000).WithMessage("A descrição não pode exceder 1000 caracteres.");

        RuleFor(book => book.ReadStatus)
            .IsInEnum().WithMessage("O status de leitura fornecido não é válido.");

        RuleFor(book => book.Rating)
            .InclusiveBetween(0, 5).WithMessage("A classificação deve ser entre 0 e 5.");
    }
}