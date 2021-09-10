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
    public class PersonController : BaseApiController
    {
        private readonly IPersonRepository _personRepo;
        private readonly IMapper _mapper;
        public PersonController(IPersonRepository personRepo, IMapper mapper)
        {
            _personRepo = personRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonDto>> GetPersons()
        {
          var persons = await _personRepo.GetPersonsAsync();

          var data = _mapper.Map<IReadOnlyList<Person>, IReadOnlyList<PersonDto>>(persons);

          return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonDto>> GetPerson(int id)
        {
          var person = await _personRepo.GetPersonByIdAsync(id);

          if (person == null) return NotFound(new ApiResponse(404));

          return Ok(_mapper.Map<Person, PersonDto>(person));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeletePerson(int id)
        {
            await _personRepo.Delete(id);
            await _personRepo.SaveChangesAsync();

            return Ok(id);
        }
    }
}