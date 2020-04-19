﻿using Application.Core.DataAccsess.EntityFramework;
using Application.DataAccsess.Abstract;
using Application.Persistence;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataAccsess.Concrete.EntityFramework
{
    public class EfCommentDal:EfEntityRepositoryBase<Comment,BlogDbContext>,ICommentDal
    {

    }
}