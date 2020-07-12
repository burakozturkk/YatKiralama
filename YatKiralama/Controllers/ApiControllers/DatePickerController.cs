using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YatKiralama.Data;
using YatKiralama.Models;

namespace YatKiralama.Controllers.ApiControllers
{
    
    [ApiController]
    public class DatePickerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DatePickerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("api/DatePickerController/{id}/{date}/")]
        public List<Saatler> Get(int id, DateTime date)
        {
            var list = new List<Saatler>();
            
            var kirala2 = from t1 in _context.Kirala
                          from t2 in _context.Saatler
                          where t1.SaatID == t2.ID && t1.Tarih.ToString() == date.ToString("yyyy-MM-dd") && t1.YatID == id
                          select new Saatler { Saat = t2.Saat, ID = t2.ID };
            if (kirala2.Any())
            {
                var kirala3 = kirala2.ToList();
                var saatler = _context.Saatler.ToList();
                for (int i = 0; i < kirala3.Count; i++)
                {
                    for (int j = 0; j < saatler.Count; j++)
                    {
                        if (kirala3[i].Saat == saatler[j].Saat)
                        {
                            saatler.RemoveAt(j);
                        }
                    }
                }
                return saatler;
            }
            if (!kirala2.Any())
            {
                kirala2 = from t2 in _context.Saatler
                          select new Saatler { Saat = t2.Saat, ID = t2.ID };
            }
            return kirala2.ToList();
        }
    }
}