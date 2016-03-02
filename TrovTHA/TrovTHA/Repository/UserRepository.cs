using Common.Repository;
using TrovTHA.Models;

namespace TrovTHA.Repository
{
    public class UserRepository : BaseInMemoryRepository<ApplicationUser>, IUserRepository
    {
    }
}