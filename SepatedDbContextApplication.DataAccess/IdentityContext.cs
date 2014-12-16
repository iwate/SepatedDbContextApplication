using Microsoft.AspNet.Identity;
using SepatedDbContextApplication.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepatedDbContextApplication.DataAccess
{
    public class IdentityContext : DbContext,
        IUserPasswordStore<User>,
        IUserSecurityStampStore<User>,
        IUserLockoutStore<User, string>,
        IUserTwoFactorStore<User, string>,
        IUserStore<User>
    {
        public IdentityContext()
            : base("DefaultConnection"){}
        public IdentityContext(string connectionStringName) 
            : base(connectionStringName) { }
        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
        public DbSet<User> Users { get; set; }

        public async System.Threading.Tasks.Task<string> GetPasswordHashAsync(User user)
        {
            return (await FindByIdAsync(user.Id)).PasswordHash;
        }

        public async System.Threading.Tasks.Task<bool> HasPasswordAsync(User user)
        {
            return (await FindByIdAsync(user.Id)).PasswordHash != null;
        }

        public async System.Threading.Tasks.Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            await UpdateAsync(user);
        }

        public async System.Threading.Tasks.Task CreateAsync(User user)
        {
            if (user.Id == null)
            {
                user.Id = Guid.NewGuid().ToString("n");
            }
            Users.Add(user);
            await SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(User user)
        {
            Users.Remove(user);
            await SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<User> FindByIdAsync(string userId)
        {
            return await Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async System.Threading.Tasks.Task<User> FindByNameAsync(string userName)
        {
            return await Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async System.Threading.Tasks.Task UpdateAsync(User user)
        {
            if (user.Id == null)
                return;
            Entry<Entity.User>(user).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<string> GetSecurityStampAsync(User user)
        {
            return (await FindByIdAsync(user.Id)).SecurityStamp;
        }

        public async System.Threading.Tasks.Task SetSecurityStampAsync(User user, string stamp)
        {
            user.SecurityStamp = stamp;
            await UpdateAsync(user);
        }

        public System.Threading.Tasks.Task<int> GetAccessFailedCountAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public System.Threading.Tasks.Task<bool> GetLockoutEnabledAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(false);
        }

        public System.Threading.Tasks.Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(DateTimeOffset.Now);
        }

        public System.Threading.Tasks.Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public System.Threading.Tasks.Task ResetAccessFailedCountAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public System.Threading.Tasks.Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public System.Threading.Tasks.Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return System.Threading.Tasks.Task.FromResult(0);
        }

        public System.Threading.Tasks.Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return System.Threading.Tasks.Task.FromResult(false);
        }

        public System.Threading.Tasks.Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return System.Threading.Tasks.Task.FromResult(0);
        }
    }
}
