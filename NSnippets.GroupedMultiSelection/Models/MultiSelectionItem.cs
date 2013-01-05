using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace NSnippets.GroupedMultiSelection.Models
{
    public class MultiSelectionItem<T> : SelectListItem
    {
        public const string Separator = ",";

        private readonly IList<T> values;

        public MultiSelectionItem(string group)
            : this(group, true, group.Split(Separator[0]).Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray())
        {
        }

        public MultiSelectionItem(string text, params T[] values)
            : this(text, false, values)
        {
        }

        public MultiSelectionItem(string text, bool selected, params T[] values)
        {
            this.values = values;
            Text = text;
            Value = string.Join(Separator, values);
            Selected = selected;
        }

        public IList<T> Values { get { return values; } }
    }
}