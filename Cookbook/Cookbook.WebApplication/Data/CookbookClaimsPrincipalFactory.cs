﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cookbook.WebApplication.Data
{
    public class CookbookClaimsPrincipalFactory : UserClaimsPrincipalFactory<CookbookUser>
    {
        public CookbookClaimsPrincipalFactory(UserManager<CookbookUser> userManager,
            IOptions<IdentityOptions> options)
            : base(userManager, options)
        {
        }

        public async override Task<ClaimsPrincipal> CreateAsync(CookbookUser user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                    new Claim(ClaimTypes.GivenName, user.FirstName)
                });
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                     new Claim(ClaimTypes.Surname, user.LastName),
                });
            }

            return principal;
        }
    }
}
