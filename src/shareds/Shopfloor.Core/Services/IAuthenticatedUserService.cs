namespace Shopfloor.Core.Services
{
    public interface IAuthenticatedUserService
    {
        Guid? UserId { get; }
    }
}
