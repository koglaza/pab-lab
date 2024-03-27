namespace WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool AuthorizeUser(string username, string password)
        {
            return password.ToLower().Equals("wsei");
        }
    }
}
