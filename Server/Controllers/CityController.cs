using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Contracts;
using Shared.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(IGenericRepositoryInterface<City> genericRepositoryInterface)
        : GenericController<City>(genericRepositoryInterface)
    {
    }
}
