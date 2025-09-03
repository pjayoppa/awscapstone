using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RcbcRequests.Data;
using RcbcRequests.Models;

public class EditRequestModel : PageModel
{
    private readonly RequestsRepository _repo;
    public EditRequestModel(RequestsRepository repo) => _repo = repo;

    [BindProperty]
    public Request Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var r = await _repo.GetAsync(id);
        if (r == null) return RedirectToPage("/Requests/Index");
        Input = r;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        await _repo.UpdateAsync(Input);
        return RedirectToPage("/Requests/Index");
    }
}
