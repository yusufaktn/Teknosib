using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.RegisterDto;

namespace Teknosib.Business.ValidationRules.AuthRules.RegisterRules
{
    public class RegisterInstitutionDtoValidator : AbstractValidator<RegisterInstitutionDto>
    {
        public RegisterInstitutionDtoValidator()
        {
            // Institution Name - LegalEntity Name'den geliyor (MaxLength 100)
            RuleFor(i => i.IntitutionName)
                .NotEmpty().WithMessage("Kurum adı boş olamaz.")
                .MinimumLength(2).WithMessage("Kurum adı minimum 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Kurum adı maksimum 100 karakter olabilir.");

            // Phone Number - LegalEntity PhoneNumber'dan geliyor (MaxLength 14)
            RuleFor(i => i.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez")
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

            // Admin First Name - İlk admin kullanıcı
            RuleFor(i => i.AdminFirstName)
                .NotEmpty().WithMessage("Admin adı boş geçilemez.")
                .MaximumLength(100).WithMessage("Admin adı en fazla 100 karakter olabilir.");

            // Admin Last Name - İlk admin kullanıcı
            RuleFor(i => i.AdminLastName)
                .NotEmpty().WithMessage("Admin soyadı boş geçilemez.")
                .MaximumLength(100).WithMessage("Admin soyadı en fazla 100 karakter olabilir.");

            // Admin Email - İlk admin kullanıcı
            RuleFor(i => i.AdminEmail)
                .NotEmpty().WithMessage("Admin email boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir admin email adresi girin");

            // Admin Password - İlk admin kullanıcı
            RuleFor(i => i.AdminPassword)
                .NotEmpty().WithMessage("Admin şifresi boş geçilemez")
                .MinimumLength(8).WithMessage("Admin şifresi en az 8 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Admin şifresinde en az bir büyük harf olmalıdır")
                .Matches("[a-z]").WithMessage("Admin şifresinde en az bir küçük harf olmalıdır")
                .Matches("[0-9]").WithMessage("Admin şifresinde en az bir rakam olmalıdır.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Admin şifresinde en az bir özel karakter olmalıdır");

            // Adres bilgileri
            RuleFor(i => i.City)
                .NotEmpty().WithMessage("Şehir boş geçilemez.")
                .MaximumLength(300).WithMessage("Şehir en fazla 300 karakter olabilir.");

            RuleFor(i => i.District)
                .MaximumLength(50).WithMessage("İlçe en fazla 50 karakter olabilir.")
                .When(i => !string.IsNullOrEmpty(i.District));

            RuleFor(i => i.AddressLine)
                .MaximumLength(350).WithMessage("Adres satırı en fazla 350 karakter olabilir.")
                .When(i => !string.IsNullOrEmpty(i.AddressLine));

            RuleFor(i => i.PostalCode)
                .MaximumLength(50).WithMessage("Posta kodu en fazla 50 karakter olabilir.")
                .When(i => !string.IsNullOrEmpty(i.PostalCode));
        }
    }
} 