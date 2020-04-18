using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

//imported
using Application.Core.Entities;

namespace Application.Persistence.Entity
{
    public class AuditableEntity:IEntity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
