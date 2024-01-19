using System.ComponentModel.DataAnnotations;

namespace WatchPeopleDie.tv.Models;

public class Video
{
    [Key]
    public int Id { get; set; }
    public string filePath { get; set; }
    public string Title { get; set; }
    public string UserId { get; set; }
    public User poster { get; set; }
}