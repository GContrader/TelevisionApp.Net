using System;
using System.Collections.Generic;

namespace ToDoApp.DataAccessLayer.Entities;

public class Programma
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime Orario { get; set; }

    public List<User> listaUtentiConPreferito { get; set;}
}

