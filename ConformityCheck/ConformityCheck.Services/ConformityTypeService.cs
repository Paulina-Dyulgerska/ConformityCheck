using ConformityCheck.Data;
using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System;
using System.Linq;

namespace ConformityCheck.Services
{
    public class ConformityTypeService : IConformityTypeService
    {
        private readonly ConformityCheckContext db;

        public ConformityTypeService(ConformityCheckContext db)
        {
            this.db = db;
        }
        public void Create(ConformityTypeImputDTO conformityTypeImputDTO)
        {
            //if no description is provided
            if (conformityTypeImputDTO.Description == null)
            {
                throw new ArgumentNullException(nameof(conformityTypeImputDTO.Description));
            }

            //if this conformity type is already in the DB
            if (this.db.ConformityTypes.FirstOrDefault(c=>c.Description == conformityTypeImputDTO.Description) != null)
            {
                throw new ArgumentException($"Has this conformity type {nameof(conformityTypeImputDTO.Description)}");
            }

            ConformityType conformityType = new ConformityType
            {
                Description = conformityTypeImputDTO.Description.Trim(),
            };

            this.db.ConformityTypes.Add(conformityType);

            this.db.SaveChanges();
        }
    }
}
