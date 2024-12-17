using EjemploEnClase.Model;
using EjemploEnClase.QueryResponse;
using EjemploEnClase.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EjemploEnClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            return await _repository.ObtenerTodosLosEmpleados();
        }

        [HttpGet]
        [Route("api/CantidadEmpleados")]
        public async Task<int> ObtenerCantidadEmpleados()
        {
            return await _repository.ObtenerCantidadEmpleados();
        }

        [HttpGet]
        [Route("api/EmpleadoPorID")]
        public async Task<Employees> EmpleadoPorID([FromQuery] int empleadoID)
        {
            return await _repository.EmpleadoPorID(empleadoID);
        }

        [HttpGet]
        [Route("api/EmpleadosPorNombre")]
        public async Task<Employees> ObtenerEmpleadosPorNombre([FromQuery] string nombreEmpleado)
        {
            return await _repository.ObtenerEmpleadosPorNombre(nombreEmpleado);
        }

        [HttpGet]
        [Route("api/IDempleadoPorTitulo")]
        public async Task<Employees> ObtenerIDEmpleadoPorTitulo([FromQuery] string titulo)
        {
            return await _repository.ObtenerIDEmpleadoPorTitulo(titulo);
        }

        [HttpGet]
        [Route("api/EmpleadoporPais")]
        public async Task<Employees> ObtenerEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerEmpleadoPorPais(country);
        }

        [HttpGet]
        [Route("api/TodosLosEmpleadoPorPais")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerTodosLosEmpleadosPorPais(country);
        }

        [HttpGet]
        [Route("api/ElEmpleadoMasGrande")]
        public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {
            return await _repository.ObtenerElEmpleadoMasGrande();
        }

        [HttpGet]
        [Route("api/EmpleadosPorTitulo")]
        public async Task<List<EmpleadosPorTituloResponse>> ObtenerEmpleadosPorTitulo()
        {
            return await _repository.ObtenerEmpleadosPorTitulo();
        }

        [HttpGet]
        [Route("api/ProductoConCategoria")]
        public async Task<List<ProductoPorCategoriaResponse>> ObtenerProductoConCategoria()
        {
            return await _repository.ObtenerProductoConCategoria();
        }

        [HttpGet]
        [Route("api/ProductosConChef")]

        public async Task<IEnumerable<object>> ObtenerProductosConChef()
        {
            return await _repository.ObtenerProductosConChef();
        }

        [HttpDelete]
        [Route("api/EliminarOrdenPorID")]
        public async Task<bool> EliminarOrdenPorID([Required, FromQuery] int id)
        {
            return await _repository.EliminarOrdenPorID(id);
        }

        [HttpPut]
        [Route("api/InsertarEmpleado")]

        public async Task<bool> InsertarEmpleado()
        {
            return await _repository.InsertarEmpleado();
        }

        [HttpPut]
        [Route("api/ModificarNombreEmpleado")]

        public async Task<bool> ModificarNombreEmpleado([Required, FromQuery] int id, [Required, FromQuery] string nombre)
        {
            return await _repository.ModificarNombreEmpleado(id, nombre);
        }

    }
}