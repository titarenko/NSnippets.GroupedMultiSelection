using System;

namespace NSnippets.GroupedMultiSelection.Models
{
    public class ViewModel
    {
        public MultiSelection<int> Ints { get; set; }

        public MultiSelection<string> Strings { get; set; }

        public MultiSelection<DayOfWeek> Days { get; set; }

        public ViewModel()
        {
            Ints = new MultiSelection<int>();
            Strings = new MultiSelection<string>();
            Days = new MultiSelection<DayOfWeek>();
        }

        public bool ContainsUserInput { get; set; }
    }
}