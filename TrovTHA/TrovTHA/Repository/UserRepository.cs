using System.Linq;
using Common.Repository;
using TrovTHA.Models;

namespace TrovTHA.Repository
{
    public class UserRepository : BaseInMemoryRepository<ApplicationUser>, IUserRepository
    {
        public ApplicationUser FindByUsername(string userName)
        {
            return FindAll().FirstOrDefault(item => item.UserName == userName);
        }
    }
}