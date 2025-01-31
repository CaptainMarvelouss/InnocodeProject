﻿using FPT.BusinessLogic;


using FPT.Domain;
using LLMSharp.Google.Palm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPT.API.Controllers;
[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly InnocodeDbContext _context;

    [HttpGet("GetAllUser")]
    public async Task<IActionResult> GetAllUser()
    {
        var user = await _context.Users
            .Where(p => p.UserRole == UserRole.GeneralUser)
            .ToListAsync();

        return Ok(user);
    }

    public AdminController(InnocodeDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetAllPendingPost")]
    public async Task<IActionResult> GetAllPendingPost()
    {
        var post = await _context.Posts
            .Where(p => p.State == State.Pending)
            .Include(p => p.User)
            .ToListAsync();

        return Ok(post);
    }

}
