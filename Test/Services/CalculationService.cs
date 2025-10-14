using Infrastructure.Mapper;
using Infrastructure.RemoteServices;
using Infrastucture.DTO.Models;
using System;
using System.Threading.Tasks;

namespace Test.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IRemoteCalculationService _remoteCalculationService;

        public CalculationService(IRemoteCalculationService remoteCalculationService)
        {
            _remoteCalculationService = remoteCalculationService;
        }

        public async Task<int> Calculate(InputModel inputModel)
        {
            var mapper = new InputMapper();
            var calcModel = mapper.InputModelToCalulationModel(inputModel);

            try
            {
                var result = await _remoteCalculationService.Calculate(calcModel);

                if (!string.IsNullOrEmpty(result.Error))
                    throw new Exception(result.Error);

                return result.Result;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error remote service call: {ex.Message}");
            }
        }
    }
}
