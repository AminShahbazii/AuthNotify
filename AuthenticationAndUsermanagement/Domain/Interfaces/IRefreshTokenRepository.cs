using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByTokenAsync(string token);
        Task AddAsync(RefreshToken token);
        Task RevokeAsync(RefreshToken token);

        Task DeleteAsync(RefreshToken token);
    }
}
