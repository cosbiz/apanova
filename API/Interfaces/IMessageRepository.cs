using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> GetMessageById(int id);
        void Update(Message message);
        Task<bool> SaveAllAsync();
    }
}