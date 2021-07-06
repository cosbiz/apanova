using System;

namespace API.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string DeepLinkAction { get; set; }
        public int ImportanceLevel { get; set; }
    }
}