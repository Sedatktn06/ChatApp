using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Data.Repositories.MessageRepositories;

namespace ChatApp.Services.Services.MessageServices;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Message> AddAsync(Message entity)
    {
        var message = await _messageRepository.CreateAsync(entity);
        return message;
    }

    public async Task<int> CountAsync()
    {
        var count = await _messageRepository.CountAsync();
        return count;
    }

    public async Task<Message> DeleteAsync(Message entity)
    {
        var message = await _messageRepository.DeleteAsync(entity);
        return message;
    }

    public async Task<IReadOnlyList<Message>> GetAllAsync(PaginationModel paginationModel)
    {
        var messages = await _messageRepository.GetAllAsync(paginationModel);
        return messages;
    }

    public async Task<Message> GetByIdAsync(int id)
    {
        var message = await _messageRepository.GetByIdAsync(id);
        return message;
    }

    public async Task<Message> UpdateAsync(Message entity)
    {
        var message = await _messageRepository.UpdateAsync(entity);
        return message;
    }
}
