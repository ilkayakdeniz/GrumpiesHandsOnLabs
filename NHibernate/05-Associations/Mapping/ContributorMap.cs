using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class ContributorMap : ClassMap<Contributor>
    {
        public ContributorMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.Commits).Not.Nullable();
 
        }
    }
}
