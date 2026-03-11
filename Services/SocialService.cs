using System;
using System.Collections.Generic;
using System.Linq;

public class SocialService
{
    public List<User> Users = new List<User>();
    public List<Post> Posts = new List<Post>();

    private int userIdCounter = 1;
    private int postIdCounter = 1;
    private int commentIdCounter = 1;

    // Register
    public User Register(string username, string password)
    {
        var user = new User { Id = userIdCounter++, Username = username, Password = password };
        Users.Add(user);
        return user;
    }

    // Login
    public User Login(string username, string password)
    {
        return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    // Create Post
    public Post CreatePost(User user, string content)
    {
        var post = new Post { Id = postIdCounter++, Content = content, Author = user };
        Posts.Add(post);
        return post;
    }

    // Like Post
    public void LikePost(User user, int postId)
    {
        var post = Posts.FirstOrDefault(p => p.Id == postId);
        if (post != null && !post.Likes.Contains(user))
        {
            post.Likes.Add(user);
        }
    }

    // Comment Post
    public void CommentPost(User user, int postId, string text)
    {
        var post = Posts.FirstOrDefault(p => p.Id == postId);
        if (post != null)
        {
            var comment = new Comment { Id = commentIdCounter++, Text = text, Author = user };
            post.Comments.Add(comment);
        }
    }

    // View Posts
    public void ViewPosts()
    {
        foreach (var post in Posts)
        {
            Console.WriteLine($"Post {post.Id} by {post.Author.Username}: {post.Content}");
            Console.WriteLine($"Likes: {post.Likes.Count}, Comments: {post.Comments.Count}");
            foreach (var c in post.Comments)
            {
                Console.WriteLine($"  Comment by {c.Author.Username}: {c.Text}");
            }
            Console.WriteLine();
        }
    }
}