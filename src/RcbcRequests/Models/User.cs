namespace RcbcRequests.Models;

public class User
{
    public int UserID { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = "Staff"; // Staff | Supervisor
}
