using System;

namespace GrumpiesHandsOnLabs.Domain
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }
        public virtual string EMail { get; set; }
        public virtual DateTime BirthDate { get; set; }
    }
}
