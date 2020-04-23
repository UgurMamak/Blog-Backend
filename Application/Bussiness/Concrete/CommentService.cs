using Application.Bussiness.Abstract;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Concrete
{
    public class CommentService : ICommentService
    {

        private ICommentDal _commentDal;
        public CommentService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public IResult Add(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Comment> GetById(string commentId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Comment>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
