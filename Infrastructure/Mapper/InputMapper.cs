using Infrastructure.DTO;
using Infrastucture.DTO.Models;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.Mapper
{
    [Mapper]
    public partial class InputMapper
    {
        public partial CalculationModel InputModelToCalulationModel(InputModel inputModel);
    }
}
