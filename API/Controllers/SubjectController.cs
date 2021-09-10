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

        [HttpPost]
        public async Task<ActionResult<SubjectDto>> PostSubject([FromBody] SubjectDto subject)
        {
            var data = _mapper.Map<SubjectDto, Subject>(subject);
            data = await _subjectRepo.AddAsync(data);
            await _subjectRepo.SaveChangesAsync();

            return Ok(_mapper.Map<Subject, SubjectDto>(data));
        }

        [HttpPut]
        public async Task<ActionResult<SubjectDto>> PutSubject([FromBody] SubjectDto subject)
        {
            var data = _mapper.Map<SubjectDto, Subject>(subject);
            data = _subjectRepo.Update(data);
            await _subjectRepo.SaveChangesAsync();

            return Ok(_mapper.Map<Subject, SubjectDto>(data));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteSubject(int id)
        {
            await _subjectRepo.Delete(id);
            await _subjectRepo.SaveChangesAsync();

            return Ok(id);
        }
    }
}