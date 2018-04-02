using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EN_Demo_one.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }


    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog{ get; set; }
    }


    public class User
    {
        [Key]
        [StringLength(64, ErrorMessage = "username length should not go beyond 64 char")]
        public string Username { get; set; }
        [StringLength(256, ErrorMessage = "the length of display name cannot exceed 256 char")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "DisplayName Required")]
        public string DisplayName { get; set; }

    }

    public class BloggingContext: DbContext
    {
        public BloggingContext(): base("name=SchoolDBConnectionString")
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }

    }

}
