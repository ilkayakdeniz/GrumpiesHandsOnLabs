using System.Security.Cryptography.X509Certificates;
using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class BookMap : ClassMap<Book>
    {

        public BookMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable().Length(250);
            Map(x => x.Price).Not.Nullable();
            Map(x => x.ISBN).Not.Nullable().Length(50);

            #region S08 S09 S091 S092 S093
            References<Author>(x => x.Author)
                .Column("AuthorId")
                .Cascade.All();
            #endregion

        }
    }
}
