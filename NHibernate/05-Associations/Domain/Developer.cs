using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrumpiesHandsOnLabs.Domain
{
    public class Developer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }
        public virtual Department Department { get; set; }
    }
}
