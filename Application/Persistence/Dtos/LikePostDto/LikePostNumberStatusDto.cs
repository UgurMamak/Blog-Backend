using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.Dtos.LikePostDto
{
    public class LikePostNumberStatusDto
    {
        public LikePostNumberStatusDto() { }
        public int TrueNumber { get; set; }
        public int FalseNumber { get; set; }
        public string  Message { get; set; }//hangi işlem yapıldığını dönecek.
    }
}
