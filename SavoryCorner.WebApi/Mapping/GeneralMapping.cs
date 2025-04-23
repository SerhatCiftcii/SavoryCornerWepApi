using AutoMapper;
using SavoryCorner.WebApi.Dtos.FeatureDtos;
using SavoryCorner.WebApi.Dtos.MessageDtos;
using SavoryCorner.WebApi.Entites;

namespace SavoryCorner.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDtos>().ReverseMap();
            CreateMap<Feature, CreateFeatureDtos>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDtos>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDtos>().ReverseMap();


            CreateMap<Message, ResultMessageDtos>().ReverseMap();
            CreateMap<Message, CreateMessageDtos>().ReverseMap();
            CreateMap<Message, UpdateMessageDtos>().ReverseMap();
            CreateMap<Message, GetByIdMessageDtos>().ReverseMap();
        }
    }
}
