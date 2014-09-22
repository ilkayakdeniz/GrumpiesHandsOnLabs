using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class SalesTrnxMap : ClassMap<SalesTrnx>
    {
        public SalesTrnxMap()
        {
            Id(x => x.Id);
            Map(x => x.TrnxStatus).Not.Nullable();
            Map(x => x.TrnxTime).Not.Nullable();
            Component(x => x.Amount);
        }
    }
}
