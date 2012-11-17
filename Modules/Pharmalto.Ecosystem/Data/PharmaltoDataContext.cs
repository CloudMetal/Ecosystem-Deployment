using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CloudMetal.Core.Data.Configuration;
using MedVault.Framework.Model;

namespace Pharmalto.Ecosystem.Data
{
    public class PharmaltoDataContext : MedVaultModelContainer, IPharmaltoDataContext
    {
        public PharmaltoDataContext(IPharmaltoConnectionStringService connectionStringService) : base(connectionStringService) { }

        public PharmaltoDataContext Context
        {
            get { return this; }
        }
    }
}