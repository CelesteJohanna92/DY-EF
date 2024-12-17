using EjemploEnClase.Model;
using EjemploEnClase.QueryResponse;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EjemploEnClase.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employees>> ObtenerTodosLosEmpleados();
        Task<int> ObtenerCantidadEmpleados();
        Task<Employees> EmpleadoPorID(int id);
        Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado);
        Task<Employees?> ObtenerIDEmpleadoPorTitulo(string titulo);
        Task<Employees> ObtenerEmpleadoPorPais(string country);
        Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country);
        Task<Employees> ObtenerElEmpleadoMasGrande();
        Task<List<EmpleadosPorTituloResponse>> ObtenerEmpleadosPorTitulo();
        Task<List<ProductoPorCategoriaResponse>> ObtenerProductoConCategoria();
        Task<IEnumerable<object>> ObtenerProductosConChef();
        Task<bool> EliminarOrdenPorID(int orderID);
        Task<bool> InsertarEmpleado();
        Task<bool> ModificarNombreEmpleado([Required, FromQuery] int id, [Required, FromQuery] string nombre);
    }
}