using Dapper;
using RcbcRequests.Models;

namespace RcbcRequests.Data;

public class UsersRepository
{
    private readonly Sql _sql;
    public UsersRepository(Sql sql) => _sql = sql;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var db = _sql.Open();
        return await db.QueryAsync<User>("SELECT * FROM Users ORDER BY Username");
    }
}
