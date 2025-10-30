using ExampleApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages.Products
{
    public class DeleteModel : PageModel
    {
        public Product? Product { get; set; }

        public void OnGet(int Id)
        {
            try
            {
                Product = FakeDatabase._products.Where(x => x.Id == Id).FirstOrDefault();
                
                if (Product == null)
                {
                    TempData["Response"] = "Товар с таким ID не найден!";
                    TempData["ResponseType"] = "danger";
                }
            }
            catch (Exception ex)
            {
                TempData["Response"] = $"Ошибка при загрузке товара: {ex.Message}";
                TempData["ResponseType"] = "danger";
            }
        }

        public IActionResult OnPost(int Id)
        {
            try
            {
                var product = FakeDatabase._products.Where(x => x.Id == Id).FirstOrDefault();
                
                if (product == null)
                {
                    TempData["Response"] = "Ошибка: Товар с таким ID не найден!";
                    TempData["ResponseType"] = "danger";
                    throw new Exception("Товар с таким ID не найден в базе данных");
                }

                FakeDatabase._products.Remove(product);
                TempData["Response"] = "Товар успешно удалён!";
                TempData["ResponseType"] = "success";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["Response"] = $"Ошибка при удалении товара: {ex.Message}";
                TempData["ResponseType"] = "danger";
                throw;
            }
        }
    }
}

