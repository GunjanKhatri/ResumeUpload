using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobApplyMVC.Helper
{
    public static class CustomHelper
    {
        public static IHtmlString File(this HtmlHelper helper)
        {
            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("id", "fileId");
            tb.Attributes.Add("name", "fileId");
            tb.Attributes.Add("type", "file");
            return new MvcHtmlString(tb.ToString());
        }
    }
}