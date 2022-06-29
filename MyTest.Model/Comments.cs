namespace MyTest.Model
{
    public class Comment
    {
        public string Id { get; set; }
        public string CommentContent { get; set; }
        public string BlogId { get; set; }
        public Blog Blog { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatetDate { get;}
    }
}