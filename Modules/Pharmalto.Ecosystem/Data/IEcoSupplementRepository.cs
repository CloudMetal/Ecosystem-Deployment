using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedVault.Framework.Model;
using Orchard;

namespace Pharmalto.Ecosystem.Data
{
    public interface IEcoSupplementRepository : ISupplementRepository, IDependency
    {
    }
}
