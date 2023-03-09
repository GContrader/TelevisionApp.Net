using System;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Models
{
    public class CreaUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataNascita { get; set; }
        public Ruolo Ruolo { get; set; }
    }
}
