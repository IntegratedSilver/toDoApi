using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using api.models;
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
        public async Task<IEnumerable<Tasks>> getTask(){
            var task = await _context.Task.AsNoTracking().ToListAsync();
            return task;
        }

        



    }
}