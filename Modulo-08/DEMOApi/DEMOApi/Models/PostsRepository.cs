namespace DEMOApi.Models
{
    public class PostsRepository : IPostsRepository
    {
        private static Dictionary<int, Post> Posts = new Dictionary<int, Post>()
        {
            [1] = new Post { Id = 1, Author="Peter Parker", Title="Web thoughts", Body = "Post about webs and spiders"},
            [2] = new Post { Id = 2, Author="Bruce Wayne", Title="How bat orientation works", Body = "Post about bats orientation"},
            [3] = new Post { Id = 3, Author="Clark Kent", Title="Krypton tales", Body = "Post about Krypton and its people"},
            [4] = new Post { Id = 4, Author="Steve Rogers", Title="history of America", Body = "Post about history"}
        };

        public IEnumerable<Post> All()
        {
            return Posts.Values.ToList();
        }

        public bool Create(Post post)
        {
            return Posts.TryAdd(post.Id, post);
        }

        public Post GetById(int id)
        {
            Posts.TryGetValue(id, out var post);
            return post;
        }
    }
}
