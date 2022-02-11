namespace TwitterClone.Models
{
    public class Tweets
    {
        public int Id { get; set; }
        public int? userId { get; set; }

        public string? username { get; set; }

        public string? tweet { get; set; }

        public DateTime? dateTweeted { get; set; } = default(DateTime?);

        public string? profileName { get; set; }

        public string? picture { get; set; }

        public int? heart { get; set; }

        public int? retweet { get; set; }

        public int? reply { get; set; }
    }
}
