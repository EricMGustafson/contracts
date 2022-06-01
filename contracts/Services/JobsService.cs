using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Repositories;

namespace contracts.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal object Create(Job newJob)
    {
      return _repo.Create(newJob);
    }
    internal Job Get(int id)
    {
      Job found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }
    internal void Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
    }

    internal List<JobViewModel> GetJobs(int jobId)
    {
      List<JobViewModel> jobs = _repo.GetJobs(jobId);
      return jobs;
    }
  }
}