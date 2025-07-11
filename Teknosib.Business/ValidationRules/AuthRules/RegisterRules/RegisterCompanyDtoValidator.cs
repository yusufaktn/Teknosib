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

            RuleFor(c => c.Email)
               .NotEmpty().WithMessage("Email boş geçilemez.")
               .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Şifre boş geçilemez")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifrede en az bir büyük harf olmalıdır")
                .Matches("[a-z]").WithMessage("Şifrede en az bir küçük harf olmalıdır")
                .Matches("[0-9]").WithMessage("Şifrede en az bir rakam olmalıdır.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifrede en az bir özel karakter olmalıdır");

            RuleFor(c=>c.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş olamaz.")
                .MinimumLength(2).WithMessage("Şirket adı minimum 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Şirket adı maksimum 100 karakter olabilir.");

            RuleFor(c => c.TaxNumber)
                 .NotEmpty().WithMessage("Vergi no boş geçilemez.")
                 .MaximumLength(10).WithMessage("Vergi no en fazla 10 karakter olabilir.");


            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Adres boş geçilemez.")
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olabilir");

            RuleFor(c => c.Description)
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olabilir. ")
                .MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olabilir");

            RuleFor(c => c.Industry)
                .MaximumLength(100).WithMessage("Faaliyet alanı en fazla 100 karakter olabilir");

            

        }


    }
}
