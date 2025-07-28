using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.RegisterDto;

namespace Teknosib.Business.ValidationRules.AuthRules.RegisterRules
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(i => i.LegalEntityId)
                .NotEmpty().WithMessage("Legal Entity ID boş geçilemez.");

            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("Ad alanı boş geçilemez.")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir.");

            RuleFor(i => i.Surname)
                .NotEmpty().WithMessage("Soyad alanı boş geçilemez.")
                .MaximumLength(100).WithMessage("Soyad en fazla 100 karakter olabilir.");

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

            //RuleFor(i => i.LastName)
            //    .NotEmpty().WithMessage("Soyad boş geçilemez.")
            //    .MaximumLength(150).WithMessage("Soyad 150 karakteri geçemez.");

            //RuleFor(i => i.TCKN)
            //    .NotEmpty().WithMessage("TCKN boş geçilemez.")
            //    .MaximumLength(11).WithMessage("TCKN en fazla 11 karakter olabilir.")
            //    .Must(BeAllDigits).WithMessage("TCKN sadece rakam olabilir.");

            //RuleFor(b => b.Biography)
            //    .NotEmpty().WithMessage("Biyografi alanı boş bırakılamaz.")
            //    .MaximumLength(500).WithMessage("Biyografi alanı 500 karakteri geçemez.");


        }
        private bool BeAllDigits(string tckn)
        {
            return tckn.All(char.IsDigit);
        }

    }
}

