using System.Data.Entity;

namespace EfExample
{
	public interface IBloggingContext
	{
		DbSet<Blog> Blogs { get; }
		//DbSet<Post> Posts { get; }
		int SaveChanges();
	}
	public class BloggingContext : DbContext, IBloggingContext
	{
		public BloggingContext() : base("JobContext")
		{

		}
		public DbSet<Blog> Blogs { get; set; }
		//public DbSet<Post> Posts { get; set; }
	}

	public class Blog
	{
		public int BlogId { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }

		//public List<Post> Posts { get; set; }
	}

	public class Post
	{
		public int PostId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public int BlogId { get; set; }
		public virtual Blog Blog { get; set; }
	}
}
