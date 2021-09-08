using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AuthenticateResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponseDto(PersonDto person, string token)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            PictureUrl = person.PictureUrl;
            Role = person.Role;
            Email = person.Email;
            Token = token;
        }
    }
}
