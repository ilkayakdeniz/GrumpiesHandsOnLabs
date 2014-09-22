using FluentNHibernate.Mapping;
using GrumpiesHandsOnLabs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrumpiesHandsOnLabs.Mapping
{
    public class DepartmentMap: ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
        }
    }
}
