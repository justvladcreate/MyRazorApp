using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleApplication.Pages
{
    public class IndexModel : PageModel
    {
        public string MyText = "";
        public void OnGet()
        {
            int a = 5;
            int b = 13;
            int sum = a + b;

            MyText = $"Я умею считать: {sum}";
        }
    }
}
