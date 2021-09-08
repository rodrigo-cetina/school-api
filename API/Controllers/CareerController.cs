using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;

namespace API.Controllers
{
  public class CareerController : BaseApiController
  {
    private readonly ICareerRepository _careerRepo;
    private readonly IMapper _mapper;
    public CareerController(ICareerRepository careerRepo, IMapper mapper)
    {
        _careerRepo = careerRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<CareerDto>> GetCareers()
    {
      var careers = await _careerRepo.GetCareersAsync();

      var data = _mapper.Map<IReadOnlyList<Career>, IReadOnlyList<CareerDto>>(careers);

      return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CareerDto>> GetCareer(int id)
    {
      var career = await _careerRepo.GetCareerByIdAsync(id);

      if (career == null) return NotFound(new ApiResponse(404));

      return Ok(_mapper.Map<Career, CareerDto>(career));
    }
  }
}