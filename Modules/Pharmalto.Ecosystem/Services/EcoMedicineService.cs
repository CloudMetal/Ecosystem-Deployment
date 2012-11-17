using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using MedVault.Framework.Model;
using MedVault.Framework.Model.Service;
using Pharmalto.Ecosystem.Data;

namespace Pharmalto.Ecosystem.Services
{
    public class EcoMedicineService : MedicineService, IEcoMedicineService
    {
        public EcoMedicineService(IEcoMedicineRepository repository) : base(repository) {}

        public IList<Medicine> GetMedicines(System.Linq.Expressions.Expression<Func<Medicine, bool>> predicate) {
            IList<Medicine> medicines = null;
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                medicines = GetQuery().Where(predicate).ToList();
            }
            return medicines;
        }

        public Medicine GetMedicine(int id) {
            Medicine m = null;
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                m = GetById(id);
            }
            return m;
        }
    }
}