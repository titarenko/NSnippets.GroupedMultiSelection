using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace NSnippets.GroupedMultiSelection.Infrastructure
{
    public class MultiSelectionModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var modelName = bindingContext.ModelName;
            var valueProvider = bindingContext.ValueProvider;
            var groups = (string[]) valueProvider.GetValue(modelName).RawValue;

            var ctor = bindingContext.ModelType.GetConstructors()
                .FirstOrDefault(x =>
                {
                    var parameters = x.GetParameters();
                    return parameters.Length == 1 && parameters[0].ParameterType == typeof (IList<string>);
                });

            if (ctor == null)
            {
                throw new ApplicationException("Can't find appropriate ctor.");
            }

            return ctor.Invoke(new object[] {groups});
        }
    }
}