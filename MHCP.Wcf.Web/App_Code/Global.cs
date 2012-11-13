using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using MHCP.Wcf.Web.CastleWindsor;
using CommonServiceLocator.WindsorAdapter;
using SharpArch.Domain.Events;
using Microsoft.Practices.ServiceLocation;
using SharpArch.NHibernate;
using SharpArch.NHibernate.Wcf;
using MHCP.Infrastructure.NHibernateMaps;
using System.Web.Hosting;

namespace MHCP.Wcf.Web
{
    public class Global
    {
        private static WcfSessionStorage wcfSessionStorage;

        public static void AppInitialize()
        {
            wcfSessionStorage = new WcfSessionStorage();

            InitializeServiceLocator();
            InitializeNHibernateSession();
        }

        protected static void InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();

            ComponentRegistrar.AddComponentsTo(container);

            var windsorServiceLocator = new WindsorServiceLocator(container);
            DomainEvents.ServiceLocator = windsorServiceLocator;
            ServiceLocator.SetLocatorProvider(() => windsorServiceLocator);
        }

        protected static void InitializeNHibernateSession()
        {
            NHibernateSession.Init(
                wcfSessionStorage,
                new[] { HostingEnvironment.MapPath("~/bin/MHCP.Infrastructure.dll") },
                new AutoPersistenceModelGenerator().Generate(),
                HostingEnvironment.MapPath("~/NHibernate.config"));
        }

    }
}