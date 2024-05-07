using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Task>> getTask(){
            var task = await _context.Tasks.AsNoTracking().ToListAsync();
            return task;
        }

        



    }
}