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
using API.Authorization;

namespace API.Controllers
{
  [Authorize]
  public class AdministratorController : BaseApiController
  {
    private readonly IAdministratorRepository _administratorRepo;
    private readonly IMapper _mapper;
    public AdministratorController(IAdministratorRepository administratorRepo, IMapper mapper)
    {
        _administratorRepo = administratorRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<AdministratorDto>> GetAdministrators()
    {
      var administrators = await _administratorRepo.GetAdministratorsAsync();

      var data = _mapper.Map<IReadOnlyList<Administrator>, IReadOnlyList<AdministratorDto>>(administrators);

      return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AdministratorDto>> GetAdministrator(int id)
    {
      var administrator = await _administratorRepo.GetAdministratorByIdAsync(id);

      if (administrator == null) return NotFound(new ApiResponse(404));

      return Ok(_mapper.Map<Administrator, AdministratorDto>(administrator));
    }
  }
}