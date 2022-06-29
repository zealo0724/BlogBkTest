using Microsoft.EntityFrameworkCore;
using MyTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Data
{
    public class AdminRepository: IAdminRepository
    {
        private MyDbContext _dbContext;
        public AdminRepository(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<List<Blog>> GetBlogs() 
        {
            return await _dbContext.Blog
                .Include(x => x.User)
                //.OrderByDescending(x => x.CreatedDate)
                .ToListAsync();    
        }

        public async Task<Blog> AddBlog(Blog blog)
        {
            var storedBlog = await _dbContext.Blog.AddAsync(blog);
            return storedBlog.Entity;
        }

        public bool DeleteBlog(Blog blog)
        {
            var dbBlog = _dbContext.Blog.FirstOrDefault(x => x.Id == blog.Id);
            if (dbBlog != null)
            {
                _dbContext.Blog.Remove(blog);
            }
            return true;
        }

        public async Task<List<Comment>> GetComments()
        {
            return await _dbContext.Comment
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            var storedEntity = await _dbContext.Comment.AddAsync(comment);
            return storedEntity.Entity;
        }

        public bool DeleteComment(Comment comment)
        {
            var dbEntity = _dbContext.Comment.FirstOrDefault(x => x.Id == comment.Id);
            if (dbEntity != null)
            {
                _dbContext.Comment.Remove(dbEntity);
            }
            return true;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.User
                .ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            var storedEntity = await _dbContext.User.AddAsync(user);
            return storedEntity.Entity;
        }

        public bool DeleteUser(User user)
        {
            var dbEntity = _dbContext.User.FirstOrDefault(x => x.Id == user.Id);
            if (dbEntity != null)
            {
                _dbContext.User.Remove(dbEntity);
            }
            return true;
        }
    }
}
