using ChatApp.Data.Models;

namespace ChatApp.Services;

public interface IGenericService<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync(PaginationModel paginationModel);
    Task<int> CountAsync();
}
