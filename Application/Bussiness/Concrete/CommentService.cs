using Application.Bussiness.Abstract;
using Application.Bussiness.Constants;
using Application.Core.Aspects.Autofac.Transaction;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos.CommentDtos;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IDataResult<List<Comment>> GetList()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetList().ToList());
        }
        public IResult Add(CommentCreateDto commentCreateDto)//+++
        {
            var comment = new Comment
            {
                Content = commentCreateDto.Content,
                UserId = commentCreateDto.UserId,
                PostId = commentCreateDto.PostId,
                //Created = Convert.ToDateTime(commentCreateDto.Created)
                Created = DateTime.Now
            };
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IDataResult<List<CommentListDto>> GetByPostId(string postId)//+++
        {
           // var entity= _commentDal.GetList();           
            /*var result = entity.Select(se=>new CommetListDto { 
              Content=se.Content
            }).ToList();*/
            // return new SuccessDataResult<List<CommetListDto>>(result);
            // return new SuccessDataResult<List<Comment>>(_commentDal.GetList().ToList());
            return new SuccessDataResult<List<CommentListDto>>(_commentDal.GetByPostId(p=>p.PostId==postId).ToList());
        }

        public IResult Delete(Comment comment)//+++
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        [TransactionScopeAspect]//+++
        public IResult Update(CommentUpdateDto comment)
        {          
            _commentDal.Update2(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }

        public IDataResult<Comment> GetById(string commentId)
        {
            throw new NotImplementedException();
        }

        [TransactionScopeAspect]//+++++++
        public IResult DeleteByPostId(string postId)//
        {
            _commentDal.DeleteById(w=>w.PostId==postId);
            return new SuccessResult(Messages.CommentDeleted);
        }


    }
}
