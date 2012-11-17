using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;

namespace Pharmalto.Ecosystem.Data
{
    public class EcoMedicineRepository : MedicineRepository, IEcoMedicineRepository
    {
        public EcoMedicineRepository(IPharmaltoDataContext context) : base(context.Context) {}
    }
}