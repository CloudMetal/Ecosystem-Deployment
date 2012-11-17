using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;
using Orchard.ContentManagement;
using Orchard.Security;

namespace Pharmalto.Ecosystem.Models
{
    public class EcoUserPart : ContentPart<EcoUserPartRecord>, IUser {
        public EcoUserPart() {
            User = new User();
        }

        public int UserId {
            get { return Record.UserId; }
            set { Record.UserId = value; }
        }

        public User User { get; set; }

        public string UserName
        {
            get { return User.Email; }
        }

        public string Email
        {
            get { return User.Email; }
        }
    }
}