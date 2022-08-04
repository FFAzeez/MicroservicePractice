using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Repository;
using PlatformService.DTOs;
using PlatformService.Model;
using System.Collections.Generic;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;
        public PlatformController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet("GetPlatforms")]
        public ActionResult<IEnumerable<PlatformResponseDto>> GetPlatforms()
        {
            var platforms =  _platformRepo.GetAllPlatform();
            var result = _mapper.Map<IEnumerable<PlatformResponseDto>>(platforms);
            return Ok(result);
        }

        [HttpGet("Id")]
        public ActionResult<PlatformResponseDto> GetPlatformById(int Id)
        {
            var platform = _platformRepo.GetPlatformById(Id);
            if(platform != null)
            {
                var result = _mapper.Map<PlatformResponseDto>(platform);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("CreatePlatform")]
        public IActionResult CreatePlatform(PlatformRequestDto platformRequest)
        {
            var map = _mapper.Map<Platform>(platformRequest);
            _platformRepo.CreatePlatform(map);
            _platformRepo.SaveChange();
            var platform = _mapper.Map<PlatformResponseDto>(map);
            return Created("",platform);
        }

    }
}
