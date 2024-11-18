using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Repo;
using Lecture16_1.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lecture16_1.API.Controllers
{
    [ApiController]
    [Route("Klientai")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("AddClient")]
        public void AddClient(Klientas klientas)
        {
            Log.Information("AddClient request received");
            try
            {
                _clientService.AddClient(klientas);
                Log.Information("AddClient request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method AddClient. Exception thrown {e.Message}");
            }
        }

        [HttpDelete("DeleteClient")]
        public void DeleteClient(int id)
        {
            Log.Information("DeleteClient request received");
            try
            {
                _clientService.DeleteClient(id);
                Log.Information("DeleteClient request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method DeleteClient. Exception thrown {e.Message}");
            }
        }

        [HttpGet("GetAllClients")]
        public IActionResult GetAllClients()
        {
            Log.Information("GetAllClients request received");
            try
            {
                var x = _clientService.GetAllClients();
                Log.Information("GetAllClients request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllClients. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetClient")]
        public IActionResult GetClient(int id)
        {
            Log.Information("GetClient request received");
            try
            {
                var x = _clientService.GetClient(id);
                Log.Information("GetClient request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetClient. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpPatch("UpdateClient")]
        public void UpdateClient(Klientas klientas)
        {
            Log.Information("UpdateClient request received");
            try
            {
                _clientService.UpdateClient(klientas);
                Log.Information("UpdateClient request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method UpdateClient. Exception thrown {e.Message}");
            }
        }
    }
}
