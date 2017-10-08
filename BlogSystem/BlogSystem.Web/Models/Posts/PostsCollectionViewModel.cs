using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models.Posts
{
    public class PostsCollectionViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}