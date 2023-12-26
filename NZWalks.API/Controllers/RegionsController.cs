using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        // dependency injection for DbContext 
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // Get All Regions
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data from Database  -  Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Map Domain models to DTOs
            /* var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    id = regionDomain.id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            } */    

            // Map Domain models to DTOs using AutoMapper
            // Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // Get Single Region (Get Region By ID)
        // // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // The find method only takes the primary key, so you can't use the find method for other properties
            // var region = dbContext.Regions.Find(id);

            // Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Region Domain Model to Region Dto
            /* var regionDto = new RegionDto
            {
                id = regionDomain.id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            }; */

            // Map Region Domain Model to Region Dto using AutoMapper
            // Return DTO back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST To Create New Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
           
                // Map DTO to Domain Model
                /* var regionDomainModel = new Region
                {
                    Code = addRegionRequestDto.Code,
                    Name = addRegionRequestDto.Name,
                    RegionImageUrl = addRegionRequestDto.RegionImageUrl
                }; */

                // Map DTO to Domain Model using AutoMapper
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // Use Domain Model to Create Region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                // Map Domain Model back to DTO
                /*var regionDto = new RegionDto
                {
                    id = regionDomainModel.id,
                    Code = regionDomainModel.Code,
                    Name = regionDomainModel.Name,
                    RegionImageUrl = regionDomainModel.RegionImageUrl
                };*/

                // Map Domain Model back to DTO using AutoMapper
                // var regionDto = mapper.Map<DESTINATION>(SOURCE);
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.id }, regionDto);
                           
        }

        // UPDATE Region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {           
                // Map DTO to Domain Model
                /* var regionDomainModel = new Region
                {
                    Code = updateRegionRequestDto.Code,
                    Name = updateRegionRequestDto.Name,
                    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
                }; */

                // Map DTO to Domain Model using AutoMapper
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                // check if region exists
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                // Convert Domain model to DTO
                /* var regionDto = new RegionDto
                {
                    id = regionDomainModel.id,
                    Code = regionDomainModel.Code,
                    Name = regionDomainModel.Name,
                    RegionImageUrl = regionDomainModel.RegionImageUrl
                };*/

                // Convert Domain model to DTO using AutoMapper
                return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        // DELETE Region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // return deleted region back
            // map domain model to Dto
            /* var regionDto = new RegionDto
            {
                id = regionDomainModel.id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            }; */

            // map domain model to Dto using AutoMapper
            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
