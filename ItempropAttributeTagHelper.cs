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
        public ModelExpression? PropertyName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var itemProp = context.AllAttributes["itemprop"];
            var modelExpression = itemProp.Value as ModelExpression;
            if (modelExpression == null || modelExpression.Model == null) return;
            var name = modelExpression.Name;
            var split = name.Split('.');
            output.Attributes.SetAttribute("itemprop", split.Last());
            var val = modelExpression.Model as string;
            if (val != null)
            {
                output.Content.SetHtmlContent(modelExpression.Model.ToString());

            }


        }
    }
}
