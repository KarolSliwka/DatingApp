﻿using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// allow authorize on top level will only work otherwise there will be an issue when trying to allow anonymous on top

[Authorize]
public class UsersController(DataContext context) : BaseApiController
{

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        return users;
    }

    [Authorize]
    [HttpGet("{id}")] // /api/user/3
    public async Task<ActionResult<AppUser>> GetUser(Guid Id)
    {
        var user = await context.Users.FindAsync(Id);

        if (user == null) return NotFound();

        return user;
    }
}