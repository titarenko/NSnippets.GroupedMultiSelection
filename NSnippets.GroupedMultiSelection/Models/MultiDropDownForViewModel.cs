using System.Web.Mvc;

namespace NSnippets.GroupedMultiSelection.Models
{
    public class MultiDropDownForViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public MultiSelectList List { get; set; }
    }
}