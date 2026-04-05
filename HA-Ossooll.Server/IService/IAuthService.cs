using HA_Ossooll.Data.DTOs;

namespace HA_Ossooll.Services.IService
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(TokenRequestModel model);
    }
}