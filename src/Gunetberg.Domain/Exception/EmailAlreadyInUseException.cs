namespace Gunetberg.Domain.Exception
{
    public class EmailAlreadyInUseException : System.Exception
    {
        public EmailAlreadyInUseException() : base($"Email already in use.")
        {
        }
    }
}
