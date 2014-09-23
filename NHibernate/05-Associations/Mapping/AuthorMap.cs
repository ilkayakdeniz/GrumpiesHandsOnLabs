using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable().Length(50);
            Map(x => x.Age).Not.Nullable();

            #region S08
            //HasMany<Book>(x => x.Books)
            //    .KeyColumn("AuthorId")
            //    .Cascade.All();
            #endregion

            #region S09
            HasMany<Book>(x => x.Books)
                .KeyColumn("AuthorId")
                .Cascade.All();
            #endregion

            #region S091
            //HasMany<Book>(x => x.Books)
            //    .KeyColumn("AuthorId")
            //    .Cascade.All();
            #endregion

            #region S092

            //HasMany<Book>(x => x.Books)
            //    .KeyColumn("AuthorId")
            //    .Cascade.All()
            //    .Inverse();

            #endregion


            #region S093

            //HasMany<Book>(x => x.Books)
            //    .KeyColumn("AuthorId")
            //    .Cascade.All()
            //    .Not.KeyNullable()
            //    .Not.Inverse();

            #endregion
        }
    }
}
