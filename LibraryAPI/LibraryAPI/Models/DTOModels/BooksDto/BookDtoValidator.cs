using FluentValidation;

namespace LibraryAPI.Models.DTOModels.BooksDto;

public class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator()
    {
        RuleFor(x => x.ISBN).NotEmpty().Length(13);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Genre).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(300);
        RuleFor(x => x.Author).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateOfTake).NotEmpty().LessThanOrEqualTo(x => x.DateOfReturn);
        RuleFor(x => x.DateOfReturn).NotEmpty().GreaterThanOrEqualTo(x => x.DateOfTake);
    }
}