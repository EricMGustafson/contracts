using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracts.Models;
using Dapper;

namespace contracts.Repositories
{
  public class CompanysRepository
  {
    private readonly IDbConnection _db;

    public CompanysRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Company> Get()
    {
      string sql = @"SELECT * FROM companies";
      return _db.Query<Company>(sql).ToList();
    }

    internal Company Get(int id)
    {
      string sql = @"SELECT * FROM companies WHERE id = @id;";
      return _db.QueryFirstOrDefault<Company>(sql, new { id });
    }

    internal Company Create(Company company)
    {
      string sql = @"INSERT INTO companies (name) VALUES (@Name); SELECT LAST_INSERT_ID();";
      company.Id = _db.ExecuteScalar<int>(sql, company);
      return company;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM companies WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}