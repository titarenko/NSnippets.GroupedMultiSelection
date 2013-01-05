using System;

namespace NSnippets.GroupedMultiSelection.Infrastructure
{
    public static class SafeExtensions
    {
        public static T SafeGet<TModel, T>(this TModel model, Func<TModel, T> selector) where TModel : class
        {
            return model == null ? default(T) : selector(model);
        }

        public static void SafeDo<TModel>(this TModel model, Action<TModel> action) where TModel : class
        {
            if (model != null)
            {
                action(model);
            }
        }
    }
}