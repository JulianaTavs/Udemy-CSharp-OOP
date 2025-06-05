namespace Ex18OutraVersao
{
    class Post
    {
        public DateTime Moment { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Post()
        {

        }

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
            string commentsString = "Comments:\n";
            foreach (var comment in Comments)
            {
                commentsString += "- " + comment.Text + "\n";
            }
            return  Title + "\n" +
                    Likes.ToString() + " Likes - " + Moment.ToString() + "\n" +
                    Content + "\n" +
                   commentsString;
            
        }
    }
}