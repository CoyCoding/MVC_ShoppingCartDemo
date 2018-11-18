using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models.ViewModel
{
    public class CategoryViewModel : ICategoryViewModel
    {
        public string CurrentCategory { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}