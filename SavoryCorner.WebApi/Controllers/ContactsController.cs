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
    }
}
