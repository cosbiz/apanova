using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Messages")]
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
        public string DeepLinkAction { get; set; }
        public int ImportanceLevel { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}