using System.Threading.Tasks;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request);
        
        Task<AuthenticationResult> LoginAsync(string email, string password);
        
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
