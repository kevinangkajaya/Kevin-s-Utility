using webapi.DbContext;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace webapi.services;

public sealed class MariaDbWealthService : IMariaDbWealthService
{
    private readonly MariaDbContext _dbContext;

    public MariaDbWealthService(MariaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public async Task<int> Delete(int id) // should use Update for soft delete
    // {
    //     try
    //     {
    //         _dbContext.Wealths.Remove(
    //             new Wealth
    //             {
    //                 ID = id
    //             }
    //         );

    //         return await _dbContext.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         return 0;
    //     }
    // }

    public async Task<IEnumerable<Wealth>> FindAll()
    {
        return await _dbContext.Wealths.Where(x => x.DeletedAt == null).ToListAsync();
    }

    public async Task<Wealth> FindOne(int id)
    {
        return await _dbContext.Wealths.FirstOrDefaultAsync(x => x.ID == id && x.DeletedAt == null);
    }

    public async Task<int> Insert(Wealth data)
    {
        _dbContext.Add(data);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Update(Wealth data)
    {
        try
        {
            _dbContext.Update(data);
            return await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return 0;
        }
    }
}