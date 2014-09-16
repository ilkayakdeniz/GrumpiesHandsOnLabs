using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.SurName).Length(50).Not.Nullable();
            Map(x => x.EMail).Length(100).Nullable();
            Map(x => x.BirthDate).Not.Nullable();
        }
    }
}
