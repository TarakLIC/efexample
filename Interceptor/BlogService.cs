using EF6.TagWith;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EfExample
{
	public class BlogService
	{
		private IBloggingContext _context;

		public BlogService(IBloggingContext context)
		{
			_context = context;
		}

		public Blog AddBlog(string name, string url)
		{
			var blog = new Blog { Name = name, Url = url };
			_context.Blogs.Add(blog);
			_context.SaveChanges();

			return blog;
		}

		public async Task<List<Blog>> GetAllBlogs()
		{
			//Tagged so that DbInterceptor will add Hint
			var query = _context.Blogs.TagWith("with ROBUST PLAN Hint:");

			//var query = _context.Blogs.Include(b => b.Posts).OrderBy(b => b.Name);

			return await query.ToListAsync();
		}

		public async Task<Blog> GetBlogById(int id)
		{
			//No Hint Tagging, so no adding of Hint
			var blog = await _context.Blogs
				.Where(b => b.BlogId == id).TagWith("Blog by Id")
				.FirstOrDefaultAsync();

			return blog;
		}
	}
}
