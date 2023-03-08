using System;


namespace ToDoApp.BusinessLayer.Models
{
    public  class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataNascita { get; set; }

    }
}
