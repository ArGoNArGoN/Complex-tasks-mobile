using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace project.Services.Entitys.APIService
{
    public class ToDoEntityAPIContext
        : ISupportHttpClient, ICRUDAsync<ToDoEntity>
    {
        public Task CreateAsync(ToDoEntity entity)
        {
            return Task.CompletedTask;
        }
        public Task DeleteAsync(ToDoEntity entity)
        {
            return Task.CompletedTask;
        }

        public async Task<ToDoEntity> ReadAsync(Int32 identity)
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync($"{this.GetBaseURL()}ToDo/{identity}");

                var item = await this.ResponseValidate<ToDoEntity>(response);

                item.TypeTask = "ToDo";

                return item;
            }
        }
        
        public async Task<IEnumerable<ToDoEntity>> ReadAsync()
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.GetAsync($"http://192.168.0.101:8200/api/ToDo");

                var list = await this.ResponseValidate<IEnumerable<ToDoEntity>>(response);
                
                foreach (var item in list)
                    item.TypeTask = "ToDo";

                return list;
            }
        }

        public async Task UpdateAsync(ToDoEntity entity)
        {
            using (var client = this.GetHttpClient())
            {
                var response = await client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), $"{this.GetBaseURL()}ToDo/{entity.Identity}") { Content=this.GetStringContent(entity) });
            }
        }
    }
}
