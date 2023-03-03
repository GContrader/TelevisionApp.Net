using System;

namespace ToDoApp.DataAccessLayer.Entities;

public partial class TodoItem
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime LastModified { get; set; }

    public bool IsComplete { get; set; }
}
