using System.Collections.Generic;

namespace API.Entities
{
    public class MessageDetail
    {
        public string Title { get; set; }
        public string MessageBody { get; set; }
        public string CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string DeepLinkAction { get; set; }
        public int ImportanceLevel { get; set; }
    }

    public class Content
    {
        public List<MessageDetail> MessageDetails { get; set; }
    }

    public class Root
    {
        public Content Content { get; set; }
    }



}