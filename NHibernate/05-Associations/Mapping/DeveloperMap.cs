using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class DeveloperMap : ClassMap<Developer>
    {        
        public DeveloperMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.SurName).Length(50).Not.Nullable();
            References<Department>(x => x.Department)
                .Column("DepartmentId") // REMOVE THIS AND TRY AGAIN
                .Cascade.All();
        }
    }
}
