using BlogSystem.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Model
{
    public class Post : DataModel
    {
        public Post()
        {

        }

        public Post(string title, string content, string image, User author)
        {
            this.Title = title;
            this.Content = content;
            this.Image = image;
            this.Author = author;
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Url]
        public string Image { get; set; }

        public User Author { get; set; }
        
    }
}
