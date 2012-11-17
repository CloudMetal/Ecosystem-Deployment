using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MedVault.Framework.Model;
using MedVault.Framework.Model.Service;
using Orchard;

namespace Pharmalto.Ecosystem.Services
{
    public interface IEcoMedicineService : IMedicineService, IDependency {
        IList<Medicine> GetMedicines(Expression<Func<Medicine, bool>> predicate );
        Medicine GetMedicine(int id);
    }
}
