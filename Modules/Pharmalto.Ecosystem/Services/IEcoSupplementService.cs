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
    public interface IEcoSupplementService : ISupplementService, IDependency
    {
        IList<Supplement> GetSupplements(Expression<Func<Supplement, bool>> predicate);
        Supplement GetSupplement(int id);
    }
}
