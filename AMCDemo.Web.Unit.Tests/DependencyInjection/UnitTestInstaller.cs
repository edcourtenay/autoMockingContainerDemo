using System.Web.SessionState;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Moq;

namespace AMCDemo.Web.Unit.Tests.DependencyInjection
{
    public class UnitTestInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new MoqResolver(container.Kernel));

            container.Register(Classes
                .FromAssemblyContaining<MvcApplication>()
                .Pick()
                .WithServiceSelf()
                .LifestyleTransient());

            container.Register(Component
                .For(typeof(Mock<>))
                .LifestyleSingleton());
        }

        public static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer().Install(new UnitTestInstaller());
        }
    }
}