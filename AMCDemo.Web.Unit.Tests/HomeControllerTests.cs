using System.Web.Mvc;
using AMCDemo.Web.Controllers;
using AMCDemo.Web.Unit.Tests.DependencyInjection;
using AMCDemo.Web.ViewModels;
using FluentAssertions;
using NUnit.Framework;

namespace AMCDemo.Web.Unit.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void SutIsController()
        {
            var container = UnitTestInstaller.CreateContainer();
            var sut = container.Resolve<HomeController>();
            sut.Should().BeAssignableTo<Controller>();
        }

        [Test]
        public void IndexReturnsViewResult()
        {
            var container = UnitTestInstaller.CreateContainer();
            var sut = container.Resolve<HomeController>();
            var result = sut.Index();
            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void IndexReturnsViewResultForIndexView()
        {
            var container = UnitTestInstaller.CreateContainer();
            var sut = container.Resolve<HomeController>();
            var result = sut.Index();
            result.ViewName.Should().Be("Index");
        }

        [Test]
        public void IndexReturnsViewResultWithModel()
        {
            var container = UnitTestInstaller.CreateContainer();
            var sut = container.Resolve<HomeController>();
            var result = sut.Index();
            result.Model.Should().BeOfType<HomeIndexViewModel>();
        }
    }
}
