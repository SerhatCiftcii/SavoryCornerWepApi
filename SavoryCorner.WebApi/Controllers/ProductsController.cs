using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavoryCorner.WebApi.Context;
using SavoryCorner.WebApi.Entites;

namespace SavoryCorner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;

    

        public ProductsController(IValidator<Product> validator, ApiContext context)
        {
            _validator = validator; 
            _context = context; 
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (validationResult.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(new { message = "Ürün Ekleme İşlemi Başarılı", data = product });
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }
        }
    }
}
