using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NSnippets.GroupedMultiSelection.Models
{
    public class MultiSelection<T> : MultiSelectList
    {
        private readonly IList<T> selected;

        public MultiSelection(IList<string> groups)
            : base(groups)
        {
            selected = groups.SelectMany(group => new MultiSelectionItem<T>(group).Values).ToList();
        }

        public MultiSelection(bool allSelected, params MultiSelectionItem<T>[] items)
            : this(allSelected ? items.SelectMany(x => x.Values).ToList() : new List<T>(), items)
        {
        }

        public MultiSelection(params MultiSelectionItem<T>[] items)
            : base(items, "Value", "Text", items.Where(x => x.Selected).Select(x => x.Value))
        {
            selected = items.Where(x => x.Selected).SelectMany(x => x.Values).ToList();
        }

        public MultiSelection(IList<T> selected, params MultiSelectionItem<T>[] items)
            : base(items, "Value", "Text", Update(selected, items).Where(x => x.Selected).Select(x => x.Value))
        {
            this.selected = selected == null ? new List<T>() : selected.ToList();
        }

        public IList<T> Selected { get { return selected; } }

        private static IEnumerable<MultiSelectionItem<T>> Update(IList<T> selected, MultiSelectionItem<T>[] items)
        {
            if (selected != null)
            {
                foreach (var item in items)
                {
                    item.Selected = item.Values.Intersect(selected).Count() == item.Values.Count;
                }
            }

            return items;
        }
    }
}