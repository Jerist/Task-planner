
using TaskPlanner.BL.Auth.Entities;

namespace TaskPlanner.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeUser(string phone, string password);
        Task RegisterUser(string phone, string password);
    }
}
