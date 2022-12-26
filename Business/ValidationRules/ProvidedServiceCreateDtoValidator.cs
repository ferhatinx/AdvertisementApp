using Dtos;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ProvidedServiceCreateDtoValidator : AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.ImagePath).NotEmpty();
            RuleFor(x=>x.Title).NotEmpty();
        }
    }
}