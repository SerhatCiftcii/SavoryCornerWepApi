using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavoryCorner.WebApi.Context;
using SavoryCorner.WebApi.Dtos.MessageDtos;
using SavoryCorner.WebApi.Entites;

namespace SavoryCorner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var value= _context.Messages.ToList();
            var mappedValues = _mapper.Map<List<ResultMessageDtos>>(value);
            return Ok(mappedValues);
        }
        [HttpPost]
        public IActionResult CreateMessage (CreateMessageDtos createMessageDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var message = _mapper.Map<Message>(createMessageDtos);
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Mesaj Ekleme İşlemi Başarılı");
    }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Silinecek veri bulunamadı");
            }
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Veri bulunamadı");
            }
            var mappedValues = _mapper.Map<GetByIdMessageDtos>(value);
            return Ok(mappedValues);
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDtos updateMessageDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var message = _mapper.Map<Message>(updateMessageDtos);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Mesaj Güncelleme İşlemi Başarılı"); //çok gerekli değil.
        }

    }
}
