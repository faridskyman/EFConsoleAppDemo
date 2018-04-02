using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EN_Demo_one.Models;

namespace EN_Demo_one
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            do
            {
                userInput = DisplayMenu();

                switch(userInput)
                {
                    case 1:
                        AddBlog();
                        break;
                    case 2:
                        ViewBlogs();
                        break;
                    case 3:
                        AddPost();
                        break;
                    case 4:
                        AddUser();
                        break;
                    case 5:
                        ViewUsers();
                        break;
                    default:
                        ViewBlogs();
                        break;
                }
            } while (userInput != 9);

        }


        static public int DisplayMenu()
        {
            wl("");
            wl("---------------");
            wl("Blogging Menu");
            wl("---------------");
            wl("1. Add Blog");
            wl("2. View Blogs");
            wl("3. Add Post");
            wl("4. Add User");
            wl("5. View User");
            wl("9. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        private static void AddUser()
        {
            using (var db = new BloggingContext())
            {

                var _username = GetUserInput_String("Enter in UserID: ");
                var _displayName = GetUserInput_String("Enter in Display Name: ");

                var _user = new User { Username = _username, DisplayName = _displayName };

                db.Users.Add(_user);
                db.SaveChanges();
                wl("[+] User successfully added.");
                wl("");

            }
        }

        private static void AddPost()
        {
            using (var db = new BloggingContext())
            {
                var _blogID = GetUserInput_Integer("Enter BlogID: ");
                var _title = GetUserInput_String("Enter in Title: ");
                var _content = GetUserInput_String("Enter in content: ");

                var post = new Post { BlogId = _blogID, Title = _title, Content = _content };

                db.Posts.Add(post);
                db.SaveChanges();
                wl("[+] Post successfully added.");
                wl("");

            }
        }

        private static void ViewBlogs()
        {
            using (var db = new BloggingContext())
            {
                //display blog
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                wl("***Showing all blogs in the db:**");

                foreach (var item in query)
                {
                    wl(string.Format("* {0} - {1}",item.BlogId,item.Name));
                }

                
                //wl("press any key to exit...");
                //Console.ReadKey();
            }
        }

        private static void ViewUsers()
        {
            using (var db = new BloggingContext())
            {
                //display blog
                var query = from u in db.Users
                            orderby u.Username
                            select u;

                wl("***Showing all users in the db:**");

                foreach (var usr in query)
                {
                    wl(string.Format("* {0} - {1}", usr.Username, usr.DisplayName ));
                }

            }
        }

        private static void AddBlog()
        {
            using (var db = new BloggingContext())
            {
                //create and save blog
                Console.Write("Enter name for New blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };

                db.Blogs.Add(blog);
                db.SaveChanges();

                wl("[+] Blog successfully added.");
                wl("");
            }

        }




        private static void wl(string v)
        {
            Console.WriteLine(v);
        }
        private static int GetUserInput_Integer(string v)
        {
            Console.Write(v);
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        private static string GetUserInput_String(string v)
        {
            Console.Write(v);
            var result = Console.ReadLine();
            return result;
        }

    }


    

}
