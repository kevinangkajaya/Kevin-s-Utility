
namespace webapi.services;

public interface IMariaDbWealthService
{
    // public Task<int> Delete(int id); // should use Update for soft delete
    public Task<IEnumerable<Wealth>> FindAll();
    public Task<Wealth> FindOne(int id);
    public Task<int> Insert(Wealth data);
    public Task<int> Update(Wealth data);
}