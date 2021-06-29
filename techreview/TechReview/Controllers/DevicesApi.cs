using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechReview.DbContexts;
using TechReview.Entities;

namespace TechReview.Controllers
{
    [ApiController]
    [Route("api")]
    public class DevicesApi : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;
        public DevicesApi(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("devices")]
        public IEnumerable<Devices> GetLines()
        {
            return dbcontext.Devices.ToArray();
        }

        [HttpGet]
        [Route("devices{id:Guid}")]
        public async Task<Devices> Getline(Guid id)
        {
            var item = await dbcontext.Devices.FirstOrDefaultAsync(e => e.Id == id);
            return item;
        }

        [HttpPost]
        [Route("devices")]
        public async Task<Guid> PostLine([FromBody] Devices d)
        {
            if (d != null)
            {
                var item = new Devices
                {
                    Name = d.Name,
                    Type = d.Type,
                    UrlImage = d.UrlImage,
                    ShortContent = d.ShortContent,
                    Content = d.Content,
                    Outstanding = d.Outstanding
                };
                dbcontext.Devices.Add(item);
                var change = await dbcontext.SaveChangesAsync();
                if (change >= 0) return item.Id;
            }
            return d.Id;
        }

        [HttpPut]
        [Route("devices")]
        public async Task<bool> PutLine(Devices d)
        {

            if (d != null)
            {
                var device = await dbcontext.Devices.FirstOrDefaultAsync(e => e.Id == d.Id);
                if (device != null)
                {
                    device.Name = d.Name;
                    device.Type = d.Type;
                    device.UrlImage = d.UrlImage;
                    device.Content = d.Content;
                    device.ShortContent = d.ShortContent;
                    device.Outstanding = d.Outstanding;
                    var change = await dbcontext.SaveChangesAsync();
                    if (change >= 0) return true;
                }
            }
            return false;
        }


        [HttpDelete]
        [Route("devices{id:Guid}")]
        public async Task<bool> DeletePoint(Guid id)
        {


            var device = await dbcontext.Devices.FirstOrDefaultAsync(e => e.Id == id);
            if (device != null)
            {
                dbcontext.Devices.Remove(device);
                var change = await dbcontext.SaveChangesAsync();
                if (change >= 0) return true;
            }

            return false;
        }
    }
}
