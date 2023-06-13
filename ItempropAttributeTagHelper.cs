using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace micoredata
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes = "itemprop")]
    public class ItempropAttributeTagHelper : TagHelper
    {
        [HtmlAttributeName("itemprop")]
        public ModelExpression PropertyName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var itemProp = context.AllAttributes["itemprop"];
            var val = itemProp.Value as ModelExpression;
            if (val == null) return;
            output.Content.SetHtmlContent(val.Model.ToString());
            output.Attributes.SetAttribute("itemprop", val.Name);

        }
    }
}
