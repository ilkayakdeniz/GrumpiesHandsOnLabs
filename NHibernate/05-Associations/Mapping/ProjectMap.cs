using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.StartDate).Not.Nullable();
            Map(x => x.EndDate).Not.Nullable();


            #region S06 - S061[See error]

            HasMany<Contributor>(x => x.Contributors)
                .Cascade.All()
                .KeyColumn("ProjectId");// REMOVE THIS AND TRY AGAIN

            #endregion 


            #region S061 - FURTHER TRIAL

            //Before using this try with S06 mapping
            //USE this block for S061

            //HasMany<Contributor>(x => x.Contributors)
            //    .Cascade.All()
            //    .Not.Inverse()
            //    .Not.KeyNullable()
            //    .KeyColumn("ProjectId");// REMOVE THIS AND TRY AGAIN

            #endregion 
        }
    }
}
