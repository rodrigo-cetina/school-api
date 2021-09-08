using BCryptNet = BCrypt.Net.BCrypt;
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
using API.Authorization;
using API.Helpers;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly IPersonRepository _personRepo;
    private readonly IJwtUtils _jwtUtils;
    private readonly AppSettings _appSettings;
    private readonly IMapper _mapper;
    public AccountController(IPersonRepository personRepo, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings, IMapper mapper)
    {
        _personRepo = personRepo;
        _jwtUtils = jwtUtils;
        _appSettings = appSettings.Value;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AuthenticateResponseDto>> Authenticate(AuthenticateRequestDto model)
    {
        var person = await _personRepo.GetPersonByEmailAsync(model.Email);

        // validate
        var passwordHash = BCryptNet.HashPassword("1234");
        if (person == null || !BCryptNet.Verify(model.Password, passwordHash))
            return BadRequest(new ApiResponse(400, "Email or password is incorrect"));

        var personDto = _mapper.Map<Person, PersonDto>(person);

        // authentication successful so generate jwt token
        var jwtToken = _jwtUtils.GenerateJwtToken(personDto);

        return Ok(new AuthenticateResponseDto(personDto, jwtToken));
    }
  }
}