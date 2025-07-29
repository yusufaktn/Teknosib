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
                .NotEmpty().WithMessage("Şifre boş geçilemez");
                

        }
    }
}
