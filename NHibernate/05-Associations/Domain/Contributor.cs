using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrumpiesHandsOnLabs.Domain
{
    public class Contributor
    {
        public virtual int Id { get; set; }
        public virtual string Nickname { get; set; }
        public virtual int Commits { get; set; }
    }
}
