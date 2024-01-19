using Microsoft.AspNetCore.Identity;

namespace WatchPeopleDie.tv.Models;

public class User : IdentityUser
{
    public string? ProfilePath { get; set; }
    public ICollection<Video> posted { get; set; }

}