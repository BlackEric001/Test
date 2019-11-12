using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TestService.Controllers
{
    /// <summary>
    /// Make calculations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// ((2*5) + 4)/7 = 2
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CalculationResponse> Calculate(CalculationModel model)
        {
            var response = new CalculationResponse();

            if (model.Value4 == 0)
            {
                response.Error = "Can not divide by zero!!!";
            }
            else
            {
                response.Result = ((model.Value1 * model.Value2) + model.Value3) / model.Value4;
            }

            return await Task.FromResult(response);
        }
    }
}
