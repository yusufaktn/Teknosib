using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CategoryDto;
using Teknosib.Business.Dto.ProblemDto;

namespace Teknosib.Business.ValidationRules.ProblemRules
{
    public class CreateProblemDtoValidator : AbstractValidator<CreateProblemDto>
    {
        public CreateProblemDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
                .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olabilir.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
                .MinimumLength(20).WithMessage("Açıklama en az 20 karakter olmalıdır.")
                .MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olmalıdır.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Kategori seçimi zorunludur.");

            RuleFor(p => p.OwnerLegalEntityId)
                .NotEmpty().WithMessage("Şirket bilgisi zorunludur.");



        }
    }
}
