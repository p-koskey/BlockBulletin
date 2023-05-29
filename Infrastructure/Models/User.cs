using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Models;

public class User:IdentityUser<int>
{
    public virtual ICollection<Post>? Posts { get; set; }
}