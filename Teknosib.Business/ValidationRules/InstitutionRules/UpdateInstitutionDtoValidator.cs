using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.InstitutionDto;

namespace Teknosib.Business.ValidationRules.InstitutionRules
{
    public class UpdateInstitutionDtoValidator : AbstractValidator<UpdateInstitutionDto>
    {
        public UpdateInstitutionDtoValidator()
        {
            // Institution Name - LegalEntity Name'den geliyor (MaxLength 100)
            RuleFor(i => i.InstitutionName)
                .NotEmpty().WithMessage("Kurum adı boş olamaz.")
                .MinimumLength(2).WithMessage("Kurum adı minimum 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Kurum adı maksimum 100 karakter olabilir.");

            // Phone Number - LegalEntity PhoneNumber'dan geliyor (MaxLength 14)
            RuleFor(i => i.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez.")
                .MaximumLength(14).WithMessage("Telefon numarası en fazla 14 karakter olabilir.");

            // Email - LegalEntity Email'den geliyor (Required)
            RuleFor(i => i.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            // Type - Institution özel alanı (Required)
            RuleFor(i => i.Type)
                .NotEmpty().WithMessage("Kurum tipi boş geçilemez.");

            // Institution Code - Institution özel alanı (MaxLength 100)
            RuleFor(i => i.InstitutionCode)
                .MaximumLength(100).WithMessage("Kurum kodu en fazla 100 karakter olabilir.")
                .When(i => !string.IsNullOrEmpty(i.InstitutionCode));

            // Official Title - Institution özel alanı (MaxLength 100)
            RuleFor(i => i.OfficialTitle)
                .MaximumLength(100).WithMessage("Resmi başlık en fazla 100 karakter olabilir.")
                .When(i => !string.IsNullOrEmpty(i.OfficialTitle));

            // Authority Name - Institution özel alanı (MaxLength 100)
            RuleFor(i => i.AuthorityName)
                .MaximumLength(100).WithMessage("Yetkili adı en fazla 100 karakter olabilir.")
                .When(i => !string.IsNullOrEmpty(i.AuthorityName));
        }
    }
} 