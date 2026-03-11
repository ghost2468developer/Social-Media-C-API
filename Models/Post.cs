using System.Collections.Generic;

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public List<User> Likes { get; set; } = new List<User>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}