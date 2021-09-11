using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Common
{
    public class BaseEntity
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }
        public bool Active { get; set; }
    }
}
