using ConformityCheck.Data;
using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public void Create(ConformityTypeDTO conformityTypeImputDTO)
        {
            //if no description is provided
            if (conformityTypeImputDTO.Description == null)
            {
                throw new ArgumentNullException(nameof(conformityTypeImputDTO.Description));
            }

            //if this conformity type is already in the DB
            if (this.db.ConformityTypes.FirstOrDefault(c => c.Description.ToUpper() == conformityTypeImputDTO.Description.ToUpper()) != null)
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

        public int Delete(int conformityTypeId)
        {
            //if this conformity type is not in the DB
            if (this.db.ConformityTypes.FirstOrDefault(c => c.Id == conformityTypeId) == null)
            {
                throw new ArgumentException($"No such conformity type");
            }

            //if this conformity type has confirmations in the DB
            if (this.db.ArticleConformities.Any(ac => ac.ConformityId == conformityTypeId))
            {
                throw new ArgumentException($"Cannot delete conformity with articles assigned to it.");
            }

            this.db.ConformityTypes.Remove(this.db.ConformityTypes.FirstOrDefault(c => c.Id == conformityTypeId));

            var a = this.db.SaveChanges();

            return a;
        }

        public IEnumerable<ConformityTypeDTO> ListAllConformityTypes()
        {
            return this.db.ConformityTypes.Select(ct => new ConformityTypeDTO
            {
                Description = ct.Description,
            }).ToList();
        }
    }
}
