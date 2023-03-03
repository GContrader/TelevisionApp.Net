namespace ToDoApp.BusinessLayer.Models
{
    /*
     * Questo DTO verrà usato come input al servizio
     */
    public class TodoItemCreateDto
    {
        public string Title { get; set; }
        public bool IsComplete { get; set; }
    }
}
