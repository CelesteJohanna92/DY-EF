using EjemploEnClase.EjemploSinDY;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEnClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjenploSinDYController : ControllerBase
    {
        [HttpGet]
        public bool EnviarMail([FromQuery]string mail) 
        {
            UsuarioServiceSinDY usuarioServiceSinDY = new UsuarioServiceSinDY();
            return usuarioServiceSinDY.EnviarNotificacionUsuario(mail);
        }
    }
}
