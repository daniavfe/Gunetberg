namespace Gunetberg.Domain.User
{
    public class UpdateUserPhotoRequest
    {
        public Guid Id { get; set; }
        public string PhotoUrl { get; set; }
    }
}
