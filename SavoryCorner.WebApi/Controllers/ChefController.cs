using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavoryCorner.WebApi.Context;
using SavoryCorner.WebApi.Entites;
using System.Linq;

namespace SavoryCorner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChefController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {

            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Şef Ekleme İşlemi Başarılı");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteChef(int id)
        {
            // Veritabanında id'ye sahip şefi buluyoruz
            var value = _context.Chefs.FirstOrDefault(x => x.ChefId == id);

            // Şef bulunamadıysa NotFound döndürüyoruz
            if (value == null)
            {
                return NotFound("Silinecek şef bulunamadı.");
            }

            // Şefi silme işlemi
            _context.Chefs.Remove(value);
            _context.SaveChanges();

            return Ok("Şef silme işlemi başarılı.");
        }

        [HttpGet("GetChefById")]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chefs.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateChef(int id,Chef updateChef)
        {
            var value= _context.Chefs.FirstOrDefault(x=>x.ChefId==id);
            
            if(value == null)
            {
                return NotFound();
            }
           
            value.NameSurname = updateChef.NameSurname;
            value.Title = updateChef.Title;
            value.Description = updateChef.Description;
            value.ImageUrl = updateChef.ImageUrl;
          //  _context.Chefs.Update(value);
            _context.SaveChanges();
            return Ok("Chef Güncelleme başarılı");

        }
    }
    }
