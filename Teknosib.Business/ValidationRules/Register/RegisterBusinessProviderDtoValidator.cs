using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.RegisterDto;

namespace Teknosib.Business.ValidationRules.Register
{
    public class RegisterBusinessProviderDtoValidator : AbstractValidator<RegisterBusinessProviderDto>
    {
        public RegisterBusinessProviderDtoValidator()
        {
            RuleFor(b => b.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            RuleFor(b => b.Password)
                .NotEmpty().WithMessage("Şifre boş geçilemez")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifrede en az bir büyük harf olmalıdır")
                .Matches("[a-z]").WithMessage("Şifrede en az bir küçük harf olmalıdır")
                .Matches("[0-9]").WithMessage("Şifrede en az bir rakam olmalıdır.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifrede en az bir özel karakter olmalıdır");


            RuleFor(b => b.ExpertiseAreas)
                .NotEmpty().WithMessage("Uzmanlık alanı boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Uzmanlık alanı 200 karakteri geçemez.");

            RuleFor(b => b.ExperienceYear)
                .NotEmpty().WithMessage("Deneyim yılı boş geçilemez.");

            RuleFor(b => b.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez")
                .MaximumLength(14).WithMessage("Telfon formatına uygun değil");

            RuleFor(b => b.CompanyName)
                .NotEmpty().WithMessage("Şirket ismi boş geçilemez")
                .MaximumLength(250).WithMessage("Şirket ismi en fazla 250 karakter olabilir.");

            RuleFor(b => b.TaxNumber)
               .NotEmpty().WithMessage("Vergi numarası boş geçilemez.")
               .MaximumLength(10).WithMessage("Vergi numarası en fazla 10 karakter olabilir.");


            RuleFor(b => b.OfficialAddress)
                .NotEmpty().WithMessage("Offical adres boş geçilemez")
                .MaximumLength(350).WithMessage("Offical adres en fazla 350 karakter olabilir.");

            RuleFor(b => b.PhysicalAddress)
                .NotEmpty().WithMessage("Fizikse adres boş geçilemez")
                .MaximumLength(350).WithMessage("Fiziksel adres en fazla 350 karakter olabilir.");




        }
    }
}
