using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SavoryCorner.WebApi.Context;
using SavoryCorner.WebApi.Entites;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SavoryCorner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
  //200 OK → İstek başarılı.
//  201 Created → Yeni kaynak oluşturuldu.
//204 No Content → Yanıt gövdesi yok.
//301 Moved Permanently → Kalıcı yönlendirme.
//302 Found → Geçici yönlendirme.
//400 Bad Request → Geçersiz istek.
//401 Unauthorized → Yetkilendirme gerekli.
//403 Forbidden → Erişim yasak.
//404 Not Found → Kaynak bulunamadı.
//500 Internal Server Error → Sunucu hatası.
//503 Service Unavailable → Sunucu şu an kullanılamıyor.
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori ekleme işlemi başarili");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value= _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori Silme İşlemi Başarılı");
        }
        [HttpGet("GetCategoryById")]// bir conttroller içinde aynı attrubute tüürnde birden fazla kez kullanılmaz [HttpGet] yukardaki normal httpgetden ayırmak için isim ver
        public IActionResult GetCategory(int id ) 
        { 
            var value= _context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult PutCategory(int id, Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori Güncelleme İşlemi Başarılı");
        }

    }
}
