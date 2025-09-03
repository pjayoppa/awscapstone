namespace RcbcRequests.Models;

public class Request
{
    public int RequestID { get; set; }
    public int CreatedBy { get; set; }
    public string RequestType { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; // Pending | Approved | Denied
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
