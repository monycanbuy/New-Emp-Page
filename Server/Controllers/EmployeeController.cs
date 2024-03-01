using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Contracts;
using Shared.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IGenericRepositoryInterface<Employee> genericRepositoryInterface)
        : GenericController<Employee>(genericRepositoryInterface)
    {
    }
}
