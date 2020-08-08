using System;
using Medialink.Dal.Abstractions;
using Medialink.Dal.Models;
using MediaLink.Lib.Abstractions;
using RestSharp;

namespace MediaLink.Lib.Services
{
    public class MathService : IMathService
    {
        private readonly IRestClient _restClient;
        private readonly IOperationRepository _operationRepository;

        public MathService(IRestClient restClient, IOperationRepository operationRepository)
        {
            _restClient = restClient;
            _restClient.BaseUrl = new Uri("http://api.mathjs.org/v4/");
            _operationRepository = operationRepository;
        }

        public double Add(int a, int b)
        {
            var sum = _restClient.Get(new RestRequest($"?expr={a}+{b}")).Content;
            var result  = double.Parse(sum);
            _operationRepository.Create(new Operation
            {
                Name = nameof(Add),
                A = a,
                B = b,
                Result = result,
                Date = DateTimeOffset.Now
            });

            return result;
        }

        public double Multiply(int a, int b)
        {
            var product = _restClient.Get(new RestRequest($"?expr={a}*{b}")).Content;
            var result = double.Parse(product);
            _operationRepository.Create(new Operation
            {
                Name = nameof(Multiply),
                A = a,
                B = b,
                Result = result,
                Date = DateTimeOffset.Now
            });

            return result;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by 0!");
            }

            var quotient = _restClient.Get(new RestRequest($"?expr={a}/{b}")).Content;
            var result = double.Parse(quotient);
            _operationRepository.Create(new Operation
            {
                Name = nameof(Divide),
                A = a,
                B = b,
                Result = result,
                Date = DateTimeOffset.Now
            });

            return result;
        }
    }
}