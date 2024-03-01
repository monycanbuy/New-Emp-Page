using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Contracts;
using Shared.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(IGenericRepositoryInterface<Country> genericRepositoryInterface)
        : GenericController<Country>(genericRepositoryInterface)
    {
    }
}
