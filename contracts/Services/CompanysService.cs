using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Repositories;

namespace contracts.Services
{
  public class CompanysService
  {
    private readonly CompanysRepository _repo;

    public CompanysService(CompanysRepository repo)
    {
      _repo = repo;
    }

    internal List<Company> Get()
    {
      return _repo.Get();
    }

    internal Company Get(int id)
    {
      Company foundCompany = _repo.Get(id);
      if (foundCompany == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundCompany;
    }

    internal Company Create(Company company)
    {
      Company newCompany = _repo.Create(company);
      return newCompany;
    }

    internal void Delete(int id)
    {
      _repo.Delete(id);
    }
  }
}