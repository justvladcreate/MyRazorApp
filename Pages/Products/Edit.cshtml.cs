using ExampleApplication.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Product MyProduct { get; set; } = new Product();

        public void OnGet(int Id)
        {
            try
            {
                var localproduct = FakeDatabase._products.Where(x => x.Id == Id).FirstOrDefault();
                if (localproduct != null)
                {
                    MyProduct = localproduct;
                }
                else
                {
                    TempData["Response"] = "Товар с таким ID не найден!";
                    TempData["ResponseType"] = "danger";
                }
            }
            catch (Exception ex)
            {
                TempData["Response"] = $"Ошибка: {ex.Message}";
                TempData["ResponseType"] = "danger";
                throw;
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                var localproduct = FakeDatabase._products.Where(x => x.Id == MyProduct.Id).FirstOrDefault();
                
                if (localproduct == null)
                {
                    TempData["Response"] = "Ошибка: Товар с таким ID не найден!";
                    TempData["ResponseType"] = "danger";
                    throw new Exception("Товар с таким ID не найден в базе данных");
                }

                if (string.IsNullOrWhiteSpace(MyProduct.Name))
                {
                    TempData["Response"] = "Ошибка: Название товара не может быть пустым!";
                    TempData["ResponseType"] = "danger";
                    throw new Exception("Название товара не может быть пустым");
                }

                localproduct.Name = MyProduct.Name;
                localproduct.Code = MyProduct.Code;
                localproduct.Price = MyProduct.Price;
                localproduct.Quantity = MyProduct.Quantity;
                
                TempData["Response"] = "Товар успешно обновлён!";
                TempData["ResponseType"] = "success";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["Response"] = $"Ошибка при обновлении товара: {ex.Message}";
                TempData["ResponseType"] = "danger";
                throw;
            }
        }
    }
}
