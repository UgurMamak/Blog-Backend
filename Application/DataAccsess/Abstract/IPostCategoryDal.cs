﻿using Application.Core.DataAccsess;
using Application.Persistence.Dtos;
using Application.Persistence.Dtos.PostCategoryDtos;
using Application.Persistence.Dtos.PostDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.DataAccsess.Abstract
{
    public interface IPostCategoryDal : IEntityRepository<PostCategory>
    {
        IList<PostCardListDto> GetAll(Expression<Func<PostCardListDto, bool>> filter = null);
        IList<PostCardList2Dto> GetAll2(Expression < Func<PostCardList2Dto , bool>> filter = null);
        void Update2(PostCategory postCategory);

        IList<PostCardList2Dto> GetByCategoryId(string categoryId);
        void MultipleAdd(PostCategoryCreateDto postCategoryCreateDto);
    }
}
