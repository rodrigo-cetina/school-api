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

        [HttpGet("group/{id}")]
        public async Task<ActionResult<GroupStudentDto>> GetGroupStudents(int id)
        {
            var groupStudents = await _groupStudentRepo.GetGroupStudentsByGroupIdAsync(id);

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

        [HttpPost]
        public async Task<ActionResult<GroupStudentDto>> PostGroup([FromBody] GroupStudent groupStudent)
        {
            var existingStudent = await _groupStudentRepo.ExistsGroupStudentAsync(groupStudent.GroupId, groupStudent.StudentId);

            if (existingStudent) return BadRequest(new ApiResponse(400, "The student is already in the group"));

            groupStudent = await _groupStudentRepo.AddAsync(groupStudent);
            await _groupStudentRepo.SaveChangesAsync();
            groupStudent = await _groupStudentRepo.GetGroupStudentByIdAsync(groupStudent.Id);

            return Ok(_mapper.Map<GroupStudent, GroupStudentDto>(groupStudent));
        }

        [HttpPut]
        public async Task<ActionResult<GroupStudentDto>> PutGroup([FromBody] GroupStudent groupStudent)
        {
            groupStudent = _groupStudentRepo.Update(groupStudent);
            await _groupStudentRepo.SaveChangesAsync();
            groupStudent = await _groupStudentRepo.GetGroupStudentByIdAsync(groupStudent.Id);

            return Ok(_mapper.Map<GroupStudent, GroupStudentDto>(groupStudent));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteGroupStudent(int id)
        {
            await _groupStudentRepo.Delete(id);
            await _groupStudentRepo.SaveChangesAsync();

            return Ok(id);
        }
    }
}