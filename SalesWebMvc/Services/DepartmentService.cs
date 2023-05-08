using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Interfaces;


namespace SalesWebMvc.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
