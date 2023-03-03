namespace ToDoApp.BusinessLayer.Models
{
    /*
     * Questo DTO verrà usato come output dal servizio
     */
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LastModified { get; set; }    // Fromato: DD/MM/YYYY
        public bool IsComplete { get; set; }
    }
}
