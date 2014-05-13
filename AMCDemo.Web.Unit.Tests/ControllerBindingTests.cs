using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using AMCDemo.Web.App_Start;
using FluentAssertions;
using FluentAssertions.Types;
using Ninject;
using NUnit.Framework;

namespace AMCDemo.Web.Unit.Tests
{
    [TestFixture]
    public class ControllerBindingTests
    {
        private IKernel _kernel;

        public IEnumerable<Type> Controllers()
        {
            return AllTypes.From(typeof(MvcApplication).Assembly)
                .ThatImplement<Controller>();
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _kernel = new StandardKernel();
            _kernel.Load<ApplicationModule>();
        }

        [TestCaseSource("Controllers")]
        public void ControllersShouldBeBindable(Type controllerType)
        {
            Action action = () => _kernel.Get(controllerType);
            action.ShouldNotThrow<ActivationException>();
        }
    }
}
