using EF6.TagWith;
using System;
using System.Data.Entity.Infrastructure.Interception;
using System.Threading.Tasks;

namespace EfExample
{
	internal class Program
	{
		public static async Task Main(string[] args)
		{
			//configuration for Tagging and DbInterception
			TagWith.Initialize<SqlServerTagger>();
			DbInterception.Add(new DbInterceptor());

			BloggingContext db = new BloggingContext();
			db.Database.Log = Console.Write;

			BlogService blogService = new BlogService(db);

			var blogs = await blogService.GetAllBlogs();

			var b = await blogService.GetBlogById(10);

			Console.ReadKey();
		}
	}
}
