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
        
        // Department is parent of the developer.
        // Since department does not own the relationship. Does not know the relationship it is the "inverse"
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
            //HasMany<Developer>(x => x.Developers)
            //    .KeyColumn("DepartmentId")
            //    .Cascade.All();
            ////.Inverse();
        }
    }
}
