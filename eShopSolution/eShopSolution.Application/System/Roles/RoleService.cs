﻿using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.System.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.System.Roles
{
    public class RoleService : IRoleService
    {

        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<List<RoleVm>> GetAll()
        {
            var roles = _roleManager.Roles.
                Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();
            return roles;
        }
    }
}
