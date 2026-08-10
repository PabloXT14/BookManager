using AutoMapper;
using BookManager.Communication.Requests;
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using BookManager.Domain.Repositories.Books;
using BookManager.Exception.ExceptionsBase;

namespace BookManager.Application.UseCases.Books.Register;

public class RegisterBookUseCase : IRegisterBookUseCase
{
    private readonly IBooksRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork unitOfWork;

    public RegisterBookUseCase(IBooksRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task Execute(RequestBookJson request)
    {
        Validate(request);

        var book = _mapper.Map<Book>(request);

        await _bookRepository.Add(book);

        await unitOfWork.Commit();
    }

    private void Validate(RequestBookJson request)
    {
        var validator = new BookValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}