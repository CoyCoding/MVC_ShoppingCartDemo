using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartDemo.Models.HtmlHelpers
{
    public static class PaginationHelper
    {
        public static MvcHtmlString PaginationLinks(this HtmlHelper html, Pagination pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for(int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder htmlTag = new TagBuilder("a");
                htmlTag.MergeAttribute("href", pageUrl(i));
                htmlTag.InnerHtml = i.ToString();
                if(i == pageInfo.CurrentPage)
                {
                    htmlTag.AddCssClass("selected");
                    htmlTag.AddCssClass("btn-primary");
                }
                htmlTag.AddCssClass("btn btn-default");
                result.Append(htmlTag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}