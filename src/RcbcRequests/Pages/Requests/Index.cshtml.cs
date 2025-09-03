using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RcbcRequests.Data;
using RcbcRequests.Models;

public class RequestsIndexModel : PageModel
{
    private readonly RequestsRepository _repo;
    public RequestsIndexModel(RequestsRepository repo) => _repo = repo;

    public IEnumerable<Request> Items { get; private set; } = Enumerable.Empty<Request>();

    public async Task OnGet() => Items = await _repo.GetAllAsync();

    public async Task<IActionResult> OnPostApprove(int id)
    {
        await _repo.SetStatusAsync(id, "Approved");
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeny(int id)
    {
        await _repo.SetStatusAsync(id, "Denied");
        return RedirectToPage();
    }
}
