using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Users.Models;
using Pharmalto.Ecosystem.Models;
using Pharmalto.Ecosystem.Services;

namespace Pharmalto.Ecosystem.Handlers
{
    public class EcoUserHandler : ContentHandler {
        private readonly IEcoUserService _ecoUserService;
        private readonly IOrchardServices _orchardServices;

        public EcoUserHandler(IRepository<EcoUserPartRecord> repository,
            IEcoUserService ecoUserService, IOrchardServices orchardServices)
        {
            _ecoUserService = ecoUserService;
            _orchardServices = orchardServices;

            Filters.Add(StorageFilter.For(repository));

            OnCreated<UserPart>((context, part) =>
            {
                var ecoUser = part.As<EcoUserPart>();
                if (ecoUser != null)
                {
                    // ensure created user...
                    var user = _ecoUserService.GetById(ecoUser.UserId);
                    if (user != null)
                    {
                        ecoUser.User = user;
                    }
                    if (user == null && !string.IsNullOrEmpty(part.Email))
                    {
                        user = _ecoUserService.GetUserByEmail(part.Email) as User;

                        if (user == null)
                        {
                            user = new User();
                            user.UserName = part.Email;
                            user.CreateDate = DateTime.UtcNow;
                            user.LastUpdateDate = user.CreateDate;
                            user.Email = user.UserName;
                            user.Password = "Password";
                            user.PasswordFormat = 0;
                            user.LoweredEmail = user.Email;

                            _ecoUserService.Add(user);
                        }

                        ecoUser.UserId = user.Id;
                        ecoUser.User = user;

                        /*var rootPersona = _personaService.GetPersonaByName("User");
                        var userPersona = new UserPersona();
                        userPersona.PersonaId = rootPersona.Id;
                        userPersona.UserId = user.Id;
                        _personaService.Save(rootPersona);*/

                        _orchardServices.ContentManager.Publish(part.ContentItem);

                        _orchardServices.ContentManager.Publish(ecoUser.ContentItem);
                    }
                }
            });

            OnLoaded<UserPart>((context, part) =>
            {
                var ecoUser = part.As<EcoUserPart>();
                if (ecoUser != null)
                {
                    // ensure created user when module might have been disabled, etc...
                    // ensure created user...
                    var user = _ecoUserService.GetById(ecoUser.UserId);
                    if (user != null)
                    {
                        ecoUser.User = user;
                    }
                    if (user == null && !string.IsNullOrEmpty(part.Email))
                    {
                        user = new User();
                        user.UserName = part.Email;
                        user.CreateDate = DateTime.UtcNow;
                        user.LastUpdateDate = user.CreateDate;
                        user.Email = user.UserName;
                        user.Password = "Password";
                        user.PasswordFormat = 0;
                        user.LoweredEmail = user.Email;

                        _ecoUserService.Add(user);

                        ecoUser.UserId = user.Id;

                        /*var rootPersona = _personaService.GetPersonaByName("User");
                        var userPersona = new UserPersona();
                        userPersona.PersonaId = rootPersona.Id;
                        userPersona.UserId = user.Id;
                        _personaService.Save(rootPersona);*/

                        _orchardServices.ContentManager.Publish(ecoUser.ContentItem);
                    }
                }
            });
        }
    }
}