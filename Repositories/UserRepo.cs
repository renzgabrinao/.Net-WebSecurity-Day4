using WebApplication1.ViewModels;
using WebApplication1.Data;

namespace WebApplication1.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserVM> GetUserVMs()
        {
            IEnumerable<UserVM> users =
                _context.Users.Select(u => new UserVM() { Email = u.Email });

            return users;
        }

    }
}
