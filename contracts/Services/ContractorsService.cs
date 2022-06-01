using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Repositories;

namespace contracts.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;

    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }

    internal List<Contractor> Get()
    {
      return _repo.Get();
    }

    internal Contractor Get(int id)
    {
      Contractor foundContractor = _repo.Get(id);
      if (foundContractor == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundContractor;
    }

    internal Contractor Create(Contractor contractor)
    {
      Contractor newContractor = _repo.Create(contractor);
      return newContractor;
    }

    internal void Delete(int id)
    {
      Contractor foundContractor = Get(id);
      _repo.Delete(id);
    }

  }
}