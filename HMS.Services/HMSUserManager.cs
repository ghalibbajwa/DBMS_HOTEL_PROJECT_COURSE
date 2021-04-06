using HMS.Data;
using HMS.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Services
{
    public class HMSUserManager: UserManager<HMSUser>
    {
        public HMSUserManager(IUserStore<HMSUser> store)
           : base(store)
        {
        }

        public static HMSUserManager Create(IdentityFactoryOptions<HMSUserManager> options, IOwinContext context)
        {
            var manager = new HMSUserManager(new UserStore<HMSUser>(context.Get<HMSContext>()));

            manager.UserValidator = new UserValidator<HMSUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 5,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

         
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<HMSUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<HMSUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });


            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<HMSUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
