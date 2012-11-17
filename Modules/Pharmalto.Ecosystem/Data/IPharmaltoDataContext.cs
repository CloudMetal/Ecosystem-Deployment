using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard;

namespace Pharmalto.Ecosystem.Data
{
    public interface IPharmaltoDataContext : IDependency
    {
        PharmaltoDataContext Context { get; }
    }
}
