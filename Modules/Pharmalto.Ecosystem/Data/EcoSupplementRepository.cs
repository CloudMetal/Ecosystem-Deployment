using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;

namespace Pharmalto.Ecosystem.Data
{
    public class EcoSupplementRepository : SupplementRepository, IEcoSupplementRepository
    {
        public EcoSupplementRepository(IPharmaltoDataContext dbContext) : base(dbContext.Context) {}
    }
}