using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Entities to Dtos
            CreateMap<Administrator, AdministratorDto>();
            CreateMap<Career, CareerDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<GroupStudent, GroupStudentDto>();
            CreateMap<GroupStudent, ScoreRecordDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<ScoreRecord, ScoreRecordDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<Teacher, TeacherDto>();

            //Dtos to Entities
            CreateMap<AdministratorDto, Administrator>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Person.Id));
            CreateMap<CareerDto, Career>();
            CreateMap<GroupDto, Group>()
                .ForMember(d => d.CareerId, o => o.MapFrom(s => s.Career.Id))
                .ForMember(d => d.SubjectId, o => o.MapFrom(s => s.Subject.Id))
                .ForMember(d => d.TeacherId, o => o.MapFrom(s => s.Teacher.Person.Id));
            CreateMap<GroupStudentDto, GroupStudent>();
            CreateMap<PersonDto, Person>();
            CreateMap<ScoreRecordDto, ScoreRecord>();
            CreateMap<StudentDto, Student>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Person.Id));
            CreateMap<SubjectDto, Subject>();
            CreateMap<TeacherDto, Teacher>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Person.Id));
        }
    }
}