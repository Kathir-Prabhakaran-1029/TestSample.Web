using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSample.Domain.Entities
{
    public class Insurer : Entity<Int32>
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string InternalCode { get; set; }
        public string Remarks { get; set; }
    }
}