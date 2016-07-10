using HtmlTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftBookingTest.Web.Helpers
{
    public class UIRatingTag : HtmlTag
    {
        public UIRatingTag(string model) : base("div")
        {
            Attr("data-uib-rating", "");
            Attr("ng-model", model);
        }

        public UIRatingTag Max(int max)
        {
            Attr("max", max);
            return this;
        }

        public UIRatingTag NgClick(string action)
        {
            Attr("ng-click", action);
            return this;
        }
    }
}