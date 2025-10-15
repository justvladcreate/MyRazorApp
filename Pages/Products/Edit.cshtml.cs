using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public int AmountProduct { get; set; } = 0;
        [BindProperty]
        public string ColourProduct { get; set; } = "";
        public string Message { get; set; } = "";
        public void OnGet()
        {
            AmountProduct = 5;
            ColourProduct = "Зелёный";
        }

        public void OnPost()
        {
            var amount = AmountProduct;
            var colour = ColourProduct;
            Message = $"Сообщение для сохранения? Количество: {amount} Цвет: {colour}";


        }
    }
}
