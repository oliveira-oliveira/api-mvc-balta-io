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
        
        [HttpGet("/{id:int}")]
        public ToDoModel GetById([FromRoute] int id,
                                 [FromServices] AppDbContext context)
        {

            return context.ToDos.FirstOrDefault(x => x.Id == id);
        }
        
        [HttpPost("/")]
        public ToDoModel Post([FromBody] ToDoModel todo, 
                              [FromServices] AppDbContext context)
        {
            context.ToDos.Add(todo);
            context.SaveChanges();

            return todo;
        }

        [HttpPut("/{id:int}")]
        public ToDoModel Put([FromRoute] int id,
                             [FromBody] ToDoModel toDo, 
                             [FromServices] AppDbContext context)
        {
            var model = context.ToDos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return null;
            
            model.Title = toDo.Title;
            model.Done = toDo.Done;

            context.ToDos.Update(model);
            context.SaveChanges();
            return model;
        }

        
        [HttpDelete("/{id:int}")]
        public ToDoModel Delete([FromRoute] int id,
                             [FromServices] AppDbContext context)
        {
            var model = context.ToDos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return null;

            context.ToDos.Remove(model);
            context.SaveChanges();
            return model;
        }

    }
}