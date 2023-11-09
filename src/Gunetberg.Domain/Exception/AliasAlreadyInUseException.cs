namespace Gunetberg.Domain.Exception
{
    public class AliasAlreadyInUseException : System.Exception
    {
        public AliasAlreadyInUseException() : base($"Alias already in use.")
        {
        }
    }
}
