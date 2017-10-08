using System;

namespace BlogSystem.Web.Models.Posts
{
    public class PostViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime PostedOn { get; set; }
    }
}