﻿using System;
using System.Web.Mvc;
using NSnippets.GroupedMultiSelection.Models;

namespace NSnippets.GroupedMultiSelection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ViewModel viewModel)
        {
            return View(new ViewModel
            {
                Ints = new MultiSelection<int>(
                    !viewModel.ContainsUserInput,
                    new MultiSelectionItem<int>("From 1 to 3", 1, 2, 3),
                    new MultiSelectionItem<int>("From 5 to 8", 5, 6, 7, 8),
                    new MultiSelectionItem<int>("Just 9", 9)),
                Strings = new MultiSelection<string>(
                    viewModel.Strings.Selected,
                    new MultiSelectionItem<string>("Just A", "A"),
                    new MultiSelectionItem<string>("Z and Y", "Z", "Y")),
                Days = new MultiSelection<DayOfWeek>(
                    viewModel.Days.Selected,
                    new MultiSelectionItem<DayOfWeek>("Monday and Friday", DayOfWeek.Monday, DayOfWeek.Friday),
                    new MultiSelectionItem<DayOfWeek>("Sunday", DayOfWeek.Sunday),
                    new MultiSelectionItem<DayOfWeek>("Thursday", DayOfWeek.Thursday))
            });
        }
    }
}