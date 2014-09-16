using System;

namespace GrumpiesHandsOnLabs.Domain
{
    public class Adress
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Street { get; set; }
        public virtual string PostCode { get; set; }        
    }
}
