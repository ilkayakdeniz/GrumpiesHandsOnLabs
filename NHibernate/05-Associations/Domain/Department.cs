using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrumpiesHandsOnLabs.Domain
{
    public class Department
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //public virtual IList<Developer> Developers { get; set; }
    }
}
