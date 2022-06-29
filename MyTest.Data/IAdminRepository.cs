using MyTest.Model;

namespace MyTest.Data
{
    public interface IAdminRepository
    {
        Task<List<Blog>> GetBlogs();
        Task<Blog> AddBlog(Blog blog);
        bool DeleteBlog(Blog blog);
        Task<List<Comment>> GetComments();
        Task<Comment> AddComment(Comment comment);
        bool DeleteComment(Comment comment);
        Task<List<User>> GetUsers();
        Task<User> AddUser(User user);
        bool DeleteUser(User user);
    }
}