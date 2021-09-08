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
  public class StudentController : BaseApiController
  {
    private readonly IStudentRepository _studentRepo;
    private readonly IMapper _mapper;
    public StudentController(IStudentRepository studentRepo, IMapper mapper)
    {
        _studentRepo = studentRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<StudentDto>> GetStudents()
    {
      var students = await _studentRepo.GetStudentsAsync();

      var data = _mapper.Map<IReadOnlyList<Student>, IReadOnlyList<StudentDto>>(students);

      return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentDto>> GetStudent(int id)
    {
      var student = await _studentRepo.GetStudentByIdAsync(id);

      if (student == null) return NotFound(new ApiResponse(404));

      return Ok(_mapper.Map<Student, StudentDto>(student));
    }
  }
}