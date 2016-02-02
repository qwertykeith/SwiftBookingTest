using System.Configuration;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ConfigInjector.Configuration;
using Refit;
using SwiftBookingTest.Web.Configuration;
using SwiftBookingTest.Web.Controllers.Features;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web
{
    public class SwiftBookingTestWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationConfigurator
                .RegisterConfigurationSettings()
                .FromAssemblies(typeof (MvcApplication).Assembly)
                .RegisterWithContainer(x => builder.RegisterInstance(x).AsSelf().SingleInstance())
                .AllowConfigurationEntriesThatDoNotHaveSettingsClasses(true)
                .DoYourThing();
            builder
                .RegisterType<BookingContext>()
                .As<IBookingContext>()
                .InstancePerApiRequest()
                .InstancePerHttpRequest();
            builder
                .Register(ctx => RestService.For<ISwiftApi>(ctx.Resolve<SwiftApiUrlSetting>()))
                .As<ISwiftApi>()
                .InstancePerDependency();
        }
    }
}