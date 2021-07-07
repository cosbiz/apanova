using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await _context.Messages
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
        }
    }
}