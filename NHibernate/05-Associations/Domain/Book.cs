using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrumpiesHandsOnLabs.Domain
{
    public class Book
    {

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ISBN { get; set; }
        public virtual double Price { get; set; }
        public virtual Author Author { get; set; }       

    }
}
