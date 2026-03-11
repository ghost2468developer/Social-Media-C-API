using System;

class Program
{
    static void Main(string[] args)
    {
        var service = new SocialService();
        User currentUser = null;

        while (true)
        {
            Console.WriteLine("1. Register\n2. Login\n3. Create Post\n4. Like Post\n5. Comment Post\n6. View Posts\n7. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Username: ");
                    var username = Console.ReadLine();
                    Console.Write("Password: ");
                    var password = Console.ReadLine();
                    currentUser = service.Register(username, password);
                    Console.WriteLine($"Registered! Welcome {currentUser.Username}\n");
                    break;
                case "2":
                    Console.Write("Username: ");
                    var uname = Console.ReadLine();
                    Console.Write("Password: ");
                    var pwd = Console.ReadLine();
                    currentUser = service.Login(uname, pwd);
                    Console.WriteLine(currentUser != null ? $"Logged in as {currentUser.Username}\n" : "Invalid credentials\n");
                    break;
                case "3":
                    if (currentUser == null) { Console.WriteLine("Login first!\n"); break; }
                    Console.Write("Post content: ");
                    var content = Console.ReadLine();
                    service.CreatePost(currentUser, content);
                    Console.WriteLine("Post created!\n");
                    break;
                case "4":
                    if (currentUser == null) { Console.WriteLine("Login first!\n"); break; }
                    Console.Write("Post ID to like: ");
                    var likeId = int.Parse(Console.ReadLine());
                    service.LikePost(currentUser, likeId);
                    Console.WriteLine("Post liked!\n");
                    break;
                case "5":
                    if (currentUser == null) { Console.WriteLine("Login first!\n"); break; }
                    Console.Write("Post ID to comment: ");
                    var commentId = int.Parse(Console.ReadLine());
                    Console.Write("Comment: ");
                    var text = Console.ReadLine();
                    service.CommentPost(currentUser, commentId, text);
                    Console.WriteLine("Comment added!\n");
                    break;
                case "6":
                    service.ViewPosts();
                    break;
                case "7":
                    return;
            }
        }
    }
}