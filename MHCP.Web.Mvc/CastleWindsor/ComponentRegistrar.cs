namespace MHCP.Web.Mvc.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using SharpArch.Domain.Commands;
    using SharpArch.Domain.Events;
    using SharpArch.Domain.PersistenceSupport;
    using SharpArch.NHibernate;
    using SharpArch.NHibernate.Contracts.Repositories;
    using SharpArch.Web.Mvc.Castle;
    using Castle.Facilities.FactorySupport;
    using Castle.DynamicProxy;
    using Castle.Core;
    using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
    using MHCP.Web.Mvc.Services;
    using MHCP.Services.Wcf.Client.APR;

    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container) 
        {
            //AddGenericRepositoriesTo(container);
            //AddCustomRepositoriesTo(container);
            AddQueryObjectsTo(container);
            //AddTasksTo(container);
            AddHandlersTo(container);

            AddWcfServiceFactoriesTo(container);
        }

        private static void AddTasksTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                    .FromAssemblyNamed("MHCP.Tasks")
                    .Pick()
                    .WithService.FirstNonGenericCoreInterface("MHCP.Domain"));
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container) 
        {
            container.Register(
                AllTypes
                    .FromAssemblyNamed("MHCP.Infrastructure.Data")
                    .BasedOn(typeof(IRepositoryWithTypedId<,>))
                    .WithService.FirstNonGenericCoreInterface("MHCP.Domain"));
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

        private static void AddQueryObjectsTo(IWindsorContainer container) 
        {
            container.Register(
                AllTypes.FromAssemblyNamed("MHCP.Web.Mvc")
                    .BasedOn<NHibernateQuery>()
                    .WithService.DefaultInterfaces());

            container.Register(
                AllTypes.FromAssemblyNamed("MHCP.Infrastructure.Data")
                    .BasedOn(typeof(NHibernateQuery))
                    .WithService.DefaultInterfaces());
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

        private static void AddWcfServiceFactoriesTo(IWindsorContainer container)
        {
            container.AddFacility<FactorySupportFacility>();
            container.Register(Component.For<StandardInterceptor>()
                .Named("standard.interceptor"));

            container.Register(Component.For<APRWcfServiceFactory>().Named("APRWcfServiceFactory"));
            
            container.Kernel.Register(
                Component.For<IAPRWcfService>()
                .UsingFactory((APRWcfServiceFactory f) => f.Create())                
                .ImplementedBy<APRWcfServiceClient>()
                .Named("APRWcfServices")
                .LifeStyle.Is(LifestyleType.PerWebRequest));


        }

    }
}