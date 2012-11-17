using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedVault.Framework.Model;
using MedVault.Framework.Model.Service;
using Orchard;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Services
{
    public interface IEcoUserService : IUserService, IDependency {
        EcoUserPart CreateUser(string email, string password);
    }
}
