using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Repo;
using Microsoft.AspNetCore.Mvc;

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
            _clientService.AddClient(klientas);
        }

        [HttpDelete("DeleteClient")]
        public void DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
        }

        [HttpGet("GetAllClients")]
        public List<Klientas> GetAllClients()
        {
            return _clientService.GetAllClients();
        }

        [HttpGet("GetClient")]
        public Klientas GetClient(int id)
        {
            return _clientService.GetClient(id);
        }

        [HttpPatch("UpdateClient")]
        public void UpdateClient(Klientas klientas)
        {
            _clientService.UpdateClient(klientas);
        }
    }
}
