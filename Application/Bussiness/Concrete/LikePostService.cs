using Application.Bussiness.Abstract;
using Application.Bussiness.Constants;
using Application.Core.Utilities.Results;
using Application.DataAccsess.Abstract;
using Application.Persistence.Dtos.LikePostDto;
using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Bussiness.Concrete
{
    class LikePostService : ILikePostService
    {
        private ILikePostDal _likePostDal;
        public LikePostService(ILikePostDal likePostDal)
        {
            _likePostDal = likePostDal;
        }
        //+++
        public IResult Add(LikePostCreateDto likePost)
        {
            var lpost = new LikePost {
                PostId = likePost.PostId,
                UserId=likePost.UserId,
                LikeStatus=likePost.LikeStatus
            };
            _likePostDal.Add(lpost);
            return new SuccessResult(Messages.LikePostAdded);
        }

        //Kullanıcının daha önce like ve ya dislike tutup tutmadığı kontrol edilir.+++
       public string LikePostExists(LikePostCreateDto likePost)
       {
            //sonuc==0 ise yeni gelen datayı ekle
            //sonuc==1 ise güncelleme yap.(eski datayı sil yenisini ekle)
            //sonuc==2 ise hiçbirşey yapma
            var sonuc = "";           
            //postId ve userId göndererek daha önce işlem yapılıp yaplmadığını döndüm.
            var isThere = _likePostDal.Get(w => w.PostId == likePost.PostId && w.UserId == likePost.UserId);
            //kayıt yoksa yeni gelen değeri ekle
            if (isThere==null)
            {
                sonuc = "0";
                return sonuc;
            }
            //postId userId ve likestatu durular gönderilir.
            var likestatu = _likePostDal.Get(w => w.PostId == likePost.PostId && w.UserId == likePost.UserId && w.LikeStatus==likePost.LikeStatus);
            //eğer gelen data db yoksa güncelleme yap
            if(likestatu==null)
            {
                sonuc = "1";
                return sonuc;
            }
            //eğer ikisine de girmezse hiç birişlem yapma diyeceğiz
            sonuc = "2";
            return sonuc;     
       }

        //+++
        public IDataResult<List<LikePost>> GetList()
        {
            return new SuccessDataResult <List<LikePost>>(_likePostDal.GetList().ToList());
        }

        //+++
        public IDataResult<LikePostNumberStatusDto> GetNumberStatus(string postId)
        {
            //_likePostDal.GetNumberStatus(postId);
            //return new SuccessDataResult<List<LikePostNumberStatusDto>>(_likePostDal.GetNumberStatus(postId).ToString());          
            return new SuccessDataResult<LikePostNumberStatusDto>(_likePostDal.GetNumberStatus(postId));        
        }

        //+++
        public IResult Delete(LikePostCreateDto likePost)
        {
            //userId ve postId değerlerine göre girilen kayıt silinir.
           //var entity= _likePostDal.Get(w => w.PostId == likePost.PostId && w.UserId == likePost.UserId && w.LikeStatus == likePost.LikeStatus);                   
            _likePostDal.DeleteById(w => w.PostId == likePost.PostId && w.UserId == likePost.UserId && w.LikeStatus == likePost.LikeStatus);
            return new SuccessResult();
        }    
    }
}
