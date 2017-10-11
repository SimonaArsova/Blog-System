using AutoMapper;
using BlogSystem.Data.Model;
using BlogSystem.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models.Posts
{
    public class CreatePostViewModel : IMapFrom<Post>
    {
        public CreatePostViewModel()
        {

        }

        public CreatePostViewModel(Guid id, string title, string content)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
        
    }
}