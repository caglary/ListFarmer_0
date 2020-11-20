using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.ValidationRules.FluentValidation
{
    public class CiftciValidator : AbstractValidator<Entities.Ciftci>
    {
        public CiftciValidator()
        {
            RuleFor(p => p.tc).NotEmpty().WithMessage("TC alanı boş olamaz.");
            RuleFor(p => p.tc).MinimumLength(11).WithMessage("Tc numarası eksik girdiniz.");
            RuleFor(p => p.tc).Must(Rakam).WithMessage("Tc alanı rakamlardan oluşur.");
            RuleFor(p => p.isim).NotEmpty().WithMessage("İsim alanı boş olamaz.");
            RuleFor(p => p.soyisim).NotEmpty().WithMessage("Soyisim alanı boş olamaz.");
            RuleFor(p => p.mahalle).NotEmpty().WithMessage("Mahalle alanı boş olamaz.");
            //RuleFor(p => p.isim).Must(HarfIleBaslamali).WithMessage("İsim alanı harflerden oluşur.");
        }
        private bool HarfIleBaslamali(string arg)
        {
            return arg.All(char.IsLetter);
        }
        private bool Rakam(string arg)
        {
            return arg.All(char.IsNumber);
        }
    }
}
