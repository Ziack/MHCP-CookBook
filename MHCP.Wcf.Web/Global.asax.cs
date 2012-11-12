using System;
using System.Reflection;
using System.Web;

using Castle.Windsor;

using CommonServiceLocator.WindsorAdapter;

using Microsoft.Practices.ServiceLocation;

using MHCP.Infrastructure.NHibernateMaps;
using MHCP.Wcf.Web.CastleWindsor;

using SharpArch.NHibernate;
using SharpArch.NHibernate.Wcf;

namespace MHCP.Wcf.Web
{
    using System;
    using System.Reflection;
    using System.Web;

    using Castle.Windsor;

    using CommonServiceLocator.WindsorAdapter;

    using Microsoft.Practices.ServiceLocation;

    using MHCP.Infrastructure.NHibernateMaps;
    using MHCP.Wcf.Web.CastleWindsor;

    using SharpArch.NHibernate;
    using SharpArch.NHibernate.Wcf;
    using SharpArch.Domain.Events;

    public class Global : HttpApplication
    {
        private WcfSessionStorage wcfSessionStorage;

        public override void Init()
        {
            base.Init();

            // The WebSessionStorage must be created during the Init() to tie in HttpApplication events
            this.wcfSessionStorage = new WcfSessionStorage();
        }

        /// <summary>
        ///   Due to issues on IIS7, the NHibernate initialization cannot reside in Init() but
        ///   must only be called once.  Consequently, we invoke a thread-safe singleton class to 
        ///   ensure it's only initialized once.
        /// </summary>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            NHibernateInitializer.Instance().InitializeNHibernateOnce(() => this.InitializeNHibernateSession());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Useful for debugging
            var ex = this.Server.GetLastError();
            var reflectionTypeLoadException = ex as ReflectionTypeLoadException;
        }

        protected void Application_Start()
        {
            this.InitializeServiceLocator();
        }

        /// <summary>
        ///   Instantiate the container and add all Controllers that derive from 
        ///   WindsorController to the container.  Also associate the Controller 
        ///   with the WindsorContainer ControllerFactory.
        /// </summary>
        protected virtual void InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();

            ComponentRegistrar.AddComponentsTo(container);

            var windsorServiceLocator = new WindsorServiceLocator(container);
            DomainEvents.ServiceLocator = windsorServiceLocator;
            ServiceLocator.SetLocatorProvider(() => windsorServiceLocator);             
        }

        /// <summary>
        ///   If you need to communicate to multiple databases, you'd add a line to this method to
        ///   initialize the other database as well.
        /// </summary>
        private void InitializeNHibernateSession()
        {
            NHibernateSession.Init(
                this.wcfSessionStorage,
                new[] { Server.MapPath("~/bin/MHCP.Infrastructure.dll") },
                new AutoPersistenceModelGenerator().Generate(),
                this.Server.MapPath("~/NHibernate.config"));
        }
    }
}