using AutoMapper;
using SignalR.DtoLayer.DiscountDto;

namespace SignalRApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<DiscountMapping, ResultDiscountDto>().ReverseMap();
            CreateMap<DiscountMapping, CreateDiscountDto>().ReverseMap();
            CreateMap<DiscountMapping, UpdateDiscountDto>().ReverseMap();
            CreateMap<DiscountMapping, GetDiscountDto>().ReverseMap();
        }
    }
}
