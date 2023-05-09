using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Insert(Seller obj)
        {
            if (obj != null)
            {             
                _context.Add(obj);
                _context.SaveChanges();
            }
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(s => s.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
