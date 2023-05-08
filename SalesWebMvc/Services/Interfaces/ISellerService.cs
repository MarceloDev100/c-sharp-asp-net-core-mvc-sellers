using SalesWebMvc.Models;

namespace SalesWebMvc.Services.Interfaces
{
    public interface ISellerService
    {
        List<Seller> FindAll();
        void Insert(Seller obj);
    }
}
