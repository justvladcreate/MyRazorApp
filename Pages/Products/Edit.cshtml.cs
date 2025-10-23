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
            var localproduct = FakeDatabase._products.Where(x => x.Id == Id).FirstOrDefault();
            if (localproduct != null)
            {
                MyProduct = localproduct;
            }
        }

        public IActionResult OnPost()
        {
            var localproduct = FakeDatabase._products.Where(x => x.Id == MyProduct.Id).FirstOrDefault();
            if (localproduct != null && MyProduct.Name != "�����")
            {
                localproduct.Name = MyProduct.Name;
                localproduct.Code = MyProduct.Code;
                localproduct.Price = MyProduct.Price;
                localproduct.Quantity = MyProduct.Quantity;
                TempData["Response"] = "����� ��������������";
            }
            else
            {
                TempData["Response"] = "����� �� ��������";
            }
            return RedirectToPage("Index");
        }
    }
}
