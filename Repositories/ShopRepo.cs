using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ShopRepo
    {
        ApplicationDbContext _context;
        public ShopRepo(ApplicationDbContext context)
        {
            _context= context;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products;
            return products;
        }
    }
}
