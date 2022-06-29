namespace MyTest.Model
{
    public class Blog
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get;}
    }
}