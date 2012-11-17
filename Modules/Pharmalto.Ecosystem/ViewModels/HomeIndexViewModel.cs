using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedVault.Framework.Model;
using Pharmalto.Ecosystem.Models;

namespace Pharmalto.Ecosystem.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Medicine> Medicines { get; set; }
        public EcoUserPart User { get; set; }
    }
}