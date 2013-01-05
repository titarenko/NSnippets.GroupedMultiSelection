using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using NSnippets.GroupedMultiSelection.Models;

namespace NSnippets.GroupedMultiSelection.Infrastructure
{
    public static class MultiDropDownListForExtensions
    {
        public static MvcHtmlString MultiDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> property) where TProperty : MultiSelectList
        {
            var list = property.Compile().Invoke(helper.ViewData.Model);
            var htmlFieldName = ExpressionHelper.GetExpressionText(property);
            var templateInfo = helper.ViewContext.ViewData.TemplateInfo;
            return helper.Partial("MultiDropDownForViewModel", new MultiDropDownForViewModel
            {
                Id = templateInfo.GetFullHtmlFieldId(htmlFieldName),
                Name = templateInfo.GetFullHtmlFieldName(htmlFieldName),
                List = list
            });
        }
    }
}