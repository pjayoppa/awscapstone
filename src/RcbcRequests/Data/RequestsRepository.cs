using Dapper;
using RcbcRequests.Models;

namespace RcbcRequests.Data;

public class RequestsRepository
{
    private readonly Sql _sql;
    public RequestsRepository(Sql sql) => _sql = sql;

    public async Task<IEnumerable<Request>> GetAllAsync()
    {
        using var db = _sql.Open();
        return await db.QueryAsync<Request>("SELECT * FROM Requests ORDER BY CreatedAt DESC");
    }

    public async Task<Request?> GetAsync(int id)
    {
        using var db = _sql.Open();
        return await db.QueryFirstOrDefaultAsync<Request>(
            "SELECT * FROM Requests WHERE RequestID=@id", new { id });
    }

    public async Task<int> CreateAsync(Request r)
    {
        using var db = _sql.Open();
        var sql = @"
            INSERT INTO Requests (CreatedBy, RequestType, Details, Status, CreatedAt)
            VALUES (@CreatedBy, @RequestType, @Details, 'Pending', SYSUTCDATETIME());
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
        return await db.ExecuteScalarAsync<int>(sql, r);
    }

    public async Task<int> UpdateAsync(Request r)
    {
        using var db = _sql.Open();
        var sql = @"
            UPDATE Requests
            SET RequestType=@RequestType, Details=@Details, UpdatedAt=SYSUTCDATETIME()
            WHERE RequestID=@RequestID";
        return await db.ExecuteAsync(sql, r);
    }

    public async Task<int> SetStatusAsync(int id, string status)
    {
        using var db = _sql.Open();
        var sql = "UPDATE Requests SET Status=@status, UpdatedAt=SYSUTCDATETIME() WHERE RequestID=@id";
        return await db.ExecuteAsync(sql, new { id, status });
    }
}
