using FluentValidation;

namespace BusinessLogic.DTOModels.UsersDto.Validation;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
    }
}