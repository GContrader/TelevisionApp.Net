using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Models
{
    public class AziendaDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<Programma> Programmi {get; set; }
    }
}
