using AutoMapper;
using BlogSystem.Data.Model;
using BlogSystem.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Models.Posts
{
    public class CreatePostViewModel 
    {
        public CreatePostViewModel()
        {
        }

        public CreatePostViewModel(Guid id, string title, string category, string content, string image)
        {
            this.Id = id;
            this.Title = title;
            this.Category = category;
            this.Content = content;
            this.Image = image;
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image")]
        public string Image { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}