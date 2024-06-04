using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MisaAsp.Models;
using MisaAsp.Services;
using MisaAsp.Repositories;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly ServiceRepository _repository;

    public ServicesController(ServiceRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Service>> GetServices()
    {
        return await _repository.GetServicesAsync();
    }
}
