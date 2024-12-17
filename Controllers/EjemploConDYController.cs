using EjemploEnClase.EjemploConDY;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEnClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploConDYController : ControllerBase
    {
        private IEmailServiceConDY _emailServiceConDY;

        public EjemploConDYController(IEmailServiceConDY emailServiceConDY)

        {
            _emailServiceConDY = emailServiceConDY;
        }

        [HttpGet]
        public bool EnviarMail([FromQuery] string mail)
        {
            UsuarioServiceConDY usuarioServiceSinDY = new UsuarioServiceConDY(_emailServiceConDY);
            return usuarioServiceSinDY.enviarNotificacionUsuarioConDY(mail);
        }
    }
}
