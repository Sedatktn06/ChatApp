using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ChatAppDbContext _chatAppDbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ChatAppDbContext chatAppDbContext)
    {
        _chatAppDbContext = chatAppDbContext;
        _dbSet = _chatAppDbContext.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _chatAppDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _chatAppDbContext.Remove(entity);
        await _chatAppDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(PaginationModel paginationModel)
    {
        if (paginationModel != null)
        {
            return await _dbSet.Skip((paginationModel.PageNumber - 1) * paginationModel.PageSize)
                .Take(paginationModel.PageSize)
                .ToListAsync();
        }
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _chatAppDbContext.Update(entity);
        await _chatAppDbContext.SaveChangesAsync();
        return entity;
    }
}
