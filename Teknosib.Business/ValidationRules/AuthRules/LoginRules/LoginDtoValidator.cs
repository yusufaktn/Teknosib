using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.AuthDto.LoginDto;

namespace Teknosib.Business.ValidationRules.AuthRules.LoginRules
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Şifre boş geçilemez")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifrede en az bir büyük harf olmalıdır")
                .Matches("[a-z]").WithMessage("Şifrede en az bir küçük harf olmalıdır")
                .Matches("[0-9]").WithMessage("Şifrede en az bir rakam olmalıdır.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifrede en az bir özel karakter olmalıdır");

        }
    }
}
