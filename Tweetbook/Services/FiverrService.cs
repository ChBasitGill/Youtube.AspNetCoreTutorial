using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Data;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class FiverrService : IFiverrService
    {

        private readonly DataContext _dataContext;
        public FiverrService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateAsync(FiverrServices model)
        {
            await _dataContext.FiverrServices.AddAsync(model);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteAsync(Guid Id, string UserId)
        {
           var fiverrService =  await _dataContext.FiverrServices.SingleOrDefaultAsync(x => x.Id == Id && x.UserId==UserId);
            if (fiverrService == null)
            {
                return false;
            }
            _dataContext.FiverrServices.Remove(fiverrService);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<FiverrServices> GetFiverrServiceByIdAsync(Guid Id, string UserId)
        {
            return await _dataContext.FiverrServices
            .SingleOrDefaultAsync(x => x.Id == Id && x.UserId==UserId);
        }

        public async Task<bool> UpdateAsync(FiverrServices model, string UserId)
        {
            var fiverrService = await _dataContext.FiverrServices.SingleOrDefaultAsync(x => x.Id == model.Id && x.UserId == UserId);
            if (fiverrService == null)
            {
                return false;
            }
            _dataContext.FiverrServices.Update(model);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async  Task<List<FiverrServices>> GetFiverrServicesAsync(string UserId)
        {
            var queryable = _dataContext.FiverrServices.AsQueryable();

            return await queryable.ToListAsync(); 
        }
    }
}
