using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    public class MessagesController : BaseApiController
    {
        private readonly DataContext _context;
        public MessagesController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        [HttpPost("newMessage")]
        public async Task<ActionResult<Message>> Create(Message messages)
        {
            var message = new Message
            {
                Title = messages.Title,
                MessageBody = messages.MessageBody,
                CreateDate = DateTime.Now,
                CreateBy = messages.CreateBy,
                DeepLinkAction = messages.DeepLinkAction,
                ImportanceLevel = messages.ImportanceLevel,
                AppUserId = 1
            };
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }
    }
}