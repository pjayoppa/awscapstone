using System.Data;
using Microsoft.Data.SqlClient;

namespace RcbcRequests.Data;

public class Sql
{
    private readonly string _connStr;
    public Sql(string connStr) => _connStr = connStr;
    public IDbConnection Open() => new SqlConnection(_connStr);
}
