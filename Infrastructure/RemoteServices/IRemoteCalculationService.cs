using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RemoteServices
{
    public interface IRemoteCalculationService
    {
        [Post("/api/Calculator")]
        Task<CalculationResponse> Calculate([FromBody] CalculationModel calculationModel);
    }
}
