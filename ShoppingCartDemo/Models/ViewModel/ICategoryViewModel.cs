using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDemo.Models.ViewModel
{
    public interface ICategoryViewModel
    {
       string CurrentCategory { get; set; }

       IEnumerable<string> Categories { get; set; }
    }
}
