using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // dependency injection for DbContext 
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Get All Regions
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data from Database  -  Domain Models
            var regionsDomain = dbContext.Regions.ToList();

            // Map Domain models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach(var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    id = regionDomain.id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            // Return DTOs
            return Ok(regionsDto);
        }

        // Get Single Region (Get Region By ID)
        // // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // The find method only takes the primary key, so you can't use the find method for other properties
            // var region = dbContext.Regions.Find(id);

            // Get Region Domain Model From Database
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.id == id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            // Map Region Domain Model to Region Dto
            var regionDto = new RegionDto
            {
                id = regionDomain.id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            // Return DTO back to client
            return Ok(regionDto);
        }
    }
}
