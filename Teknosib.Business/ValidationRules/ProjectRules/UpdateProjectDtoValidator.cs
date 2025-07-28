using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProjectDto;

namespace Teknosib.Business.ValidationRules.ProjectRules
{
    public class UpdateProjectDtoValidator : AbstractValidator<UpdateProjectDto>
    {
        public UpdateProjectDtoValidator()
        {
            // Project Name - Required, MaxLength 100
            RuleFor(p => p.ProjectName)
                .NotEmpty().WithMessage("Proje adı boş geçilemez.")
                .MinimumLength(3).WithMessage("Proje adı en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Proje adı en fazla 100 karakter olabilir.");

            // Project Description - Required, MaxLength 300
            RuleFor(p => p.ProjectDescription)
                .NotEmpty().WithMessage("Proje açıklaması boş geçilemez.")
                .MinimumLength(10).WithMessage("Proje açıklaması en az 10 karakter olmalıdır.")
                .MaximumLength(300).WithMessage("Proje açıklaması en fazla 300 karakter olabilir.");

            // Start Date - Optional, but if provided, should not be in the past
            RuleFor(p => p.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Başlangıç tarihi bugünden önce olamaz.")
                .When(p => p.StartDate.HasValue);

            // Completed Date - Optional, but if provided, should be after start date
            RuleFor(p => p.ComplatedDate)
                .GreaterThan(p => p.StartDate).WithMessage("Tamamlanma tarihi başlangıç tarihinden sonra olmalıdır.")
                .When(p => p.ComplatedDate.HasValue && p.StartDate.HasValue);

            // Final Budget - Optional, but if provided, should be positive
            RuleFor(p => p.FinalBudget)
                .GreaterThan(0).WithMessage("Nihai bütçe 0'dan büyük olmalıdır.");


            // Project Status - Enum validation
            RuleFor(p => p.ProjectStatus)
                .IsInEnum().WithMessage("Geçerli bir proje durumu belirtilmelidir.");
                
        }
    }
} 