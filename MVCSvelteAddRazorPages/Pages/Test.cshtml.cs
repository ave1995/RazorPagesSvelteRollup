using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace MVCSvelteAddRazorPages.Pages;

public partial class Urls
{
    public const string TestUrl = "/test";
}

public class TestModel : PageModel
{
    public void OnGet()
    {
        // Add data to ViewData
        ViewData["Hello"] = "Hello from ViewData!";
        ViewData["Number"] = 42;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var requestBody = await reader.ReadToEndAsync();
                var jsonData = JsonSerializer.Deserialize<MyModel>(requestBody);

                if (jsonData != null)
                {
                    // Handle the data, e.g., jsonData.PropertyName
                    Console.WriteLine($"Received data: {jsonData.Username}");
                }
            }

            return RedirectToPage("/Test");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message, "Error handling POST request");
            return BadRequest();
        }
    }
}

public class MyModel
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
