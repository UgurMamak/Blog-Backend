using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.UserDtos
{
    public class UserGetAllDto
    {

        public string Id  { get; set; }
        public string FirstName  { get; set; }
        public string LastName  { get; set; }
        public string Email  { get; set; }
        public string Role { get; set; }


    }
}
