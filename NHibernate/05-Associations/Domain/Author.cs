using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrumpiesHandsOnLabs.Domain
{
    public class Author
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age{ get; set; }
        public virtual IList<Book> Books { get; set; }
    }
}
