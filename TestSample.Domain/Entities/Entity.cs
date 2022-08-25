using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSample.Domain.Entities
{
    public class Entity<TIdentity>
    {
        public TIdentity Id { get; set; }

        public TIdentity CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public TIdentity ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public long TotalCount { get; set; }
        public Int64 RowNum { get; set; }
        public string SystemIp { get; set; }
    }
}