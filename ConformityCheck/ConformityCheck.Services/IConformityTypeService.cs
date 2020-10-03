using ConformityCheck.Services.Models;
using System.Collections.Generic;

namespace ConformityCheck.Services
{
    public interface IConformityTypeService
    {
        void Create(ConformityTypeDTO conformityTypeImputDTO);

        IEnumerable<ConformityTypeDTO> ListAllConformityTypes();

        int Delete(int conformityTypeId);
    }
}
