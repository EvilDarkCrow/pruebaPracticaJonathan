using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Newtonsoft.Json;
using pruebaPracticaJonathan.Connection;
using pruebaPracticaJonathan.Models;
using RestSharp;
using System;
using System.Runtime.InteropServices.Marshalling;
using System.Threading;
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

        public async Task<List<postDetail>> GetPosts()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/comments", Method.Get);
            var queryResult = client.Execute(request);
            if(queryResult.IsSuccessful)
            {

                var jsonContent = queryResult.Content;
                List<Posts> comments = JsonConvert.DeserializeObject<List<Posts>>(jsonContent);

                var listFiltering = comments
                    .GroupBy(p => p.postId)
                    .OrderByDescending(g => g.Count())
                    .Take(3)
                    .Select(g => new
                    {
                        id = g.Key,
                        commentAmount = g.Count()
                    });

                List <postDetail> returnedList = new List<postDetail>();

                foreach(var a in listFiltering)
                {
                    returnedList.Add(new postDetail
                    {
                        id = a.id,
                        commentAmount = a.commentAmount
                    });
                   
                }

                return returnedList;

            } else
            {
                return null;
            }
            
            
        }


        

        
    }
}
