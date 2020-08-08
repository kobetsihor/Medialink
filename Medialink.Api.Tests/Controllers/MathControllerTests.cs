using System;
using System.Web.Http.Results;
using Medialink.Api.Controllers;
using Medialink.Api.Filters;
using MediaLink.Lib.Abstractions;
using Moq;
using NUnit.Framework;

namespace Medialink.Api.Tests.Controllers
{
    public class MathControllerTests
    {
        private MathController _mathController;
        private Mock<IMathService> _mathServiceMock;

        [SetUp]
        public void Init()
        {
            _mathServiceMock = new Mock<IMathService>();
            _mathController = new MathController(_mathServiceMock.Object);
        }

        [Test]
        public void AddShouldReturnSuccessResult()
        {
            var a = 2;
            var b = 3;
            var expected = 5;

            _mathServiceMock.Setup(x => x.Add(a, b)).Returns(expected);

            var response = _mathController.Add(a, b) as OkNegotiatedContentResult<double>;

            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response.Content);
            _mathServiceMock.Verify(x => x.Add(a, b), Times.Once);
        }

        [Test]
        public void MultiplyShouldReturnSuccessResult()
        {
            var a = 2;
            var b = 4;
            var expected = 8;

            _mathServiceMock.Setup(x => x.Multiply(a, b)).Returns(expected);

            var response = _mathController.Multiply(a, b) as OkNegotiatedContentResult<double>;

            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response.Content);
            _mathServiceMock.Verify(x => x.Multiply(a, b), Times.Once);
        }

        [Test]
        public void DivideShouldReturnSuccessResult()
        {
            var a = 10;
            var b = 5;
            var expected = 2;

            _mathServiceMock.Setup(x => x.Divide(a, b)).Returns(expected);

            var response = _mathController.Divide(a, b) as OkNegotiatedContentResult<double>;

            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response.Content);
            _mathServiceMock.Verify(x => x.Divide(a, b), Times.Once);
        }

        [Test]
        public void DivideByZeroShouldThrowError()
        {
            var a = 10;
            var b = 0;

            _mathServiceMock.Setup(x => x.Divide(a, b)).Throws<DivideByZeroException>();

            Assert.Throws<DivideByZeroException>(() => _mathController.Divide(a, b));
        }
    }
}