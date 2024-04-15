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
    public class Controller: ControllerBase
    {
        private readonly DbContexto context;
        private readonly Manager manager;

        public Controller(Manager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        [Route("getLastOrder")]
        public async Task<ActionResult<orderDetail>> getLastOrder()
        {
            var entities = await manager.GetMemberAndLastOrder();
            return Ok(entities);
        }

        [HttpGet]
        [Route("getPosts")]
        public async Task<ActionResult<Posts>> getPosts()
        {
            var entities = await manager.GetPosts();
            return Ok(entities);
        }

    }
}
