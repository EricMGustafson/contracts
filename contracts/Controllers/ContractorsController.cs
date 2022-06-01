using System;
using System.Collections.Generic;
using contracts.Models;
using contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contracts.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _cs;

    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }
    [HttpGet]
    public ActionResult<List<Contractor>> Get()
    {
      try
      {
        List<Contractor> contractors = _cs.Get();
        return Ok(contractors);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        Contractor contractor = _cs.Get(id);
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Contractor> Create([FromBody] Contractor contractor)
    {
      try
      {
        Contractor newContractor = _cs.Create(contractor);
        return Created($"/api/contractors/{newContractor.Id}", newContractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete]
    [Authorize]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _cs.Delete(id);
        return Ok("Deleted...");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }

}