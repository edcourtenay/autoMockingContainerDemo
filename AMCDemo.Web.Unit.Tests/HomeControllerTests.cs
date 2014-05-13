using System.Web.Mvc;
using AMCDemo.Web.Controllers;
using AMCDemo.Web.Interfaces;
using AMCDemo.Web.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AMCDemo.Web.Unit.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void SutIsController()
        {
            var greetingService = Mock.Of<IGreetingService>();
            var dateService = Mock.Of<IDateService>();
            var sut = new HomeController(greetingService, dateService);
            sut.Should().BeAssignableTo<Controller>();
        }

        [Test]
        public void IndexReturnsViewResult()
        {
            var greetingService = Mock.Of<IGreetingService>();
            var dateService = Mock.Of<IDateService>();
            var sut = new HomeController(greetingService, dateService);
            var result = sut.Index();
            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public void IndexReturnsViewResultForIndexView()
        {
            var greetingService = Mock.Of<IGreetingService>();
            var dateService = Mock.Of<IDateService>();
            var sut = new HomeController(greetingService, dateService);
            var result = sut.Index();
            result.ViewName.Should().Be("Index");
        }

        [Test]
        public void IndexReturnsViewResultWithModel()
        {
            var greetingService = Mock.Of<IGreetingService>();
            var dateService = Mock.Of<IDateService>();
            var sut = new HomeController(greetingService, dateService);
            var result = sut.Index();
            result.Model.Should().BeOfType<HomeIndexViewModel>();
        }
    }


}
