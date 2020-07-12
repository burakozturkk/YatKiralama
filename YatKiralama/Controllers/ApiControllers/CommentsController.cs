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
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("api/CommentsController/{id}")]
        public List<Comment> Get(int id)
        {
           var yorumlar = from t1 in _context.Comments where t1.YatId == id
                                        select new Comment { ID = t1.ID,Detail = t1.Detail, Name = t1.Name, CreatedDate = t1.CreatedDate , YatId = t1.YatId ,UserID = t1.UserID };
            return yorumlar.ToList();
        }
    }
}