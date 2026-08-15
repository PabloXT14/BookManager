using FluentValidation;

namespace BookManager.Web.Components.Pages.Home.Components.BookForm;

public class BookFormValidator : AbstractValidator<BookFormModel>
{
    public BookFormValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título é obrigatório.")
            .MaximumLength(100).WithMessage("O título não pode ter mais de 100 caracteres.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("A descrição não pode ter mais de 500 caracteres.");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("O autor é obrigatório.")
            .MaximumLength(100).WithMessage("O autor não pode ter mais de 100 caracteres.");

        RuleFor(x => x.ReadStatus)
            .IsInEnum().WithMessage("O status de leitura é inválido.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5).WithMessage("A avaliação deve estar entre 0 e 5 estrelas.");

        RuleFor(x => x.CoverImageUrl)
            .Must(uri =>
                Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("A URL da imagem de capa é inválida.");
    }
}