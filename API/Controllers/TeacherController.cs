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
  public class TeacherController : BaseApiController
  {
    private readonly ITeacherRepository _teacherRepo;
    private readonly IMapper _mapper;
    public TeacherController(ITeacherRepository teacherRepo, IMapper mapper)
    {
        _teacherRepo = teacherRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<TeacherDto>> GetTeachers()
    {
      var teachers = await _teacherRepo.GetTeachersAsync();

      var data = _mapper.Map<IReadOnlyList<Teacher>, IReadOnlyList<TeacherDto>>(teachers);

      return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TeacherDto>> GetTeacher(int id)
    {
      var teacher = await _teacherRepo.GetTeacherByIdAsync(id);

      if (teacher == null) return NotFound(new ApiResponse(404));

      return Ok(_mapper.Map<Teacher, TeacherDto>(teacher));
    }
  }
}