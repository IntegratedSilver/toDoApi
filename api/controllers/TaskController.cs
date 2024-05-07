using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context){
            _context = context;
            
        }
        
         [HttpGet]
        public async Task<IEnumerable<ToDo>> getTask(){
            var task = await _context.ToDos.AsNoTracking().ToListAsync();
            return task;
        }

        [HttpPost]
        public async Task<IActionResult> Create (ToDo ToDo){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            await _context.AddAsync(ToDo);
            var result = await _context.SaveChangesAsync();

            if(result > 0){
                return Ok();
            }
            return BadRequest();
        }

         [HttpDelete ("{id:int}")]
    public async Task<IActionResult> Delete(int id){
        var task = await _context.ToDos.FindAsync(id);
        if(task == null){
            return NotFound();
        }

        _context.Remove(task);

           var result = await _context.SaveChangesAsync();

           if(result > 0){
            return Ok("Task was deleted");
           }
        return BadRequest ("unable to delete task");


    }

     [HttpGet("{id:int}")]

     public async Task<ActionResult<ToDo>> GetTask(int id){
        var task = await _context.ToDos.FindAsync(id);
        if(task == null){
            return NotFound("Sorry, task was not found");
        }
        return Ok(task);
     }


     [HttpPut ("{id:int}")]
     public async Task<IActionResult> EditTask (int id, ToDo task){
        var taskFromDb = await _context.ToDos.FindAsync(id);

        if(taskFromDb == null){
            return BadRequest ("Task not found");
        }

        taskFromDb.DayName = task.DayName;
        taskFromDb.objective1 = task.objective1;
        taskFromDb.Objective2 = task.Objective2;
        taskFromDb.Objective3 = task.Objective3;
        taskFromDb.Objective4 = task.Objective4;
        taskFromDb.Objective5 = task.Objective5;

        var result = await _context.SaveChangesAsync();

        if(result > 0){
            return Ok("Task was edited");
        }
        return BadRequest("Task to update data");
     }



    }
}