using System.Web.Mvc;
using AMCDemo.Web.Controllers;
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
    }
}
