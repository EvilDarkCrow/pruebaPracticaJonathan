using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using pruebaPracticaJonathan.Connection;
using pruebaPracticaJonathan.Models;
using static pruebaPracticaJonathan.Managers.Manager;

namespace pruebaPracticaJonathan.Managers
{
    public class Manager
    {
        private readonly DbContexto context;

        public Manager(DbContexto contexto)
        {
            this.context = contexto;
        }

        public async Task<List<orderDetail>> GetMemberAndLastOrder()
        {
            var listFiltering = await (
                from order in context.orders
                join member in context.members on order.MemberId equals member.id
                join product in context.products on order.ProductId equals product.Id
                where order.dateOrder == context.orders
                .Where(o => o.MemberId == order.MemberId)
                .OrderByDescending(o => o.dateOrder)
                .Select(o => o.dateOrder)
                .FirstOrDefault()
                select new orderDetail
                {
                    orderId = order.id,
                    memberName = member.name,
                    productName = product.name
                }
                )
                .OrderBy(od => od.memberName)
                .ToListAsync();

            return listFiltering;
        }


        public class orderDetail
        {
            public string memberName { get; set; }
            public string productName { get; set; }
            public long orderId { get; set; }
        }
    }
}
