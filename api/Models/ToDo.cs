using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? DayName{ get; set; }
        public string? objective1{ get; set; }
        public string? Objective2{ get; set; }
        public string? Objective3{ get; set; }
        public string? Objective4{ get; set; }
        public string? Objective5{ get; set; }
    }
}