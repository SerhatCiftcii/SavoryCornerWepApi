using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavoryCorner.WebApi.Context;
using SavoryCorner.WebApi.Dtos.ContactDtos;
using SavoryCorner.WebApi.Entites;

namespace SavoryCorner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values= _context.Contacts.ToList();
            return Ok(values); //BURDA mapleme yok
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto )
        {
            Contact contact = new Contact //automappersiz olan daha kısaası automapper
            {
                MapLocation = createContactDto.MapLocation,
                Address = createContactDto.Address,
                Phone = createContactDto.Phone,
                Email = createContactDto.Email,
                OpenHours = createContactDto.OpenHours
                
                };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact= _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound("Silinecek kayıt bulunamadı");
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContact(int id)
        {
            var value= _context.Contacts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            // Veritabanındaki mevcut kaydı buluyoruz
            var contact = _context.Contacts.Find(updateContactDto.ContactId);

            // Eğer kayıt bulunamazsa, NotFound dönüyoruz
            if (contact == null)
            {
                return NotFound("Güncellenecek kayıt bulunamadı");
            }

            // Mevcut contact nesnesinin özelliklerini güncelliyoruz
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.Email = updateContactDto.Email;
            contact.OpenHours = updateContactDto.OpenHours;

            // Güncellenmiş contact nesnesini veritabanına kaydediyoruz
            _context.SaveChanges();

            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
