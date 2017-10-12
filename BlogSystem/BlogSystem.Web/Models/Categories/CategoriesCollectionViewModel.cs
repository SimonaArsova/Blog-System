using BlogSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Models.Categories
{
    public class CategoriesCollectionViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}