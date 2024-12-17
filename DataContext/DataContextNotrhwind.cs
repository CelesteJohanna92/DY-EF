using EjemploEnClase.Model;
using Microsoft.EntityFrameworkCore;

namespace EjemploEnClase.DataContext
{
    public class DataContextNotrhwind : DbContext
    {
        public DataContextNotrhwind(DbContextOptions<DataContextNotrhwind> options) : base(options)
        { }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
 }
