using System.Web.Mvc;
using AMCDemo.Web.Controllers;
using AMCDemo.Web.Interfaces;
using AMCDemo.Web.ViewModels;
using FluentAssertions;
using Ninject;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;

namespace AMCDemo.Web.Unit.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void SutIsController()
        {
            var kernel = new MoqMockingKernel();
            var sut = kernel.Get<HomeController>();
            sut.Should().BeAssignableTo<Controller>();
        }

        [Test]
        public void IndexReturnsViewResult()
        {
            var kernel = new MoqMockingKernel();
            var sut = kernel.Get<HomeController>();
            var result = sut.Index();
            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void IndexReturnsViewResultForIndexView()
        {
            var kernel = new MoqMockingKernel();
            var sut = kernel.Get<HomeController>();
            var result = sut.Index();
            result.ViewName.Should().Be("Index");
        }

        [Test]
        public void IndexReturnsViewResultWithModel()
        {
            var kernel = new MoqMockingKernel();
            var sut = kernel.Get<HomeController>();
            var result = sut.Index();
            result.Model.Should().BeOfType<HomeIndexViewModel>();
        }

        [Test]
        public void IndexCallsGreetingService()
        {
            var kernel = new MoqMockingKernel();
            var sut = kernel.Get<HomeController>();
            sut.Index();

            var service = kernel.GetMock<IGreetingService>();
            service.Verify(svc => svc.GetGreeting());
        }
    }
}
