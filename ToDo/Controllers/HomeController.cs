using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public List<ToDoModel> Get([FromServices] AppDbContext context)
        {
            return context.ToDos.ToList();
        }
        
        [HttpPost("/")]
        public ToDoModel Post([FromBody] ToDoModel todo, 
                            [FromServices] AppDbContext context)
        {
            context.ToDos.Add(todo);
            context.SaveChanges();

            return todo;
        }

    }
}