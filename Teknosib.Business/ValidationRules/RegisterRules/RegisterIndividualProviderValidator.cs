using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.RegisterDto;

namespace Teknosib.Business.ValidationRules.Register
{
    public class RegisterIndividualProviderValidator : AbstractValidator<RegisterIndividualProviderDto>
    {
        public RegisterIndividualProviderValidator()
        {
            RuleFor(i => i.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            RuleFor(i => i.Password)
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


            RuleFor(i => i.FirstName)
                .NotEmpty().WithMessage("Ad alanı boş geçilemez.")
                .MaximumLength(150).WithMessage("Ad  150 karakteri geçemez.");

            RuleFor(i => i.LastName)
                .NotEmpty().WithMessage("Soyad boş geçilemez.")
                .MaximumLength(150).WithMessage("Soyad 150 karakteri geçemez.");

            RuleFor(i => i.TCKN)
                .NotEmpty().WithMessage("TCKN boş geçilemez.")
                .MaximumLength(11).WithMessage("TCKN en fazla 11 karakter olabilir.")
                .Must(BeAllDigits).WithMessage("TCKN sadece rakam olabilir.");

            RuleFor(b => b.Biography)
                .NotEmpty().WithMessage("Biyografi alanı boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Biyografi alanı 500 karakteri geçemez.");


        }
        private bool BeAllDigits(string tckn)
        {
            return tckn.All(char.IsDigit);
        }

    }
}

