using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.CompanyDto;

namespace Teknosib.Business.ValidationRules.CompanyRules
{
    public class UpdateCompanyDtoValidator : AbstractValidator<UpdateCompanyDto>
    {
        public UpdateCompanyDtoValidator()
        {
            // Company Name - LegalEntity Name'den geliyor (MaxLength 100)
            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş olamaz.")
                .MinimumLength(2).WithMessage("Şirket adı minimum 2 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Şirket adı maksimum 100 karakter olabilir.");

            // Phone Number - LegalEntity PhoneNumber'dan geliyor (MaxLength 14)
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş geçilemez.")
                .MaximumLength(14).WithMessage("Telefon numarası en fazla 14 karakter olabilir.");

            // Email - LegalEntity Email'den geliyor (Required)
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin");

            // Tax Number - Company özel alanı (Required, MaxLength 10)
            RuleFor(c => c.TaxNumber)
                .NotEmpty().WithMessage("Vergi no boş geçilemez.")
                .MaximumLength(10).WithMessage("Vergi no en fazla 10 karakter olabilir.");

            // Content Email - Optional email
            RuleFor(c => c.ContentEmail)
                .EmailAddress().WithMessage("Geçerli bir email adresi girin")
                .When(c => !string.IsNullOrEmpty(c.ContentEmail));

            // Industry - Company özel alanı (MaxLength 100)
            RuleFor(c => c.Industry)
                .MaximumLength(100).WithMessage("Sektör bilgisi en fazla 100 karakter olabilir.");

            // Description - Company özel alanı (MaxLength 250)
            RuleFor(c => c.Description)
                .MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olabilir.");

            // Employee Count - Optional, default 0
            RuleFor(c => c.EmployeeCount)
                .GreaterThanOrEqualTo(0).WithMessage("Çalışan sayısı 0 veya daha büyük olmalıdır.")
                .When(c => c.EmployeeCount.HasValue);

            // Expertise Areas - Business alanı
            RuleFor(c => c.ExpertiseAreas)
                .NotEmpty().WithMessage("Uzmanlık alanı boş bırakılamaz.")
                .MaximumLength(200).WithMessage("Uzmanlık alanı 200 karakteri geçemez.");

            // Experience Year - Business alanı
            RuleFor(c => c.ExperienceYear)
                .GreaterThan(0).WithMessage("Deneyim yılı 0'dan büyük olmalıdır.")
                .LessThan(100).WithMessage("Deneyim yılı 100'den küçük olmalıdır.");
        }
    }
} 