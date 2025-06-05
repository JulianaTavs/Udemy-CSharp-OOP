using System.Text;

namespace Ex18AgainParaTreinar
{
    class Post
    {
        public DateTime Moment { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Post() { }
        public Post(DateTime moment, string title, string content, int likes)
        {
            Moment = moment;
            Title = title;
            Content = content;
            Likes = likes;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Dados do Post:\n");
            sb.AppendLine("Date: " + Moment.ToString());
            sb.AppendLine("Title: " + Title);
            sb.AppendLine("Content: " + Content);
            sb.AppendLine("Likes: " + Likes.ToString());
            sb.AppendLine("Comments: ");

            foreach (Comment c in Comments)
            {
                sb.AppendLine("- " + c.Text); 
            }
            
            return sb.ToString();
        }
    }
}