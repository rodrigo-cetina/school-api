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
    public class ScoreRecordController : BaseApiController
    {
        private readonly IScoreRecordRepository _scoreRecordRepo;
        private readonly IGroupStudentRepository _groupStudentRepo;
        private readonly IMapper _mapper;
        public ScoreRecordController(IScoreRecordRepository scoreRecordRepo, IGroupStudentRepository groupStudentRepo, IMapper mapper)
        {
            _scoreRecordRepo = scoreRecordRepo;
            _groupStudentRepo = groupStudentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ScoreRecordDto>> GetScoreRecords()
        {
          var scoreRecords = await _scoreRecordRepo.GetScoreRecordsAsync();

          var data = _mapper.Map<IReadOnlyList<ScoreRecord>, IReadOnlyList<ScoreRecordDto>>(scoreRecords);

          return Ok(data);
        }

        [HttpGet("student/{id}")]
        public async Task<ActionResult<ScoreRecordDto>> GetScoreRecordsByStudentId(int id)
        {
            var groupStudents = await _groupStudentRepo.GetGroupStudentsByStudentIdAsync(id);
            var data = _mapper.Map<IReadOnlyList<GroupStudent>, IReadOnlyList<ScoreRecordDto>>(groupStudents).ToList();

            var scoreRecords = await _scoreRecordRepo.GetScoreRecordsByStudentIdAsync(id);

            data.ForEach(x =>
            {
                var score = scoreRecords.FirstOrDefault(sr => sr.StudentId == x.Student.Person.Id && sr.GroupId == x.Group.Id)?.Score ?? null;

                if (score.HasValue) x.Score = score.Value;
            });
            
            return Ok(data);
        }

        [HttpGet("group/{id}")]
        public async Task<ActionResult<ScoreRecordDto>> GetScoreRecordsByGroupId(int id)
        {
            var groupStudents = await _groupStudentRepo.GetGroupStudentsByGroupIdAsync(id);
            var data = _mapper.Map<IReadOnlyList<GroupStudent>, IReadOnlyList<ScoreRecordDto>>(groupStudents).ToList();

            var scoreRecords = await _scoreRecordRepo.GetScoreRecordsByGroupIdAsync(id);

            data.ForEach(x =>
            {
                var score = scoreRecords.FirstOrDefault(sr => sr.StudentId == x.Student.Person.Id && sr.GroupId == x.Group.Id)?.Score ?? null;

                if (score.HasValue) x.Score = score.Value;
            });

            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScoreRecordDto>> GetScoreRecord(int id)
        {
          var scoreRecord = await _scoreRecordRepo.GetScoreRecordByIdAsync(id);

          if (scoreRecord == null) return NotFound(new ApiResponse(404));

          return Ok(_mapper.Map<ScoreRecord, ScoreRecordDto>(scoreRecord));
        }

        [HttpPost]
        public async Task<ActionResult<ScoreRecordDto>> PostScoreRecord([FromBody] ScoreRecord scoreRecord)
        {
            scoreRecord = await _scoreRecordRepo.AddAsync(scoreRecord);
            await _scoreRecordRepo.SaveChangesAsync();
            scoreRecord = await _scoreRecordRepo.GetScoreRecordByIdAsync(scoreRecord.Id);

            return Ok(_mapper.Map<ScoreRecord, ScoreRecordDto>(scoreRecord));
        }

        [HttpPost("register")]
        public async Task<ActionResult<ScoreRecordDto>> PostScoreRecordRegister([FromBody] ScoreRecord[] scoreRecords)
        {
            foreach (var scoreRecord in scoreRecords)
            {
                var existingItem = await _scoreRecordRepo.GetScoreRecordAsync(scoreRecord.GroupId, scoreRecord.StudentId);
                if (existingItem != null)
                {
                    _scoreRecordRepo.Update(existingItem);
                }
                else
                {
                    await _scoreRecordRepo.AddAsync(scoreRecord);
                }
            }
            await _scoreRecordRepo.SaveChangesAsync();
            
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<ScoreRecordDto>> PutScoreRecord([FromBody] ScoreRecord scoreRecord)
        {
            scoreRecord = _scoreRecordRepo.Update(scoreRecord);
            await _scoreRecordRepo.SaveChangesAsync();
            scoreRecord = await _scoreRecordRepo.GetScoreRecordByIdAsync(scoreRecord.Id);

            return Ok(_mapper.Map<ScoreRecord, ScoreRecordDto>(scoreRecord));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteScoreRecord(int id)
        {
            await _scoreRecordRepo.Delete(id);
            await _scoreRecordRepo.SaveChangesAsync();

            return Ok(id);
        }
    }
}