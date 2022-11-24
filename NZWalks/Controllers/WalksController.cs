using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task <IActionResult> GetAllWalksAsync()
        {
            //Fetch Dat from Database
                var walksDomain= await walkRepository.GetAllAsync();
            //Convert Domain Walks  to DTo Walks
            var WalksDTO = mapper.Map<List<Models.DTO.Walk>>(walksDomain);
            //Return respinse
            return Ok(WalksDTO);    
            
        }
    }
}
