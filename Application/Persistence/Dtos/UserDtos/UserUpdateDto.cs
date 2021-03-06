﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string Id{ get; set; }//güncellemek için user Id bilgisine ihtiyaç var
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Image { get; set; }       
        public string ImageName { get; set; }
        public string password { get; set; }

        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
    }

}
