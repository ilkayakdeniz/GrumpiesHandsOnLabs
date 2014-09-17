using System;
using FluentNHibernate.Automapping;

namespace GrumpiesHandsOnLabs.Mapping
{
    /// <summary>
    /// When Automap is being used system does not know which namespaces to investigate under certain assembly.
    /// This configuration helps FluentNHibernate to seach proper namespaces or else.
    /// This can be modified accordign to needs.
    /// 
    /// Always prefer writing you own mapping files.
    /// </summary>
    public class AutoMappingConfig : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "GrumpiesHandsOnLabs.Domain";
        }
    }
}
