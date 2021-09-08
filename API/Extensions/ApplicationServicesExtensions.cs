using System.Linq;
using API.Authorization;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
  public static class ApplicationServicesExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddScoped<IJwtUtils, JwtUtils>();
      services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
      services.AddTransient(typeof(IAdministratorRepository), typeof(AdministratorRepository));
      services.AddTransient(typeof(ICareerRepository), typeof(CareerRepository));
      services.AddTransient(typeof(IGroupRepository), typeof(GroupRepository));
      services.AddTransient(typeof(IGroupStudentRepository), typeof(GroupStudentRepository));
      services.AddTransient(typeof(IPersonRepository), typeof(PersonRepository));
      services.AddTransient(typeof(IScoreRecordRepository), typeof(ScoreRecordRepository));
      services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
      services.AddTransient(typeof(ISubjectRepository), typeof(SubjectRepository));
      services.AddTransient(typeof(ITeacherRepository), typeof(TeacherRepository));
      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.InvalidModelStateResponseFactory = actionContext =>
              {
                var errors = actionContext.ModelState
                          .Where(e => e.Value.Errors.Count > 0)
                          .SelectMany(x => x.Value.Errors)
                          .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                  Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
              };
      });

      return services;
    }
  }
}