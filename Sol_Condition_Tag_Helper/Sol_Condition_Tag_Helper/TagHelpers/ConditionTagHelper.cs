using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sol_Condition_Tag_Helper.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("div-condition")]
    public class ConditionTagHelper : TagHelper
    {
        #region Declaration
        private const string ConditionAttributeName = "mark-condition";
        private const string IfHtmlContentAttributeName = "if-html";
        private const string ElseHtmlContentAttributeName = "else-html";

        private IHtmlHelper htmlHelper = null;
        #endregion

        #region Constructor
        public ConditionTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }
        #endregion

        #region Property
        [HtmlAttributeName(ConditionAttributeName)]
        public bool Condition { get; set; }

        [HtmlAttributeName(IfHtmlContentAttributeName)]
        public Object IfHtml { get; set; }

        [HtmlAttributeName(ElseHtmlContentAttributeName)]
        public Object ElseHtml { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        #endregion 

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var conditionTagHelperModelObj = new ConditionTagHelpersModel()
            {
                MarkCondition = Condition,
                If = IfHtml,
                Else = ElseHtml
            };

            var content = await htmlHelper.PartialAsync("~/Views/Shared/_ConditionTagHelperPartialView.cshtml", conditionTagHelperModelObj);

            output.Content.SetHtmlContent(content);

            //return base.ProcessAsync(context, output);
        }
    }
}
