namespace DEMOApi.Models
{
    public interface IPostsRepository
    {
        IEnumerable<Post> All();
        Post GetById(int id);
        bool Create(Post post);
    }
}
