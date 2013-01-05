namespace NSnippets.GroupedMultiSelection.Models
{
    public class ViewModel
    {
        public MultiSelection<int> Ints { get; set; }

        public MultiSelection<string> Strings { get; set; }

        public ViewModel()
        {
            Ints = new MultiSelection<int>();
            Strings = new MultiSelection<string>();
        }
    }
}