namespace SistemaDeBlogs.Models.Entities
{
    public class Post
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}
