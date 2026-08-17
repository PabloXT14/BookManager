using AutoMapper;
using BookManager.Communication.Requests;
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using BookManager.Domain.Repositories.Users;
using BookManager.Exception.ExceptionsBase;

namespace BookManager.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUsersRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterUserUseCase(IUsersRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Execute(RequestUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);

        var existingUser = await _userRepository.GetByName(user.Name);

        if (existingUser != null)
        {
            throw new AlreadyExistsException("O usuário já existe.");
        }

        await _userRepository.Add(user);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestUserJson request)
    {
        var validator = new UserValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}