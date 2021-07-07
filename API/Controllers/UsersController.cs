using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UsersController(DataContext context,
        IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _userRepository = userRepository;
        }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync();
        var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(usersToReturn);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<MemberDto>> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return _mapper.Map<MemberDto>(user);
    }

    [Authorize(Policy = "RequireAdminRole")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleteUser = await _context.Users.FindAsync(id);

        if (deleteUser == null)
        {
            return NotFound();
        }

        _context.Users.Remove(deleteUser);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
}