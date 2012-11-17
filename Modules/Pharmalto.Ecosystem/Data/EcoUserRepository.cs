using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudMetal.Core.Data.EntityFramework;
using MedVault.Framework.Model;

namespace Pharmalto.Ecosystem.Data
{
    public class EcoUserRepository : UserRepository, IEcoUserRepository {
        public EcoUserRepository(IPharmaltoDataContext context) : base(context.Context) {}
    }
}