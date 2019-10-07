using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Viajanet.Front.Pages
{
    public class CheckoutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
    }
}
