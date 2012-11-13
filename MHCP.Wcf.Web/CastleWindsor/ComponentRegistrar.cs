namespace MHCP.Wcf.Web.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using MHCP.Services.Wcf.BoundedContexts.APR;

    using SharpArch.Domain.PersistenceSupport;
    using SharpArch.NHibernate;
    using SharpArch.NHibernate.Contracts.Repositories;
    using SharpArch.Domain.Commands;
    using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
    using Castle.Facilities.WcfIntegration;
    using Castle.Facilities.NHibernate;
    using NHibernate;
    using SharpArch.Domain.Events;
    
    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            AddQueryObjectsTo(container);
            AddTasksTo(container);
            AddHandlersTo(container);
            AddWcfServicesTo(container);
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                    .FromAssemblyNamed("MHCP.Infrastructure.Data")
                    .BasedOn(typeof(IRepositoryWithTypedId<,>))
                    .WithService.DefaultInterfaces());
        }

        private static void AddQueryObjectsTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromAssemblyNamed("MHCP.Infrastructure.Data")
                    .BasedOn(typeof(NHibernateQuery))
                    .WithService.DefaultInterfaces());
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(IEntityDuplicateChecker))
                    .ImplementedBy(typeof(EntityDuplicateChecker))
                    .Named("entityDuplicateChecker"));

            container.Register(
                Component.For(typeof(INHibernateRepository<>))
                    .ImplementedBy(typeof(NHibernateRepository<>))
                    .Named("nhibernateRepositoryType")
                    .Forward(typeof(IRepository<>)));

            container.Register(
                Component.For(typeof(INHibernateRepositoryWithTypedId<,>))
                    .ImplementedBy(typeof(NHibernateRepositoryWithTypedId<,>))
                    .Named("nhibernateRepositoryWithTypedId")
                    .Forward(typeof(IRepositoryWithTypedId<,>)));

            container.Register(
                    Component.For(typeof(ISessionFactoryKeyProvider))
                        .ImplementedBy(typeof(DefaultSessionFactoryKeyProvider))
                        .Named("sessionFactoryKeyProvider"));

            container.Register(
                    Component.For(typeof(ICommandProcessor))
                        .ImplementedBy(typeof(CommandProcessor))
                        .Named("commandProcessor"));
        }

        private static void AddTasksTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                    .FromAssemblyNamed("MHCP.Tasks")
                    .Pick()
                    .WithService.AllInterfaces());
        }

        private static void AddHandlersTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromAssemblyNamed("MHCP.Tasks")
                    .BasedOn(typeof(ICommandHandler<>))
                    .WithService.FirstInterface());

            container.Register(
                AllTypes.FromAssemblyNamed("MHCP.Tasks")
                    .BasedOn(typeof(IHandles<>))
                    .WithService.FirstInterface());
        }

        private static void AddWcfServicesTo(IWindsorContainer container)
        {
            container.AddFacility<WcfFacility>();
                        
            container.Register(
                Component.For<APRWcfService>()
                .ImplementedBy<APRWcfService>()
                .LifestylePerWcfOperation()
                .Named("APRWcfService"));
        }

        private static void AddNHibernateFacilityTo(IWindsorContainer container)
        {
            //Integrating a Single Session Per Request
            container.AddFacility<NHibernateFacility>();
            container.Register(Component.For<ISession>().LifeStyle.PerWcfOperation()
                .UsingFactoryMethod(x => container.Resolve<ISessionManager>().OpenSession()));
        }
    }
}