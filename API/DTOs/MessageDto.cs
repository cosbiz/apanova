using System;

namespace API.DTOs
{
    public class MessageDto
    {
        public string Title { get; set; }
        public string MessageBody { get; set; }
        public string DeepLinkAction { get; set; }
        public int ImportanceLevel { get; set; }
    }
}