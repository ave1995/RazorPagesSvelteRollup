namespace MVCSvelteAddRazorPages.Pages;

public partial class Urls
{
    public const string  TestUrl = "/test";
}

public class TestModel : PageModel 
{
    public void OnGet()
    {
        // Add data to ViewData
        ViewData["Hello"] = "Hello from ViewData!";
        ViewData["Number"] = 42;
    }
}
