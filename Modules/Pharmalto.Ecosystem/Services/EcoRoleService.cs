﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;
using MedVault.Framework.Model.Service;
using Pharmalto.Ecosystem.Data;

namespace Pharmalto.Ecosystem.Services
{
    public class EcoRoleService : RoleService, IEcoRoleService
    {
        public EcoRoleService(IEcoRoleRepository repository) : base(repository) {}
    }
}