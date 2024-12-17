namespace EjemploEnClase.EjemploConDY
{
    public class UsuarioServiceConDY 
    {
        private  IEmailServiceConDY _emailServiceConDY;

        public UsuarioServiceConDY(IEmailServiceConDY emailServiceConDY)
        {
            _emailServiceConDY = _emailServiceConDY;
        }
        public bool enviarNotificacionUsuarioConDY(String email)
        {
            _emailServiceConDY.Enviar(email, "Notificacion");
            return true;      }
    }
}
