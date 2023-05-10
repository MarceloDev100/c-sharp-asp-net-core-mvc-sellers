using SalesWebMvc.Models;

namespace SalesWebMvc.Services.Interfaces
{
    public interface ISalesRecordService
    {
        Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate);
    }
}
