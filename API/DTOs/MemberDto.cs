using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public string Bio { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
    }
}