using System.Web.Mvc;
using NSnippets.GroupedMultiSelection.Models;
using NSnippets.GroupedMultiSelection.Infrastructure;

namespace NSnippets.GroupedMultiSelection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ViewModel viewModel)
        {
            return View(new ViewModel
            {
                Ints = new MultiSelection<int>(
                    viewModel.Ints.SafeGet(x => x.Selected),
                    new MultiSelectionItem<int>("From 1 to 3", 1, 2, 3),
                    new MultiSelectionItem<int>("From 5 to 8", 5, 6, 7, 8),
                    new MultiSelectionItem<int>("Just 9", 9)),
                Strings = new MultiSelection<string>(
                    viewModel.Strings.SafeGet(x => x.Selected),
                    new MultiSelectionItem<string>("Just A", "A"),
                    new MultiSelectionItem<string>("Z and Y", "Z", "Y"))
            });
        }
    }
}