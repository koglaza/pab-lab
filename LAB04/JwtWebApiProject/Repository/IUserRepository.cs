namespace WebApi.Repository
{
    public interface IUserRepository
    {
        bool AuthorizeUser(string username, string pass);
    }
}
