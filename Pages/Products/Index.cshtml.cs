using ExampleApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> localProducts = new List<Product>();
        public string? SearchText { get; set; }
        public void OnGet(string? searchText, string price = "", string income = "")
        {
            SearchText = searchText;
            localProducts = FakeDatabase._products;
            if (!String.IsNullOrEmpty(searchText))
            {
                localProducts = localProducts.Where(x => x.Name == searchText).ToList();
            }
            else
            {
                localProducts = localProducts.ToList();
            }
            
            if (price == "on")
            {
                localProducts = localProducts.OrderByDescending(x => x.Price).ToList();
            }
            if (income == "on")
            {
                localProducts = localProducts.OrderByDescending(x => x.Income).ToList();
            }

        }
    }
}
