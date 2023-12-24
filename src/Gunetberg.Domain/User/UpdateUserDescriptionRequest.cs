namespace Gunetberg.Domain.User
{
    public class UpdateUserDescriptionRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
