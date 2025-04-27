using FluentValidation;
using SavoryCorner.WebApi.Entites;

namespace SavoryCorner.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=> x.ProductName).NotEmpty().WithMessage("Ürün Adını Boş Geçmeyin");
            RuleFor(x=> x.ProductName).MinimumLength(2).WithMessage("Ürün Adı En Az 2 Karakter Olmalıdır");
            RuleFor(x=>x.ProductName).MaximumLength(50).WithMessage("Ürün Adı En Fazla 50 Karakter Olmalıdır");
           
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez").GreaterThan(0).WithMessage("Ürün Fiyatı Negatif Olamaz.").LessThan(1000).WithMessage("Ürün fiyatı bukadar yüksek olamaz , girdiğiniz değeri kontrol edin");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez!");
        }
    }
}
