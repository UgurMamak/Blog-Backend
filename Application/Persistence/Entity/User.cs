using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Application.Persistence.Entity
{
    public class User : AuditableEntity
    {

        //************* olmayanlar sonradan eklendi.

        public User()
        {
            Id = Guid.NewGuid().ToString();//****************
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordSalt { get; set; }//girilen þifreyi kuvvetlendirmektedir.
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }//*********
        public string ImgName { get; set; }//Resimlerin adýný tutmak için oluþturuldu.
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }

        public List<Post> Posts { get; set; }//**********
        public List<LikePost> LikePosts { get; set; }//*******
    }
}
