using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Data.Repositories.GroupRepositories;

namespace ChatApp.Services.Services.GroupServices;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Group> AddAsync(Group entity)
    {
        var group =  await _groupRepository.CreateAsync(entity);
        return group;
    }

    public async Task<int> CountAsync()
    {
        var count = await _groupRepository.CountAsync();
        return count;
    }

    public async Task<Group> DeleteAsync(Group entity)
    {
        var group = await _groupRepository.DeleteAsync(entity);
        return group;
    }

    public async Task<IReadOnlyList<Group>> GetAllAsync(PaginationModel paginationModel)
    {
        var groups = await _groupRepository.GetAllAsync(paginationModel);
        return groups;
    }

    public async Task<Group> GetByIdAsync(int id)
    {
        var group = await _groupRepository.GetByIdAsync(id);
        return group;
    }

    public async Task<Group> UpdateAsync(Group entity)
    {
        var group = await _groupRepository.UpdateAsync(entity);
        return group;
    }
}
