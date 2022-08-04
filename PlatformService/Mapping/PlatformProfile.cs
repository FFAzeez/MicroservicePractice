using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Model;

namespace PlatformService.Mapping
{
    public class PlatformProfile:Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformResponseDto>().ReverseMap();
            CreateMap<PlatformRequestDto, Platform>().ReverseMap();

        }
    }
}
