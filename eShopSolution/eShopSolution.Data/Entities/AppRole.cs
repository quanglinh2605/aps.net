﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
