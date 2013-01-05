using System;
using System.Web.Mvc;
using NSnippets.GroupedMultiSelection.Models;

namespace NSnippets.GroupedMultiSelection.Infrastructure
{
    public class ExtendedBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return HasGenericTypeBase(bindingContext.ModelType, typeof (MultiSelection<>))
                       ? new MultiSelectionModelBinder().BindModel(controllerContext, bindingContext)
                       : base.BindModel(controllerContext, bindingContext);
        }

        private bool HasGenericTypeBase(Type type, Type genericType)
        {
            while (type != null && type != typeof(object))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }
    }
}