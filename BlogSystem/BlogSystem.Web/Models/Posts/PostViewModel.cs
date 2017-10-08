using BlogSystem.Data.Model;
using BlogSystem.Web.Infrastructure;
using System;
using AutoMapper;

namespace BlogSystem.Web.Models.Posts
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(postViewModel => postViewModel.AuthorEmail, cfg => cfg.MapFrom(post => post.Author.Email))
                .ForMember(postViewModel => postViewModel.PostedOn, cfg => cfg.MapFrom(post => post.CreatedOn));
        }
    }
}