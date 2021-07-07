using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Authorize]
    public class MessagesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        public MessagesController(IMessageRepository messageRepository, DataContext context, 
            UserManager<AppUser> userManager, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            var message = await _messageRepository.GetMessageById(id);
            return _mapper.Map<Message>(message);
        }

        [HttpGet("fetchFromApi")]
        public async Task<ActionResult<MessageDetail>> GetFromApi()
        {   
            WebClient client = new WebClient();

            var json_data = client.DownloadString("https://6b9b8bef3c0b387287e826964b122804.m.pipedream.net/");

            var messagesFromUrl = JsonConvert.DeserializeObject<List<MessageDetail>>(json_data);
            
            foreach(var data in messagesFromUrl ) 
            { 
                Console.WriteLine(data.Title);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMessage(int id, MessageDto messageDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.FindFirstValue(ClaimTypes.Name));

            if(user.Id != _context.Messages.Find(id).AppUserId) return BadRequest("You can't edit");

            if(_context.Messages.Find(id).CreateBy == "System") return BadRequest("You can't edit from fetch");

            var message = await _messageRepository.GetMessageById(id);

            _mapper.Map(messageDto, message);

            _messageRepository.Update(message);

            if (await _messageRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to save data");
        }

        [HttpPost("newMessage")]
        public async Task<ActionResult<Message>> Create(Message messages)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.FindFirstValue(ClaimTypes.Name));

            var message = new Message
            {
                Title = messages.Title,
                MessageBody = messages.MessageBody,
                CreateDate = DateTime.Now,
                CreateBy = user.UserName,
                DeepLinkAction = messages.DeepLinkAction,
                ImportanceLevel = messages.ImportanceLevel,
                AppUserId = user.Id
            };
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }
    }
}