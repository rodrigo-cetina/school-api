using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context, IPersonRepository personRepo, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                var person = await personRepo.GetByIdAsync(userId.Value);
                context.Items["User"] = _mapper.Map<Person, PersonDto>(person);
            }

            await _next(context);
        }
    }
}
