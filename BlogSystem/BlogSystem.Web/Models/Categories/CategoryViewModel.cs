using BlogSystem.Data.Model;
using BlogSystem.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models.Categories
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
                
        }

        public CategoryViewModel(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}