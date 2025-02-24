using System;
using API.Models;

namespace API.Interfaces;

// names of interfaces always ahve a capital i 'I'
public interface ITokenServrice
{
    string CreateToken(AppUser user);
}
