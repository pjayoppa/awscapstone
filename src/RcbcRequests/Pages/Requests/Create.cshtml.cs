using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RcbcRequests.Data;
using RcbcRequests.Models;

public class CreateRequestModel : PageModel
{
    private readonly RequestsRepository _repo;
    public CreateRequestModel(RequestsRepository repo) => _repo = repo;

    [BindProperty]
    public Request Input { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        await _repo.CreateAsync(Input);
        return RedirectToPage("/Requests/Index");
    }
}
