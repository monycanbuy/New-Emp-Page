using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Services.Contracts;
using Shared.Entities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController(IGenericRepositoryInterface<Branch> genericRepositoryInterface)
        : GenericController<Branch>(genericRepositoryInterface)
    {
    }
}
