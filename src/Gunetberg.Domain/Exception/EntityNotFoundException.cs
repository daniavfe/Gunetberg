namespace Gunetberg.Domain.Exception
{
    public class EntityNotFoundException<T> : System.Exception
    {
        public EntityNotFoundException() : base($"Entity {typeof(T)} Not found")
        {
        }

    }
}
