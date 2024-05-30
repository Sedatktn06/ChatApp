using ChatApp.Data.Entities;
using ChatApp.Data.Models;

namespace ChatApp.Data.Repositories;

public interface IGenericRepository<T> where T:BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync(PaginationModel paginationModel);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
