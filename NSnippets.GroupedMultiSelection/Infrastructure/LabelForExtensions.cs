using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace NSnippets.GroupedMultiSelection.Infrastructure
{
    public static class LabelForExtensions
    {
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string text, object htmlAttributes)
        {
            return LabelFor(html, expression, text, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string text, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = text ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            var tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}