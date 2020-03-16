using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Persistence.Entity
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
