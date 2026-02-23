using FluentValidation;
using FluentValidation.AspNetCore;
using server.DTOs.Categories;

namespace server.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}