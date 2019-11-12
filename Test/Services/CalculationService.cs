using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.RemoteServices;
using Infrastucture.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IMapper _mapper;
        private readonly IRemoteCalculationService _remoteCalculationService;

        public CalculationService(IMapper mapper, IRemoteCalculationService remoteCalculationService)
        {
            _mapper = mapper;
            _remoteCalculationService = remoteCalculationService;
        }

        public async Task<int> Calculate(InputModel inputModel)
        {
            var calcModel = _mapper.Map<CalculationModel>(inputModel);

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
