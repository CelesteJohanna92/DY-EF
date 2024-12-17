using EjemploEnClase.Model;
using EjemploEnClase.DataContext;
using Microsoft.EntityFrameworkCore;
using EjemploEnClase.QueryResponse;
namespace EjemploEnClase.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContextNotrhwind _dataContext;

        public NorthwindRepository(DataContextNotrhwind dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            var result = await _dataContext.Employees.ToListAsync();
            return result;
        }

        public async Task<int> ObtenerCantidadEmpleados()
        {
            var result = await _dataContext.Employees.CountAsync();
            return result;
        }

        public async Task<Employees> EmpleadoPorID(int id)
        {
            var result = await _dataContext.Employees.Where(e => e.EmployeeID == id).FirstAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado)
        {
            var result = await _dataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == nombreEmpleado);
            return result;
        }

        public async Task<Employees?> ObtenerIDEmpleadoPorTitulo(string titulo)
        {
            var result = from emp in _dataContext.Employees where emp.Title == titulo select emp;
            return await result.FirstOrDefaultAsync();
        }

        public async Task<Employees> ObtenerEmpleadoPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName
                         };

            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         orderby emp.FirstName
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName
                         };

            return await result.ToListAsync();
        }
        public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {
            var result = from emp in _dataContext.Employees
                         orderby emp.BirthDate
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName
                         };

            return await result.FirstOrDefaultAsync();
        }
        public async Task<List<EmpleadosPorTituloResponse>> ObtenerEmpleadosPorTitulo()
        {
            var result = await (from emp in _dataContext.Employees
                                group emp by emp.Title into g
                                select new EmpleadosPorTituloResponse
                                {
                                    Titulo = g.Key,
                                    CantidadEmpleados = g.Count()
                                }).ToListAsync();
            return result;
        }
        public async Task<List<ProductoPorCategoriaResponse>> ObtenerProductoConCategoria()
        { 
                var result = from prod in _dataContext.Products
                             join cat in _dataContext.Categories on prod.CategoryID equals cat.CategoryID
                             select new ProductoPorCategoriaResponse
                             {
                                 Producto = prod.ProductName,
                                 Categoria = cat.CategoryName,
                             };
            return await result.ToListAsync();

            }
        public async Task<IEnumerable<object>> ObtenerProductosConChef()
        {
            var result = from prod in _dataContext.Products
                         where prod.ProductName.Contains("chef")
                         select new
                         {
                             Producto = prod.ProductName,
                             Precio = prod.UnitPrice
                         };

            return await result.ToListAsync();
        }

        public async Task<bool> EliminarOrdenPorID(int orderID)
        {
            Orders? orden = await _dataContext.Orders.Where(r => r.OrderID == orderID).FirstOrDefaultAsync();
            OrderDetails? orderDetail = await _dataContext.OrderDetails.Where(r => r.OrderID == orden.OrderID).FirstOrDefaultAsync();

            _dataContext.OrderDetails.Remove(orderDetail);
            _dataContext.Orders.Remove(orden);

            var resulta = _dataContext.SaveChanges();
            return true;
        }

        public async Task<bool> InsertarEmpleado()
        {
            Employees employee = new Employees();
            employee.Title = "Developer";
            employee.City = "Buenos Aires";
            employee.FirstName = "Celeste";
            employee.LastName = "Astarito";
            employee.HireDate = DateTime.Now;
            employee.BirthDate = DateTime.Now;
            var newEmployee = await _dataContext.AddAsync(employee);
            var result = _dataContext.SaveChanges();

            return (result > 0);
        }
        public async Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre)
        {
            bool actualizado = false;
            Employees result = await _dataContext.Employees.Where(r => r.EmployeeID == idEmpleado).FirstOrDefaultAsync();

            if (result != null)
            {
                result.FirstName = nombre;
                var resulta = _dataContext.SaveChanges();
                actualizado = true;
            }

            return actualizado;
        }

    } 
}