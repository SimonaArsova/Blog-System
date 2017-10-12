using BlogSystem.Data.Model;
using BlogSystem.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models.Categories
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}