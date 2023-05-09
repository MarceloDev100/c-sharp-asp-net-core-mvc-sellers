﻿using SalesWebMvc.Models;

namespace SalesWebMvc.Services.Interfaces
{
    public interface ISellerService
    {
        Task<List<Seller>> FindAllAsync();
        Task InsertAsync(Seller obj);
        Task<Seller> FindByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(Seller obj);
    }
}
