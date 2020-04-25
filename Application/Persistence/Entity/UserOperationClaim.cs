using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.Entities;

namespace Application.Persistence.Entity
{
    public class UserOperationClaim : IEntity
    {
        //Hangi kullanıcının hangi role sahip olduğunu tutacak olan tablo
        public int Id { get; set; }
        public string UserId { get; set; }

        public int OperationClaimId { get; set; }

        public User User { get; set; }

        public OperationClaim OperationClaim { get; set; }

    }
}
