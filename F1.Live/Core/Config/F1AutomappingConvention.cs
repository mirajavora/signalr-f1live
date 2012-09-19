using System;
using F1.Live.Core.Extensions;
using FluentNHibernate.Automapping;
using FluentNHibernate.Data;

namespace F1.Live.Core.Config
{
    public class F1AutomappingConvention : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return (type.CanBeCastTo<Entity>() && base.ShouldMap(type));
        }

        public override bool IsComponent(Type type)
        {
            return type.Namespace.EndsWith("Components");
        }

        public override bool ShouldMap(FluentNHibernate.Member member)
        {
            return !member.Name.StartsWith("Grouped") && base.ShouldMap(member);
        }
    }
}