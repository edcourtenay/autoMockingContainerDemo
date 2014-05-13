using System.Security.Permissions;
using System.Web.Mvc;
using AMCDemo.Web.Controllers;
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
            var sut = new HomeController();
            sut.Should().BeAssignableTo<Controller>();
        }

        [Test]
        public void IndexReturnsViewResult()
        {
            var sut = new HomeController();
            var result = sut.Index();
            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void IndexReturnsViewResultForIndexView()
        {
            var sut = new HomeController();
            var result = sut.Index();
            result.ViewName.Should().Be("Index");
        }

        [Test]
        public void IndexReturnsViewResultWithModel()
        {
            var sut = new HomeController();
            var result = sut.Index();
            result.Model.Should().BeOfType<HomeIndexViewModel>();
        }
    }
}
