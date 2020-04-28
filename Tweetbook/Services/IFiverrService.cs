using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public interface IFiverrService
    {
        Task<List<FiverrServices>> GetFiverrServicesAsync(string UserId);
        Task<FiverrServices> GetFiverrServiceByIdAsync(Guid Id, string UserId);
        Task<bool> UpdateAsync(FiverrServices model, string UserId);
        Task<bool> DeleteAsync(Guid Id, string UserId);
        Task<bool> CreateAsync(FiverrServices model);
    }
}
