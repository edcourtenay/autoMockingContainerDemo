using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Moq;

namespace AMCDemo.Web.Unit.Tests.DependencyInjection
{
    public class MoqResolver : ISubDependencyResolver
    {
        private readonly IKernel _kernel;

        public MoqResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
            DependencyModel dependency)
        {
            return dependency.TargetType.IsInterface || dependency.TargetType.IsAbstract;
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
            DependencyModel dependency)
        {
            // Create generic Mock type
            var mockType = typeof (Mock<>).MakeGenericType(dependency.TargetType);

            // Resolve mock type
            var mock = ((Mock) _kernel.Resolve(mockType));

            // Return the object
            return mock.Object;
        }
    }
}