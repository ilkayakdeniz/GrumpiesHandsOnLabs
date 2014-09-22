using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class AmountMap : ComponentMap<Amount>
    {
        public AmountMap()
        {
            Map(x => x.CurrencyCode).Not.Nullable();
            Map(x => x.Volume).Not.Nullable();
        }
    }
}