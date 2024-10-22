using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController: ControllerBase
    {
        private readonly DataContext _context;

        public PostsController(DataContext context)
        {
            this._context = context;
        }

        // GET api/posts
        [HttpGet(Name = "GetPosts")]
        public ActionResult<List<Post>> Get()
        {
            return this._context.Posts.ToList();
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Post> Get(Guid id)
        {
            var post = this._context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost(Name = "Create")]
        public ActionResult<Post> Create([FromBody] Post request)
        {
            var post = new Post
            {
                Id = request.Id,
                Title = request.Title,
                Body = request.Body,
                Date = request.Date
            };

            _context.Posts.Add(post);

            var success = _context.SaveChanges() > 0;

            if (success)
            {
                return Ok(post);
            }

            throw new Exception("Error creating post"); 
        }

        [HttpPut(Name = "Update")]
        public ActionResult<Post> Update([FromBody] Post request)
        {
            var post = _context.Posts.Find(request.Id);
            if (post == null)
            {
                return NotFound();
            }
            post.Title = request.Title;
            post.Body = request.Body;
            post.Date = request.Date;
            var success = _context.SaveChanges() > 0;
            if (success)
            {
                return Ok(post);
            }
            throw new Exception("Error updating post");
        }
    }
}