using SalesWebMvc.Models;

namespace SalesWebMvc.Services.Interfaces
{
    public interface ISellerService
    {
        List<Seller> FindAll();
        void Insert(Seller obj);
        Seller FindById(int id);
        void Remove(int id);
        void Update(Seller obj);
    }
}
