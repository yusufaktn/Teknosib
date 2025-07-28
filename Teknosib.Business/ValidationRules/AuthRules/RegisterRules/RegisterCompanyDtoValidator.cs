using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.RegisterDto;

namespace Teknosib.Business.ValidationRules.AuthRules.RegisterRules
{
    public class RegisterCompanyDtoValidator:AbstractValidator<RegisterCompanyDto>
    {
        public RegisterCompanyDtoValidator()
        {
            // Company/LegalEntity bilgileri
            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş olamaz.")
                .MinimumLength(2).WithMessage("Şirket adı minimum 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Şirket adı maksimum 100 karakter olabilir.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez")
                .MaximumLength(14).WithMessage("Telefon numarası en fazla 14 karakter olabilir.");

            RuleFor(c => c.Email)
               .NotEmpty().WithMessage("Email boş geçilemez.")
               .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            // Company özel alanları
            RuleFor(c => c.TaxNumber)
                 .NotEmpty().WithMessage("Vergi no boş geçilemez.")
                 .MaximumLength(10).WithMessage("Vergi no en fazla 10 karakter olabilir.");

            RuleFor(c => c.Industry)
                .MaximumLength(100).WithMessage("Sektör bilgisi en fazla 100 karakter olabilir.");

            RuleFor(c => c.ExpertiseAreas)
                .NotEmpty().WithMessage("Uzmanlık alanı boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Uzmanlık alanı 200 karakteri geçemez.");

            RuleFor(c => c.ExperienceYear)
                .GreaterThan(0).WithMessage("Deneyim yılı 0'dan büyük olmalıdır.")
                .LessThan(100).WithMessage("Deneyim yılı 100'den küçük olmalıdır.");

            // Admin kullanıcı bilgileri
            RuleFor(c => c.AdminFirstName)
                .NotEmpty().WithMessage("Admin adı boş geçilemez.")
                .MaximumLength(100).WithMessage("Admin adı en fazla 100 karakter olabilir.");

            RuleFor(c => c.AdminLastName)
                .NotEmpty().WithMessage("Admin soyadı boş geçilemez.")
                .MaximumLength(100).WithMessage("Admin soyadı en fazla 100 karakter olabilir.");

            RuleFor(c => c.AdminEmail)
                .NotEmpty().WithMessage("Admin email boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir admin email adresi girin");

            RuleFor(c => c.AdminPassword)
                .NotEmpty().WithMessage("Admin şifresi boş geçilemez")
                .MinimumLength(8).WithMessage("Admin şifresi en az 8 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Admin şifresinde en az bir büyük harf olmalıdır")
                .Matches("[a-z]").WithMessage("Admin şifresinde en az bir küçük harf olmalıdır")
                .Matches("[0-9]").WithMessage("Admin şifresinde en az bir rakam olmalıdır.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Admin şifresinde en az bir özel karakter olmalıdır");

            // Adres bilgileri
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Şehir boş geçilemez.")
                .MaximumLength(300).WithMessage("Şehir en fazla 300 karakter olabilir.");

            RuleFor(c => c.District)
                .MaximumLength(50).WithMessage("İlçe en fazla 50 karakter olabilir.");

            RuleFor(c => c.AddressLine)
                .MaximumLength(350).WithMessage("Adres satırı en fazla 350 karakter olabilir.");

            RuleFor(c => c.PostalCode)
                .MaximumLength(50).WithMessage("Posta kodu en fazla 50 karakter olabilir.");

            //RuleFor(c => c.Description)
            //    .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olabilir. ")
            //    .MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olabilir");

            //RuleFor(c => c.Industry)
            //    .MaximumLength(100).WithMessage("Faaliyet alanı en fazla 100 karakter olabilir");

            

        }


    }
}
