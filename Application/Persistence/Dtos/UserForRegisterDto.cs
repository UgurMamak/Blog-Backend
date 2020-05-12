using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }//Db'de password diye bir alan yok ama kullanıcı password olarak bunu girecek. Dto bu işe yarar.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }//***********
    }
}
