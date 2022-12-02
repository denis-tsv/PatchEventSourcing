using FluentValidation;
using Api.Dto;

namespace Api.Validators;

public class ProductValidator : AbstractValidator<PatchProductDto>
{
    public ProductValidator()
    {
        When(x => x.Name != null, () => RuleFor(x => x.Name!.Value).NotEmpty());
    }
}