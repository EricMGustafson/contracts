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
  public class CompanysController : ControllerBase
  {
    private readonly CompanysService _cs;
    private readonly JobsService _js;

    public CompanysController(CompanysService cs, JobsService js)
    {
      _cs = cs;
      _js = js;
    }

    [HttpGet]
    public ActionResult<List<Company>> Get()
    {
      try
      {
        List<Company> company = _cs.Get();
        return Ok(company);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Company> Get(int id)
    {
      try
      {
        Company company = _cs.Get(id);
        return Ok(company);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/contractors")]
    public ActionResult<List<JobViewModel>> GetJobs(int id)
    {
      try
      {
        List<JobViewModel> jobs = _js.GetJobs(id);
        return Ok(jobs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
        throw;
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Company> Create([FromBody] Company company)
    {
      try
      {
        Company newCompany = _cs.Create(company);
        return Created($"/api/companys/{newCompany.Id}", newCompany);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Company> Delete(int id)
    {
      try
      {
        _cs.Delete(id);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}