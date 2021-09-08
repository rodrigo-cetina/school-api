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
  public class GroupController : BaseApiController
  {
    private readonly IGroupRepository _groupRepo;
    private readonly IMapper _mapper;
    public GroupController(IGroupRepository groupRepo, IMapper mapper)
    {
        _groupRepo = groupRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GroupDto>> GetGroups()
    {
      var groups = await _groupRepo.GetGroupsAsync();

      var data = _mapper.Map<IReadOnlyList<Group>, IReadOnlyList<GroupDto>>(groups);

      return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GroupDto>> GetGroup(int id)
    {
      var group = await _groupRepo.GetGroupByIdAsync(id);

      if (group == null) return NotFound(new ApiResponse(404));

      return Ok(_mapper.Map<Group, GroupDto>(group));
    }
  }
}