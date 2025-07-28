using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AddressDto;

namespace Teknosib.Business.ValidationRules.AddressRules
{
    public class CreateAddressDtoValidator : AbstractValidator<CreateAddressDto>
    {
        public CreateAddressDtoValidator()
        {
            
            

            // City - Required, MaxLength 300
            RuleFor(a => a.City)
                .NotEmpty().WithMessage("Şehir bilgisi boş geçilemez.")
                .MaximumLength(300).WithMessage("Şehir bilgisi en fazla 300 karakter olabilir.");

            // District - Optional, MaxLength 50
            RuleFor(a => a.District)
                .MaximumLength(50).WithMessage("İlçe bilgisi en fazla 50 karakter olabilir.")
                .When(a => !string.IsNullOrEmpty(a.District));

            // AddressLine - Optional, MaxLength 350
            RuleFor(a => a.AddressLine)
                .MaximumLength(350).WithMessage("Adres satırı en fazla 350 karakter olabilir.")
                .When(a => !string.IsNullOrEmpty(a.AddressLine));

            // PostalCode - Optional, MaxLength 50
            RuleFor(a => a.PostalCode)
                .MaximumLength(50).WithMessage("Posta kodu en fazla 50 karakter olabilir.")
                .When(a => !string.IsNullOrEmpty(a.PostalCode));
        }
    }
} 