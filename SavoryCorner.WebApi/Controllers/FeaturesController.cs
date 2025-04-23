using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SavoryCorner.WebApi.Context;
using SavoryCorner.WebApi.Dtos.FeatureDtos;
using SavoryCorner.WebApi.Entites;

namespace SavoryCorner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList(); //aute mapper
            var mappedValues= _mapper.Map<List<ResultFeatureDtos>>(values);
            return Ok(mappedValues);
        }
        [HttpPost]
        public IActionResult CreateFature(CreateFeatureDtos createFeatureDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var feature = _mapper.Map<Feature>(createFeatureDtos);
            _context.Features.Add(feature);
            _context.SaveChanges();
           return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _context.Features.Find(id);
            if (id == null)
            {
                return NotFound("Silinecek veri bulunamadı");
            }
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeatureById(int id) 
        { 
            var values= _context.Features.Find(id);
            if(values == null)
            {
                return NotFound("Veri bulunamadı");
            }
            var mappedValues = _mapper.Map<GetByIdFeatureDtos>(values);
            return Ok(mappedValues);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDtos updateFeatureDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var value= _mapper.Map<Feature>(updateFeatureDtos);
            _context.Features.Update(value);
            return Ok("Güncelleme işlemi başarılı");
        }

    }
    
}
