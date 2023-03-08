using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Models
{
    public class ProgrammaDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Orario { get; set; }
    }
}
