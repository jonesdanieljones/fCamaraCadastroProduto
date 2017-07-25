﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TesteDeveloper.Infra.CrossCutting.Identity.Models.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
