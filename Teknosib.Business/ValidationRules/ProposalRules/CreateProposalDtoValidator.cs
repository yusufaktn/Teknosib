using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProposalDto;

namespace Teknosib.Business.ValidationRules.ProposalRules
{
    public class CreateProposalDtoValidator : AbstractValidator<CreateProposalDto>
    {
        public CreateProposalDtoValidator()
        {
            // Problem ID - Required
            RuleFor(p => p.ProblemId)
                .NotEmpty().WithMessage("Problem ID boş geçilemez.");

            // Provider Legal Entity ID - Required
            RuleFor(p => p.ProviderLegalEntityId)
                .NotEmpty().WithMessage("Hizmet sağlayıcı ID boş geçilemez.");

            // Applied Support Call ID - Optional (nullable)
            // Optional olduğu için özel validasyon gerekmiyor

            // Offer Details - Required, MaxLength 250
            RuleFor(p => p.OfferDetails)
                .NotEmpty().WithMessage("Teklif detayları boş geçilemez.")
                .MinimumLength(20).WithMessage("Teklif detayları en az 20 karakter olmalıdır.")
                .MaximumLength(250).WithMessage("Teklif detayları en fazla 250 karakter olabilir.");

            // Price - Required, decimal(18,2), must be positive
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Fiyat bilgisi boş geçilemez.")
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
                

            // Currency - Required
            RuleFor(p => p.Currency)
                .NotEmpty().WithMessage("Para birimi boş geçilemez.")
                .MinimumLength(3).WithMessage("Para birimi en az 3 karakter olmalıdır.")
                .MaximumLength(3).WithMessage("Para birimi en fazla 3 karakter olabilir.")
                .Matches("^[A-Z]{3}$").WithMessage("Para birimi 3 büyük harften oluşmalıdır (örn: TRY, USD, EUR).");

            // Proposal Status - Enum validation (optional since it has default value)
            RuleFor(p => p.ProposalStatus)
                .IsInEnum().WithMessage("Geçerli bir teklif durumu belirtilmelidir.");
                
        }
    }
} 