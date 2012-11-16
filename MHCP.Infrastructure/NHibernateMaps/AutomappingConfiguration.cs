namespace MHCP.Infrastructure.NHibernateMaps
{
    using System.Linq;
    using FluentNHibernate;
    using FluentNHibernate.Automapping;
    using SharpArch.Domain.DomainModel;

    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.GetInterfaces().Any(x =>
                 x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
        }

        public override bool ShouldMap(Member member)
        {
            return base.ShouldMap(member) && member.CanWrite;
        }

        public override bool AbstractClassIsLayerSupertype(System.Type type)
        {
            return type == typeof(EntityWithTypedId<>) || type == typeof(Entity);
        }

        public override bool IsId(Member member)
        {
            return member.Name == "Id";
        }

        public override bool IsComponent(System.Type type)
        {
            return type.BaseType == typeof(ValueObject);
        }

        public override string GetComponentColumnPrefix(Member member)
        {
            return member.PropertyType.Name + "_";
        }
    }
}
