using BlogSystem.Data.Model;
using BlogSystem.Web.Infrastructure;
using System;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Web.Models.Posts
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {

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

        public string AuthorEmail { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(postViewModel => postViewModel.AuthorEmail, cfg => cfg.MapFrom(post => post.Author.Email))
                .ForMember(postViewModel => postViewModel.PostedOn, cfg => cfg.MapFrom(post => post.CreatedOn))
                .ForMember(postViewModel => postViewModel.Category, cfg => cfg.MapFrom(post => post.Category.Name));
        }
    }
}