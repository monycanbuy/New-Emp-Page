using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Contracts;
using Shared.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IGenericRepositoryInterface<Customer> genericRepositoryInterface)
        : GenericController<Customer>(genericRepositoryInterface)
    {
    }
}
