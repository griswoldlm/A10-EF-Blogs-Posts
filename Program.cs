using EFTutorial_20024.Models;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFTutorial_20024
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User, Would you like to... \n1.Display Blogs\n2.Add Blog\n3.Display Posts\n4.Add Posts\n0.Exit Program");
            var choice = Console.ReadLine(); 
            do  
            {
                // 1. Display Blogs
                if (choice == "1")
                // READ the Blogs
                {
                    using (var context = new BlogContext())
                    {
                        var blogsList = context.Blogs.ToList();

                        Console.WriteLine("The blogs are:");
                        foreach (var blog in blogsList)
                        {
                            Console.WriteLine($"{blog.Name}");
                        }
                    }
                    break;
                } 
                // 2. Add Blog
                else if (choice == "2")
                // CREATE a blog
                {
                    using (var context = new BlogContext())
                    {
                        Console.WriteLine("Enter a blog name");
                        var blogName = Console.ReadLine();

                        var blog = new Blog();
                        blog.Name = blogName;

                        context.Blogs.Add(blog);
                        context.SaveChanges();
                    }  
                }

                // 3. Display Posts
                else if (choice == "3")
                // READ the posts
                {
                    //List blogs
                    using (var context = new BlogContext())
                    {
                        var blogsList = context.Blogs.ToList();

                        Console.WriteLine("The blogs are:");
                        foreach (var blog in blogsList)
                        {
                            Console.WriteLine($"{blog.Name}");
                        }
                    }
                    // Show posts
                    using (var context = new BlogContext())
                    {
                        Console.WriteLine("Which blog would you like? (Please use the line number + 1)");
                        int blogNumber = Convert.ToInt32(Console.ReadLine());
                        var blog = context.Blogs.Where(x => x.BlogId == blogNumber).FirstOrDefault();
                        var postsList = context.Posts.Where(x => x.BlogId == blogNumber).ToList();

                        Console.WriteLine("The posts are:");
                        foreach (var post in postsList)
                        {
                            Console.WriteLine($"Blog ID: {post.Blog.BlogId}");
                            Console.WriteLine($"    Blog Name: {post.Blog.Name}");
                            Console.WriteLine($"        Blog Title: {post.Title}");
                            Console.WriteLine($"            {post.Content}");
                        }
                    } break;
                } 

                // 4. Add Posts
                else if (choice == "4")
                // CREATE a Post
                 try {
                        // Show blog list
                    using (var context = new BlogContext())
                    {
                        var blogsList = context.Blogs.ToList();

                        Console.WriteLine("The blogs are:");
                        foreach (var blog in blogsList)
                        {
                            Console.WriteLine($"{blog.Name}");
                        }
                    }
                    // Add to blog
                    using (var context = new BlogContext())
                    {

                        Console.WriteLine("Which blog would you like to add too? (Please use the line number + 1)");
                        int blogNumber = Convert.ToInt32(Console.ReadLine());
                        var blog = context.Blogs.Where(x => x.BlogId == blogNumber).FirstOrDefault();
                        var postsList = context.Posts.Where(x => x.BlogId == blogNumber).ToList();


                        Console.WriteLine("Please enter a post title:");
                        var title = Console.ReadLine();
                        Console.WriteLine("Please write the post's content:");
                        var content = Console.ReadLine();

                        var post = new Post();
                        post.Title = title;
                        post.Content = content;
                        post.BlogId = Convert.ToInt32(blogNumber);

                        context.Posts.Add(post);
                        context.SaveChanges();

                        Console.WriteLine($"Thank you for adding a post to {blog.Name}");
                    }
                 } catch
                    {
                        Console.WriteLine("An error has occured. Please restart.");
                    }


                else if (choice == "0")
                {
                    // Exit Program
                    Console.WriteLine("Exiting program.");
                    break;
                }
                else if (choice != "1" || choice != "2" || choice != "3" || choice != "4")
                {
                    Console.WriteLine("An error has occured, please restart the program and try again.");
                    break;
                }
            } 
            while (choice == "1" || choice == "2" || choice == "3" || choice == "4");
        }
    }
}