﻿using Application.Core.DataAccsess;
using Application.Persistence.Dtos.LikePostDto;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataAccsess.Abstract
{
    public interface ILikePostDal : IEntityRepository<LikePost>
    {
         LikePostNumberStatusDto GetNumberStatus(string postId);
    }
}
