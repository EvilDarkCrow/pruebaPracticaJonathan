using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaPracticaJonathan.Models;
using System.Collections.Generic;
using pruebaPracticaJonathan.Connection;
using Microsoft.IdentityModel.Tokens;
using pruebaPracticaJonathan.Managers;

namespace pruebaPracticaJonathan.Controllers
{
    [ApiController]
    [Route("lastOrder")]
    public class LastOrderController: ControllerBase
    {
        private readonly DbContexto context;
        private readonly Manager manager;

        public LastOrderController(Manager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Route("getLastOrder")]
        public async Task<ActionResult<Manager.orderDetail>> getLastOrder()
        {
            var entities = await manager.GetMemberAndLastOrder();
            return Ok(entities);
        }

    }
}
