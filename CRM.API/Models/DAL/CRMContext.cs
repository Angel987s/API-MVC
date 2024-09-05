using CRM.API.Models.EN;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CRM.API.Models.DAL
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
