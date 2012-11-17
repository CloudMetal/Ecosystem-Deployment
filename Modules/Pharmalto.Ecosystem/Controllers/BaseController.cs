using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using MedVault.Framework.Model;
using Orchard.Security;
using Pharmalto.Ecosystem.Services;

namespace Pharmalto.Ecosystem.Controllers
{
    public class BaseController : Controller {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEcoUserService _ecoUserService;
        private readonly IEcoProfileService _ecoProfileService;

        public BaseController(IAuthenticationService authenticationService, IEcoUserService ecoUserService,
            IEcoProfileService ecoProfileService) {
            _ecoUserService = ecoUserService;
            _authenticationService = authenticationService;
            _ecoProfileService = ecoProfileService;
        }

        protected IAuthenticationService AuthenticationService {
            get { return _authenticationService; }
        }

        protected IEcoUserService EcoUserService {
            get { return _ecoUserService; }
        }

        protected IEcoProfileService ProfileService {
            get { return _ecoProfileService; }
        }

        protected User PharmaltoUser {
            get { 
                var user = _authenticationService.GetAuthenticatedUser();
                if (user == null)
                    return null;

                User u = null;
                using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                    u = _ecoUserService.GetQuery().FirstOrDefault(uu => uu.LoweredEmail == user.Email);
                }
                return u;
            }
        }

        protected MedVault.Framework.Model.Profile FirstProfile {
            get {
                MedVault.Framework.Model.Profile profile = null; 
                if (PharmaltoUser != null) {
                    using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                        profile = _ecoProfileService.GetQuery().FirstOrDefault(p => p.UserId == PharmaltoUser.Id);
                    }
                }
                return profile;
            }
        }
    }
}