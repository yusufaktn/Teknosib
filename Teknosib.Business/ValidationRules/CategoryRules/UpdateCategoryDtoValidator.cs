using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CategoryDto;

namespace Teknosib.Business.ValidationRules.CategoryRules
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            // Name - MaxLength 50 (configuration'dan)
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Kategori adı boş geçilemez.")
                .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");

            // Description - MaxLength 150 (configuration'dan)
            RuleFor(c => c.Description)
                .MaximumLength(150).WithMessage("Kategori açıklaması en fazla 150 karakter olabilir.")
                .When(c => !string.IsNullOrEmpty(c.Description));
        }
    }
} 