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
  public class GroupStudentController : BaseApiController
  {
    private readonly IGroupStudentRepository _groupStudentRepo;
    private readonly IMapper _mapper;
    public GroupStudentController(IGroupStudentRepository groupStudentRepo, IMapper mapper)
    {
        _groupStudentRepo = groupStudentRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GroupStudentDto>> GetGroupStudents()
    {
      var groupStudents = await _groupStudentRepo.GetGroupStudentsAsync();

      var data = _mapper.Map<IReadOnlyList<GroupStudent>, IReadOnlyList<GroupStudentDto>>(groupStudents);

      return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GroupStudentDto>> GetGroupStudent(int id)
    {
      var groupStudent = await _groupStudentRepo.GetGroupStudentByIdAsync(id);

      if (groupStudent == null) return NotFound(new ApiResponse(404));

      return Ok(_mapper.Map<GroupStudent, GroupStudentDto>(groupStudent));
    }
  }
}