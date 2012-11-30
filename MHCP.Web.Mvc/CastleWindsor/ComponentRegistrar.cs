namespace MHCP.Web.Mvc.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

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
            AddWcfServiceFactoriesTo(container);
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