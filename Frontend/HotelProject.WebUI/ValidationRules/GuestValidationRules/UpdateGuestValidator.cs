using FluentValidation;
using HotelProject.WebUI.DTOs.GuestDTOs;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator: AbstractValidator<UpdateGuestDTO>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Firstname).NotNull().WithMessage("İsim alanı boş geçilemez.")
                                     .MinimumLength(2).WithMessage("İsim 2 karakterden az olamaz.")
                                     .MaximumLength(30).WithMessage("İsim 30 karakterden fazla olamaz.");

            RuleFor(x => x.Lastname).NotNull().WithMessage("Soyisim alanı boş geçilemez.")
                                    .MinimumLength(2).WithMessage("Soyisim 2 karakterden az olamaz.")
                                    .MaximumLength(30).WithMessage("Soyisim 30 karakterden fazla olamaz.");

            RuleFor(x => x.City).NotNull().WithMessage("Şehir alanı boş geçilemez.")
                                .MinimumLength(3).WithMessage("Şehir 3 karakterden az olamaz.")
                                .MaximumLength(20).WithMessage("Şehir 20 karakterden fazla olamaz.");
        }
    }
}
