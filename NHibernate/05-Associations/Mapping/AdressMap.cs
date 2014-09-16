using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class AdressMap : ClassMap<Adress>
    {
        public AdressMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.Street).Length(50).Not.Nullable();
            Map(x => x.PostCode).Length(50).Not.Update();            
        }
    }
}
