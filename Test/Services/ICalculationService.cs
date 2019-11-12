using Infrastucture.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    public interface ICalculationService
    {
        Task<int> Calculate(InputModel inputModel);
    }
}
