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
            CreateMap<Person, PersonDto>();
            CreateMap<ScoreRecord, ScoreRecordDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<Teacher, TeacherDto>();

            //Dtos to Entities
            CreateMap<AdministratorDto, Administrator>();
            CreateMap<CareerDto, Career>();
            CreateMap<GroupDto, Group>();
            CreateMap<GroupStudentDto, GroupStudent>();
            CreateMap<PersonDto, Person>();
            CreateMap<ScoreRecordDto, ScoreRecord>();
            CreateMap<StudentDto, Student>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<TeacherDto, Teacher>();
        }
    }
}