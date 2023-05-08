using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Interfaces;

namespace SalesWebMvc.Services
{
    public class SellerService : ISellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            if (obj != null)
            {             
                _context.Add(obj);
                _context.SaveChanges();
            }
        }
    }
}
