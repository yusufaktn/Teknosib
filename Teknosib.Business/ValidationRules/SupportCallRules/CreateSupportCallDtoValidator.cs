using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.SupportCallDto;

namespace Teknosib.Business.ValidationRules.SupportCallRules
{
    public class CreateSupportCallDtoValidator : AbstractValidator<CreateSupportCallDto>
    {
        public CreateSupportCallDtoValidator()
        {
            // Publisher Legal Entity ID - Required
            RuleFor(s => s.PublisherLegalEntityId)
                .NotEmpty().WithMessage("Yayınlayıcı kurum ID boş geçilemez.");

            // Title - Required, MaxLength 100
            RuleFor(s => s.Title)
                .NotEmpty().WithMessage("Başlık boş geçilemez.")
                .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            // Description - Required, MaxLength 600
            RuleFor(s => s.Description)
                .NotEmpty().WithMessage("Açıklama boş geçilemez.")
                .MinimumLength(20).WithMessage("Açıklama en az 20 karakter olmalıdır.")
                .MaximumLength(600).WithMessage("Açıklama en fazla 600 karakter olabilir.");

            // Support Amount - Required, must be positive
            RuleFor(s => s.SupportAmount)
                .NotEmpty().WithMessage("Destek miktarı boş geçilemez.")
                .GreaterThan(0).WithMessage("Destek miktarı 0'dan büyük olmalıdır.");
                
        }
    }
} 