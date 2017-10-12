using BlogSystem.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Model
{
    public class Category: DataModel
    {
        public Category()
        {

        }

        public Category(string name)
        {
            this.Name = name;
        }

        [Required]
        public string Name { get; set; }
    }
}
