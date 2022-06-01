using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracts.Models;
using Dapper;

namespace contracts.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Job Get(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id;";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }
    internal object Create(Job newJob)
    {
      string sql = @"INSERT INTO jobs (companyId, contractorsId) VALUES (@CompanyId, @ProductId); SELECT LAST_INSERT_ID();";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }

    internal void Delete(int jobId)
    {
      string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { jobId });
    }

    internal List<JobViewModel> GetJobs(int jobId)
    {
      string sql = @"
      SELECT
      c.*,
      j.id AS jobsId
      FROM jobs j
      JOIN contractor c ON j.contractorId = c.id
      WHERE j.companyId = @companyId
      ";
      return _db.Query<JobViewModel>(sql, new { jobId }).ToList();
    }
  }
}