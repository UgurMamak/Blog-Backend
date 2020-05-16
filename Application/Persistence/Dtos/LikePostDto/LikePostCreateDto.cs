using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.LikePostDto
{
    public class LikePostCreateDto
    {
        public string PostId { get; set; }
        public string UserId { get; set; }//postu beğeenen kullanıcı
        public bool LikeStatus { get; set; }
    }
}
