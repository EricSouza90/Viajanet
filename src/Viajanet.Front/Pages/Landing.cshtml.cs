using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Viajanet.Front.Pages
{
    public class Landing : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
