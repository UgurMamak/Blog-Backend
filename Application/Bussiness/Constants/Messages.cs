using Application.Persistence.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Constants
{
    public static class Messages
    {
        //Tüm mesajlar burada tutulacak.
        //her seferinden new'lenmesin diye static tanımladık. bir kere newlenmsi yeterli

        public static string CategoryAdded = "Kategori başarıyla eklendi";
        public static string CategoryDeleted = "Kategori başarıyla silindi";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi";


        public static string PostAdded = "Post başarıyla eklendi";
        public static string PostDeleted = "Post başarıyla silindi";
        public static string PostUpdated = "Post başarıyla güncellendi";

        public static string CommentAdded = "Yorum başarıyla eklendi";
        public static string CommentDeleted = "Yorum başarıyla silindi";
        public static string CommentUpdated = "Yorum başarıyla güncellendi";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin ="Sisteme Giriş Başarılı";

        public static string LikePostAdded = "Post Beğenildi.";
        public static string LikePostDeleted = "Beğeni Silindi.";



        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";


        public static string AuthorizationDenied = "Yetkiniz yok";


    }
}
