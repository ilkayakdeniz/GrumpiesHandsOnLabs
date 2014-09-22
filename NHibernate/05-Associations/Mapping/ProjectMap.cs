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
            HasMany<Contributor>(x => x.Contributors)
                .Cascade.All()
                .Not.Inverse()
                .Not.KeyNullable()
                .KeyColumn("ProjectId");// REMOVE THIS AND TRY AGAIN

            #region FURTHER TRIAL

            //USE this block

            //HasMany<Contributor>(x => x.Contributors)
            //    .Cascade.All()
            //    .Not.Inverse()
            //    .Not.KeyNullable()
            //    .KeyColumn("ProjectId");// REMOVE THIS AND TRY AGAIN

            #endregion 
        }
    }
}
