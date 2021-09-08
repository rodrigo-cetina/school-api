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
    private readonly IMapper _mapper;
    public ScoreRecordController(IScoreRecordRepository scoreRecordRepo, IMapper mapper)
    {
        _scoreRecordRepo = scoreRecordRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ScoreRecordDto>> GetScoreRecords()
    {
      var scoreRecords = await _scoreRecordRepo.GetScoreRecordsAsync();

      var data = _mapper.Map<IReadOnlyList<ScoreRecord>, IReadOnlyList<ScoreRecordDto>>(scoreRecords);

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
  }
}