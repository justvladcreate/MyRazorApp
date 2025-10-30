using ExampleApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product MyProduct { get; set; } = new Product();

        public string MessageType { get; set; } = "info";

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                if (MyProduct.Name == "" || MyProduct.Code == "" || MyProduct.Price < 0 || MyProduct.Quantity < 0)
                {
                    TempData["Response"] = "Ошибка: Все поля должны быть заполнены корректно";
                    MessageType = "danger";
                    return Page();
                }

                if (FakeDatabase._products.Count == 0)
                {
                    MyProduct.Id = 1;
                }
                else
                {
                    int maxId = FakeDatabase._products.Max(x => x.Id);
                    MyProduct.Id = maxId + 1;
                }

                FakeDatabase._products.Add(MyProduct);
                TempData["Response"] = "Товар успешно добавлен!";
                MessageType = "success";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["Response"] = $"Ошибка при добавлении товара: {ex.Message}";
                MessageType = "danger";
                return Page();
            }
        }
    }
}

