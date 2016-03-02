using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TrovTHA.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public static class InMemoryUserContext
    {
        static InMemoryUserContext()
        {
            UserList = new List<ApplicationUser>();
        }

        public static List<ApplicationUser> UserList { get; set; }

        public static bool Add(ApplicationUser user)
        {
            UserList.Add(user);
            return true;
        }
    }

    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>
    {
        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            return Task.FromResult(user.PasswordHash = passwordHash);
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var user = InMemoryUserContext.UserList.Find(item => item.UserName == userName);
            return Task.FromResult(user);
        }

        public Task CreateAsync(ApplicationUser user)
        {
            return Task.FromResult(InMemoryUserContext.Add(user));
        }

        #region Not implemented methods     

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        #endregion

        public Task SetEmailAsync(ApplicationUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var user = InMemoryUserContext.UserList.Find(item => item.Email == email);
            return Task.FromResult(user);
        }
    }
}