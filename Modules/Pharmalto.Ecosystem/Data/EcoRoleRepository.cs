using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;

namespace Pharmalto.Ecosystem.Data
{
    public class EcoRoleRepository : RoleRepository, IEcoRoleRepository
    {
        public EcoRoleRepository(IPharmaltoDataContext context) : base(context.Context) {}
    }
}