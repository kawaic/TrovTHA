using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TrovTHA.Models;
using TrovTHA.Repository;

namespace TrovTHA.Providers
{
    public class RepositoryUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>
    {
        private readonly IUserRepository repository;

        public RepositoryUserStore(IUserRepository repository)
        {
            this.repository = repository;
        }

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
            var user = repository.FindByUsername(userName);
            return Task.FromResult(user);
        }

        public Task CreateAsync(ApplicationUser user)
        {
            return Task.FromResult(repository.Save(user));
        }

        #region Not implemented methods     

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            var user = repository.FindById(userId);
            return Task.FromResult(user);
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
            var user = repository.FindAll().FirstOrDefault(item => item.Email == email);
            return Task.FromResult(user);
        }
    }
}