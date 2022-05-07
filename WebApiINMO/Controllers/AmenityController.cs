﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiINMO.DTOs;
using WebApiINMO.Entities;

namespace WebApiINMO.Controllers
{
    [ApiController]
    [Route("api/amenities")]
    public class AmenityController: ControllerBase
    {

        private readonly ApplicationDbContext Context;
        private readonly IMapper Mapper;


        public AmenityController(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<AmenityDTO>>> GetAll()
        {
            var amenities = await Context.Amenities.ToListAsync();

            return Mapper.Map<List<AmenityDTO>>(amenities);
        }



        [HttpPost]
        public async Task<ActionResult> Create(AmenityCreateDTO amenityDTO)
        {
            var amenity = Mapper.Map<Amenity>(amenityDTO);

            Context.Add(amenity);

            await Context.SaveChangesAsync();

            return Ok();

        }


    }
}
