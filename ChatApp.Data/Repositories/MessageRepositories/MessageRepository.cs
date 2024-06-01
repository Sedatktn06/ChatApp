using ChatApp.Data.Entities;

namespace ChatApp.Data.Repositories.MessageRepositories;

public class MessageRepository : GenericRepository<Message>, IMessageRepository
{
    public MessageRepository(ChatAppDbContext chatAppDbContext) : base(chatAppDbContext)
    {
    }
}
