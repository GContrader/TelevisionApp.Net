using System;
using System.Collections.Generic;

namespace ToDoApp.DataAccessLayer.Entities;
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataNascita { get; set; }
        public Ruolo Ruolo { get; set; }
        public List<Programma> listaPreferiti { get; set; }
    }
