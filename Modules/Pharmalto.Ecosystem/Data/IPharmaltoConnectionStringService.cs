using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CloudMetal.Core.Data.Configuration;
using Orchard;

namespace Pharmalto.Ecosystem.Data
{
    public interface IPharmaltoConnectionStringService : IConnectionStringService, IDependency
    {
    }
}
