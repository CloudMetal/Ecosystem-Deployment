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
    public class EcoSupplementService : SupplementService, IEcoSupplementService
    {
        public EcoSupplementService(IEcoSupplementRepository repository) : base(repository) {}

        public IList<Supplement> GetSupplements(System.Linq.Expressions.Expression<Func<Supplement, bool>> predicate)
        {
            IList<Supplement> medicines = null;
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                medicines = GetQuery().Where(predicate).ToList();
            }
            return medicines;
        }

        public Supplement GetSupplement(int id)
        {
            Supplement item = null;
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                item = GetById(id);
            }
            return item;
        }
    }
}