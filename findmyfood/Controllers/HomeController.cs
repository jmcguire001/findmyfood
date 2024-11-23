using findmyfood.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace findmyfood.Controllers
{
    public class HomeController : Controller
    {
        private readonly FindmyfoodContext _context;

        public HomeController(FindmyfoodContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ItemDetails()
        {
            return View();
        }

        public IActionResult Search(string query)
        {
            var results = _context.Items
                .Join(_context.Stores,
                    i => i.StoreId,
                    s => s.StoreId,
                    (i, s) => new { Item = i, Store = s })
                .Where(g => g.Item.ItemName.Contains(query) || g.Item.Description.Contains(query) || g.Item.ItemCat.Contains(query))
                .Select(g => new SearchResultViewModel
                {
                    ItemName = g.Item.ItemName,
                    Category = g.Item.ItemCat,
                    Description = g.Item.Description,
                    ImageUrl = g.Item.ImageUrl,
                    Price = g.Item.Price,
                    StoreName = g.Store.StoreName,
                    City = g.Store.City
                })
                .ToList();

            return View("Search", results);
        }

        public IActionResult Optimize(string priceFilter, int? storeFilter, string cityFilter)
        {
            // Start with a join query between Items and Stores
            var query = _context.Items
                .Join(_context.Stores,
                    i => i.StoreId,
                    s => s.StoreId,
                    (i, s) => new { Item = i, Store = s });

            // Apply price filtering
            if (!string.IsNullOrEmpty(priceFilter))
            {
                if (priceFilter == "low")
                {
                    query = query.OrderBy(g => g.Item.Price);
                }
                else if (priceFilter == "high")
                {
                    query = query.OrderByDescending(g => g.Item.Price);
                }
            }
            else
            {
                query = query.OrderBy(g => g.Item.Price); // Default sorting by price ascending
            }

            // Apply store filtering
            if (storeFilter.HasValue)
            {
                query = query.Where(g => g.Item.StoreId == storeFilter.Value);
            }

            // Apply city filtering
            if (!string.IsNullOrEmpty(cityFilter))
            {
                query = query.Where(g => g.Store.City.ToLower() == cityFilter.ToLower());
            }

            // Final projection to the view model
            var results = query
                .Select(g => new SearchResultViewModel
                {
                    ItemName = g.Item.ItemName,
                    Category = g.Item.ItemCat,
                    Description = g.Item.Description,
                    ImageUrl = g.Item.ImageUrl,
                    Price = g.Item.Price,
                    StoreName = g.Store.StoreName,
                    City = g.Store.City
                })
                .ToList();

            // Populate the stores dropdown with distinct StoreNames
            ViewBag.Stores = _context.Stores
                .GroupBy(s => s.StoreName)
                .Select(g => new { StoreName = g.Key, StoreId = g.FirstOrDefault().StoreId })
                .ToList();
            // Populate the cities dropdown with distinct city names
            ViewBag.Cities = _context.Stores.Select(s => s.City).Distinct().ToList();

            return View("Optimize", results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
