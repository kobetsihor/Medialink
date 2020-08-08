using System.Web.Http;
using Medialink.Api.Filters;
using MediaLink.Lib.Abstractions;

namespace Medialink.Api.Controllers
{
    [RoutePrefix("api/math")]
    public class MathController : ApiController
    {
        private readonly IMathService _mathService;
        public MathController(IMathService mathService)
        {
            _mathService = mathService;
        }

        [Route("add")]
        [HttpGet]
        public IHttpActionResult Add(int a, int b)
        {
            var result = _mathService.Add(a, b);
            return Ok(result);
        }

        [Route("multiply")]
        [HttpGet]
        public IHttpActionResult Multiply(int a, int b)
        {
            var result = _mathService.Multiply(a, b);
            return Ok(result);
        }

        [Route("divide")]
        [HttpGet]
        [DivideByZeroExceptionFilter]
        public IHttpActionResult Divide(int a, int b)
        {
            var result = _mathService.Divide(a, b);
            return Ok(result);
        }
    }
}