using BlogSystem.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data.Model
{
    public class Post : DataModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }
    }
}
