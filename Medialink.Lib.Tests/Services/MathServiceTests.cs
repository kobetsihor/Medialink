using System.Globalization;
using Medialink.Dal.Abstractions;
using Medialink.Dal.Models;
using MediaLink.Lib.Abstractions;
using MediaLink.Lib.Services;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace Medialink.Lib.Tests.Services
{
    public class MathServiceTests
    {
        private IMathService _mathService;
        private Mock<IOperationRepository> _operationRepositoryMock;
        private Mock<IRestClient> _restClientMock;

        [SetUp]
        public void Init()
        {
            _operationRepositoryMock = new Mock<IOperationRepository>();
            _restClientMock = new Mock<IRestClient>();
            _mathService = new MathService(_restClientMock.Object, _operationRepositoryMock.Object);
        }

        [Test]
        public void AddShouldReturnCorrectResult()
        {
            var a = 3;
            var b = 4;
            double expected = 7;
            var response = new RestResponse { Content = expected.ToString(CultureInfo.InvariantCulture) };
            _restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>(), Method.GET)).Returns(response);

            var result = _mathService.Add(a, b);

            Verify(expected, result);
        }

        [Test]
        public void MultiplyShouldReturnCorrectResult()
        {
            var a = 5;
            var b = 6;
            double expected = 30;
            var response = new RestResponse { Content = expected.ToString(CultureInfo.InvariantCulture) };
            _restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>(), Method.GET)).Returns(response);

            var result = _mathService.Multiply(a, b);

            Verify(expected, result);
        }

        [Test]
        public void DivideShouldReturnCorrectResult()
        {
            var a = 8;
            var b = 2;
            double expected = 4;
            var response = new RestResponse { Content = expected.ToString(CultureInfo.InvariantCulture) };
            _restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>(), Method.GET)).Returns(response);

            var result = _mathService.Divide(a, b);

            Verify(expected, result);
        }

        private void Verify(double expected, double actual)
        {
            Assert.AreEqual(expected, actual);
            _operationRepositoryMock.Verify(x => x.Create(It.IsAny<Operation>()), Times.Once);
            _restClientMock.Verify(x => x.Execute(It.IsAny<IRestRequest>(), Method.GET), Times.Once);
        }
    }
}