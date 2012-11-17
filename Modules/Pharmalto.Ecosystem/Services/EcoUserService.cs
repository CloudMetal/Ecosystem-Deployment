using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using CloudMetal.Core.Domain;
using MedVault.Framework.Model;
using MedVault.Framework.Model.Service;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.Services;
using Orchard.Users.Models;
using Pharmalto.Ecosystem.Data;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.Services
{
    public class EcoUserService : UserService, IEcoUserService
    {
        private readonly IOrchardServices _orchardServices;
        private readonly IMembershipService _membershipService;
        private readonly IClock _clock;

        public EcoUserService(IEcoUserRepository repository, IOrchardServices orchardServices,
            IMembershipService membershipService, IClock clock,
            IEcoProfileService profileService, IEcoRoleService roleService) : base(repository) {
            _clock = clock;
            _membershipService = membershipService;
            _orchardServices = orchardServices;

            ProfileService = profileService;
            RoleService = roleService;
        }

        public EcoUserPart CreateUser(string email, string password) {
            var ecoUser = _orchardServices.ContentManager.New("EcoUser");
            var userPart = ecoUser.As<UserPart>();
            var ecoUserPart = ecoUser.As<EcoUserPart>();

            userPart.UserName = email;
            userPart.Email = email;
            userPart.NormalizedUserName = email.ToLowerInvariant();
            userPart.Record.HashAlgorithm = "SHA1";
            userPart.Record.RegistrationStatus = UserStatus.Approved;
            userPart.Record.EmailStatus = UserStatus.Approved;

            // create the user in medvault side....
            ecoUserPart.User = new User();
            ecoUserPart.User.CreateDate = _clock.UtcNow;
            ecoUserPart.User.Password = password;
            ecoUserPart.User.Email = email;
            ecoUserPart.User.UserName = email;
            ecoUserPart.User.LastUpdateDate = ecoUserPart.User.CreateDate;
            ecoUserPart.User.LoweredEmail = userPart.NormalizedUserName;

            _membershipService.SetPassword(userPart, password);

            Add(ecoUserPart.User);

            ecoUserPart.UserId = ecoUserPart.User.Id;

            _orchardServices.ContentManager.Create(userPart);
            _orchardServices.ContentManager.Create(ecoUserPart);

            return ecoUserPart;
        }

        public override void Add(User entity)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                base.Add(entity);
                scope.Complete();
            }
        }

        public override void Save(User entity)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                base.Save(entity);
                scope.Complete();
            }
        }

        public override User GetById(int id) {
            User user = null;
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress)) {
                user =  base.GetById(id);
            }
            return user;
        }
    }
}