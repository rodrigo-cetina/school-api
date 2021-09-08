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
  public class SubjectController : BaseApiController
  {
    private readonly ISubjectRepository _subjectRepo;
    private readonly IMapper _mapper;
    public SubjectController(ISubjectRepository subjectRepo, IMapper mapper)
    {
        _subjectRepo = subjectRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<SubjectDto>> GetSubjects()
    {
      var subjects = await _subjectRepo.GetSubjectsAsync();

      var data = _mapper.Map<IReadOnlyList<Subject>, IReadOnlyList<SubjectDto>>(subjects);

      return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubjectDto>> GetSubject(int id)
    {
      var subject = await _subjectRepo.GetSubjectByIdAsync(id);

      if (subject == null) return NotFound(new ApiResponse(404));

      return Ok(_mapper.Map<Subject, SubjectDto>(subject));
    }
  }
}