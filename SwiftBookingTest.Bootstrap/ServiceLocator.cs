using Autofac;
using SwiftBookingTest.Repository;
using SwiftBookingTest.Repository.Contracts;
using SwiftBookingTest.Service;
using SwiftBookingTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Bootstrap
{
    public class ServiceLocator
    {
        private IContainer container;

        private ServiceLocator()
        {
        }

        bool initialized = false;
        public IContainer InitializeIOC(ContainerBuilder builder)
        {
            if (initialized) return container;
            initialized = true;

            builder.RegisterType<DeliveryRepository>().As<IDeliveryRepository>();
            builder.RegisterType<DeliveryService>().As<IDeliveryService>();

            return container = builder.Build();
        }

        public IContainer Container
        {
            get
            {
                return container;
            }
        }

        public T Resolve<T>()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                return container.Resolve<T>();
            }
        }

        public T Resolve<T>(string name)
        {
            using (var scope = container.BeginLifetimeScope())
            {
                return container.ResolveNamed<T>(name);
            }
        }

        private static ServiceLocator _Instance = new ServiceLocator();
        public static ServiceLocator Instance
        {
            get
            {
                return _Instance;
            }
        }

        public static T Get<T>()
        {
            return Instance.Resolve<T>();
        }

        public static T Get<T>(string name)
        {
            return Instance.Resolve<T>(name);
        }
    }
}
