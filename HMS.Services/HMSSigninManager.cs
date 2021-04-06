using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Services
{
    public class HMSSigninManager : SignInManager<HMSUser, string>
    {
        public HMSSignInManager(HMSUserManager userManager, IAuthenticationManager authenticationManager)
           : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(HMSUser user)
        {
            return user.GenerateUserIdentityAsync((HMSUserManager)UserManager);
        }

        public static HMSSignInManager Create(IdentityFactoryOptions<HMSSignInManager> options, IOwinContext context)
        {
            return new HMSSignInManager(context.GetUserManager<HMSUserManager>(), context.Authentication);
        }
    }
}
